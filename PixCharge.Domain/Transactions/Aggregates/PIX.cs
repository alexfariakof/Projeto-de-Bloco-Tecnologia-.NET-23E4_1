using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Core.Aggreggates;
using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.ValueObject;

namespace PixCharge.Domain.Transactions.Aggreggates;
public class PIX: BaseModel
{
    private const int INTERVAL_TRANSACTON_PIX = -4;
    public DateTime Date { get; set; }
    public Status Status { get; set; }
    public Guid CorrelationId { get; set; }
    public Customer Customer { get; set; }
    public Monetary Monetary { get; set; }
    public string Description { get; set; }
    public QRCode QrCode { get; set; } = new QRCode();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public PIX(Customer custumer)
    {
        Id = Guid.NewGuid();
        CorrelationId = custumer.Id;
        Customer = custumer;
    }

    public void CreateTransaction(Monetary value, string description="")
    {
        Transaction transaction = new Transaction
        {
            CorrelationId = this.CorrelationId,
            Customer = this.Customer,
            Value = value,
            Description = description,
            DtTransaction = DateTime.Now,
        };

        // Verificãção de Existência de uma Transação PIX já Criada com o mesmo Valor dentro do Intervalo Minimo 
        transaction = this.ValidateTransaction(transaction) ?? transaction;

        Charge charge = new Charge(this.Customer, transaction.CorrelationId.ToString(), value.Cents);
        charge.CreateChargePix(charge);

        this.QrCode.Url = charge.QrCodeImage  ?? "";
        this.QrCode.BrCode = charge.BrCode ??  "";

        if (transaction.Id.ToString().Equals("00000000-0000-0000-0000-000000000000"))
        {
            transaction.Id = Guid.NewGuid();
            this.Transactions.Add(transaction);
        }
    }
    private Transaction ValidateTransaction(Transaction transaction)
    {
        var lastTransactions = this.Transactions.Where(t => t.DtTransaction > DateTime.Now.AddMinutes(INTERVAL_TRANSACTON_PIX) && t.Value.Equals(transaction.Value));
        if (lastTransactions?.Count() >= 1)
            return lastTransactions.Last();

        return null;        
    }
}
