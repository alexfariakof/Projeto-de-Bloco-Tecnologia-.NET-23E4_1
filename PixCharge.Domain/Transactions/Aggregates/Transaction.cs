using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Core.Aggreggates;
using PixCharge.Domain.Core.ValueObject;

namespace PixCharge.Domain.Transactions.Aggreggates;
public class Transaction : BaseModel
{
    public Guid? CorrelationId { get; set; }
    public DateTime DtTransaction { get; set; }
    public Monetary Value { get; set; }
    public String Description { get; set; }
    public Customer Customer { get; set; }    
}
