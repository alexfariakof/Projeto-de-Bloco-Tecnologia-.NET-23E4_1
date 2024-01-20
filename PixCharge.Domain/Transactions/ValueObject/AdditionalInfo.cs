namespace PixCharge.Domain.Transactions.ValueObject;

[Serializable]
public record AdditionalInfo
{
    public string Key { get; set; }
    public string Value { get; set; }
}
