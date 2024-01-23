using PixCharge.Domain.Core.Aggregates;

namespace PixCharge.Domain.Transactions.ValueObject;

[Serializable]
public class AdditionalInfo : BaseModel
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}
