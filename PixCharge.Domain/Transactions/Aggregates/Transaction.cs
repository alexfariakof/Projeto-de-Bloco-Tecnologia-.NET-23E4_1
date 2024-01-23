using PixCharge.Domain.Account.Aggregates;
using PixCharge.Domain.Core.Aggregates;
using PixCharge.Domain.Core.ValueObject;

namespace PixCharge.Domain.Transactions.Aggregates;
public class Transaction : BaseModel
{
    public Guid? CorrelationId { get; set; }
    public DateTime DtTransaction { get; set; }
    public Monetary Value { get; set; }
    public string Description { get; set; }
    public Customer Customer { get; set; }
}
