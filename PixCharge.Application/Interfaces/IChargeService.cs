using PixCharge.Application.Transactions.Dto;
using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.Aggregates;

namespace PixCharge.Service.Interfaces;
public interface IChargeService
{
    ChargeDto Create(ChargeDto obj);
    List<ChargeDto> FindAll(Guid userId);
    ChargeDto FindById(Guid id);
    ChargeDto Update(ChargeDto obj);
    bool Delete(ChargeDto obj);
    public void CreateTransaction(PIX pix, Monetary value, string description = "");
}