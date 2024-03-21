using PixCharge.Domain.Core.Aggregates;
using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Transactions.Aggregates;

namespace PixCharge.Domain.Account.Aggregates;
public class Flat : BaseModel
{
    public virtual Customer Customer { get; set; } = new();
    public virtual Guid CustomerId { get; set; }
    public Monetary Value { get; set; } = 0;
    public DateTime DtCreated { get; set; }
    public bool Active { get; set; }
    public DateTime DtActivation { get; set; }
    public virtual IList<Charge> Charges { get; set; } = new List<Charge>();
}
