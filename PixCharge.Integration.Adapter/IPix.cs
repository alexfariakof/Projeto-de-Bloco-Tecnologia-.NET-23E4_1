using PixCharge.Domain.Transactions.Aggregates;

namespace PixCharge.Integration.Adapter;
public interface IPix
{
    public Charge CreateCharge(long Value, string CorrelationID);
    public Boolean IsChargeApporve(Guid correlationID);
}