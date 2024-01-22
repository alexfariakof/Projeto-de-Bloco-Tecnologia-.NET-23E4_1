using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Core.Aggreggates;
using PixCharge.Domain.Transactions.ValueObject;
using PixCharge.Domain.Core.ValueObject;

namespace PixCharge.Domain.Transactions.Aggreggates;

[Serializable]
public sealed class Charge : BaseModel
{
    public Guid CorrelationID { get; set; }
    public Customer Customer { get; set; }
    public long  Value { get; set; }
    public string  Identifier { get; set; }    
    public string  PaymentLinkID { get; set; }
    public string  TransactionID { get; set; }
    public string  Status { get; set; }
    public AdditionalInfo[]? AdditionalInfo { get; set; }
    public int Discount { get; set; }
    public int  ValueWithDiscount { get; set; }
    public DateTime  ExpiresDate { get; set; }
    public string  Type { get; set; }
    public DateTime  CreatedAt { get; set; }    
    public DateTime UpdatedAt { get; set; }
    public string BrCode { get; set; }    
    public int  ExpiresIn { get; set; }
    public string  PixKey { get; set; }    
    public string  PaymentLinkUrl { get; set; }
    public string QrCodeImage { get; set; }
    public string  GlobalID { get; set; }
    public Charge() { }
    public Charge(PIX pix, Monetary value) 
    { 
        this.Customer = pix.Customer;
        this.CorrelationID = pix.CorrelationId;
        this.Value = value.Cents;
    }

}
