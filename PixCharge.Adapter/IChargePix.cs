using PixCharge.Domain.Transactions.Aggreggates;

namespace PixCharge.Adapter;
public interface IChargePix
{
    public Charge CreateCharge(long Value, string CorrelationID);
    public Boolean IsChargeApporve(Guid correlationID);
}