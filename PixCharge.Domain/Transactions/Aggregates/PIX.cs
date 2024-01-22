using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Core.Aggreggates;
using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.ValueObject;

namespace PixCharge.Domain.Transactions.Aggreggates;
public class PIX: BaseModel
{
    
    public Guid CorrelationId { get; set; }
    public DateTime Date { get; set; }
    public Status Status { get; set; }    
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


}
