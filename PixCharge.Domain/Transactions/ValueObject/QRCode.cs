namespace PixCharge.Domain.Transactions.ValueObject;
public record QRCode
{
    public string Url { get; set; }
    public string BrCode { get; set; }
}
