using PixCharge.Domain.Transactions.Aggregates;
using PixCharge.Integration.Adapter.Plataform.OpenPix.Models;

namespace PixCharge.Integration.Adapter.Converters;
public class ChargeParser : IParser<Charge, ChargeOpenPix>, IParser<ChargeOpenPix, Charge>
{
    public ChargeOpenPix Parse(Charge origin)
    {
        if (origin == null) return new ChargeOpenPix();
        return new ChargeOpenPix
        {
            Customer =
            {
                Name = origin.Customer.Name,
                TaxID = origin.Customer.TaxID,
                Email = origin.Customer.Email,
                Phone = origin.Customer.Phone,
                CorrelationID = origin.Customer.CorrelationID.ToString(),
                Address =
                {
                    Zipcode = origin.Customer.Address.Zipcode,
                    Street = origin.Customer.Address.Street,
                    Number = origin.Customer.Address.Number,
                    Neighborhood = origin.Customer.Address.Neighborhood,
                    City = origin.Customer.Address.City,
                    State = origin.Customer.Address.State,
                    Complement = origin.Customer.Address.Complement,
                    Country = origin.Customer.Address.Country
                }
            },
            Value = origin.Value,
            Identifier = origin.Identifier,
            CorrelationID = origin.CorrelationID.ToString(),
            PaymentLinkID = origin.PaymentLinkID,
            TransactionID = origin.TransactionID,
            Status = origin.Status,
            Discount = origin.Discount,
            ValueWithDiscount = origin.ValueWithDiscount,
            ExpiresDate  = origin.ExpiresDate,
            Type = origin.Type,
            CreatedAt = origin.CreatedAt,
            UpdatedAt = origin.UpdatedAt,
            BrCode = origin.BrCode,
            ExpiresIn = origin.ExpiresIn,
            PixKey = origin.PixKey,
            PaymentLinkUrl = origin.PaymentLinkUrl,
            QrCodeImage = origin.QrCodeImage,
            GlobalID = origin.GlobalID
        };
    }

    public  Charge Parse(ChargeOpenPix origin)
    {
        if (origin == null) return new Charge();
        return new Charge
        {
            /*
            Customer =
            {
                Name = origin.Customer?.Name,
                TaxID = origin?.Customer?.TaxID,
                Email = origin.Customer?.Email,
                Phone = origin.Customer?.Phone,
                CorrelationID = new Guid(origin.Customer?.CorrelationID),
                Address =
                {
                    Zipcode = origin.Customer?.Address.Zipcode,
                    Street = origin.Customer?.Address.Street,
                    Number = origin.Customer?.Address.Number,
                    Neighborhood = origin.Customer?.Address.Neighborhood,
                    City = origin.Customer?.Address.City,
                    State = origin.Customer?.Address.State,
                    Complement = origin.Customer.Address.Complement,
                    Country = origin.Customer.Address.Country
                }
            },*/
            Value = origin.Value,
            Identifier = origin.Identifier,
            CorrelationID = new Guid(origin.CorrelationID.ToString()),
            PaymentLinkID = origin.PaymentLinkID,
            TransactionID = origin.TransactionID,
            Status = origin.Status,
            Discount = origin.Discount,
            ValueWithDiscount = origin.ValueWithDiscount,
            ExpiresDate = origin.ExpiresDate,
            Type = origin.Type,
            CreatedAt = origin.CreatedAt,
            UpdatedAt = origin.UpdatedAt,
            BrCode = origin.BrCode,
            ExpiresIn = origin.ExpiresIn,
            PixKey = origin.PixKey,
            PaymentLinkUrl = origin.PaymentLinkUrl,
            QrCodeImage = origin.QrCodeImage,
            GlobalID = origin.GlobalID
        };
    }

    public List<ChargeOpenPix> ParseList(List<Charge> origin)
    {
        throw new NotImplementedException();
    }

    public List<Charge> ParseList(List<ChargeOpenPix> origin)
    {
        throw new NotImplementedException();
    }
}
