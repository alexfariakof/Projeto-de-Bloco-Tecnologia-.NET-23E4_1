using PixCharge.Integration.Adapter;
using PixCharge.Integration.Adapter.Plataform.OpenPix;
using PixCharge.Service.Interfaces;
using PixCharge.Domain.Account.Aggregates;
using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.Aggregates;
using PixCharge.Application.Transactions.Dto;
using AutoMapper;
using PixCharge.Repository;

namespace PixCharge.Application.Transactions;
public class ChargeService : ServiceBase<ChargeDto, Charge>, IService<ChargeDto>, IChargeService
{
    private const int INTERVAL_TRANSACTON_PIX = -4;
    public ChargeService(IMapper mapper, IRepository<Charge> chargeRepository) : base(mapper, chargeRepository)
    {

    }


    public void CreateTransaction(PIX pix, Monetary value, string description = "")
    {
        Transaction transaction = new Transaction
        {
            CorrelationId = pix.CorrelationId,
            Customer = pix.Customer,
            Value = value,
            Description = description,
            DtTransaction = DateTime.Now,
        };

        // Verificãção de Existência de uma Transação PIX já Criada com o mesmo Valor dentro do Intervalo Minimo 
        transaction = ValidateTransaction(transaction, pix.Customer) ?? transaction;

        IPix chargePix = new OpenPix();
        var charge = chargePix.CreateCharge(value, transaction.CorrelationId.Value.ToString());

        //pix.Status = charge.Status;
        pix.QrCode.Url = charge.QrCodeImage;
        pix.QrCode.BrCode = charge.BrCode;

        if (transaction.Id.ToString().Equals("00000000-0000-0000-0000-000000000000"))
        {
            transaction.Id = Guid.NewGuid();
            pix.Customer.Transactions.Add(transaction);
        }
    }

    public override ChargeDto Create(ChargeDto obj)
    {
        throw new NotImplementedException();
    }

    public override bool Delete(ChargeDto obj)
    {
        throw new NotImplementedException();
    }

    public override List<ChargeDto> FindAll(Guid userId)
    {
        throw new NotImplementedException();
    }

    public override ChargeDto FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public override ChargeDto Update(ChargeDto obj)
    {
        throw new NotImplementedException();
    }

    private Transaction ValidateTransaction(Transaction transaction, Customer customer)
    {
        var lastTransactions = customer.Transactions.Where(t => t.DtTransaction > DateTime.Now.AddMinutes(INTERVAL_TRANSACTON_PIX) && t.Value.Equals(transaction.Value));
        if (lastTransactions?.Count() >= 1)
            return lastTransactions.Last();

        return null;
    }
}