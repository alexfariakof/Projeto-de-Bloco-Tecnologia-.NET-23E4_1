using PixCharge.Domain.Account.Aggregates;
using PixCharge.Domain.Core.ValueObject;
using PixCharge.Domain.Core.Aggregates;

namespace PixCharge.Domain.Transactions.Aggregates;

[Serializable]
public class Charge : BaseModel
{
    public Guid CorrelationID { get; set; }
    public virtual Customer Customer { get; set; } = new();
    public virtual Flat Flat { get; set; } = new();
    public Monetary Value { get; set; } = 0;
    public string Identifier { get; set; } = String.Empty;
    public string PaymentLinkID { get; set; } = String.Empty;
    public string TransactionID { get; set; } = String.Empty;
    public string Status { get; set; } = String.Empty;
    public int Discount { get; set; } = 0;
    public int ValueWithDiscount { get; set; } = 0;
    public DateTime ExpiresDate { get; set; }
    public string Type { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string BrCode { get; set; } = String.Empty;
    public int ExpiresIn { get; set; } = 0;
    public string PixKey { get; set; } = String.Empty;
    public string PaymentLinkUrl { get; set; } = String.Empty;
    public string QrCodeImage { get; set; } = String.Empty;
    public string GlobalID { get; set; } = String.Empty;
    public Charge() { }
    public Charge(PIX pix, Flat flat,  Monetary value)
    {
        Customer = pix.Customer;
        Flat = flat;
        CorrelationID = pix.CorrelationId;
        Value = value;
    }
}
