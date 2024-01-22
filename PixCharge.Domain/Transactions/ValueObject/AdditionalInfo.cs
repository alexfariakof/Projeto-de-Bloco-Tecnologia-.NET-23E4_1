using PixCharge.Domain.Core.Aggreggates;

namespace PixCharge.Domain.Transactions.ValueObject;

[Serializable]
public class AdditionalInfo : BaseModel
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}
