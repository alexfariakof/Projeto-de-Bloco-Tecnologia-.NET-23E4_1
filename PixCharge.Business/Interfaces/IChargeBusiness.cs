using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.Aggreggates;

namespace PixCharge.Business.Interfaces;
public interface IChargeBusiness
{
    public void CreateTransaction(PIX pix, Monetary value, string description = "");
}