using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.Aggregates;

namespace PixCharge.Business.Interfaces;
public interface IChargeBusiness
{
    public void CreateTransaction(PIX pix, Monetary value, string description = "");
}