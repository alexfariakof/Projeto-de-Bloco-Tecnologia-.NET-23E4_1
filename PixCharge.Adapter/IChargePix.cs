using PixCharge.Domain.Transactions.Aggregates;

namespace PixCharge.Adapter;
public interface IChargePix
{
    public Charge CreateCharge(long Value, string CorrelationID);
    public Boolean IsChargeApporve(Guid correlationID);
}