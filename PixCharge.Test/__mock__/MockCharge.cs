using Bogus;

namespace __mock__;
public static class MockCharge
{
    public static Charge GetFaker()
    {
        var fakeCharge = new Faker<Charge>()
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(c => c.CorrelationID, f => f.Random.Guid())
            .RuleFor(c => c.Customer, MockCustomer.GetFaker)
            .RuleFor(c => c.Value, f => new Monetary(f.Finance.Amount()))
            .RuleFor(c => c.Identifier, f => f.Random.Word())
            .RuleFor(c => c.PaymentLinkID, f => f.Random.Word())
            .RuleFor(c => c.TransactionID, f => f.Random.Word())
            .RuleFor(c => c.Status, f => f.Random.Word())
            .RuleFor(c => c.Discount, f => f.Random.Int())
            .RuleFor(c => c.ValueWithDiscount, f => f.Random.Int())
            .RuleFor(c => c.ExpiresDate, f => f.Date.Future())
            .RuleFor(c => c.Type, f => f.Random.Word())
            .RuleFor(c => c.CreatedAt, f => f.Date.Past())
            .RuleFor(c => c.UpdatedAt, f => f.Date.Past())
            .RuleFor(c => c.BrCode, f => f.Random.Word())
            .RuleFor(c => c.ExpiresIn, f => f.Random.Int())
            .RuleFor(c => c.PixKey, f => f.Random.Word())
            .RuleFor(c => c.PaymentLinkUrl, f => f.Internet.Url())
            .RuleFor(c => c.QrCodeImage, f => f.Image.LoremPixelUrl())
            .RuleFor(c => c.GlobalID, f => f.Random.Word())
            .Generate();

        return fakeCharge ?? null;
    }

    public static List<Charge> GetListFaker(int count)
    {
        var chargeList = new List<Charge>();
        for (var i = 0; i < count; i++)
        {
            chargeList.Add(GetFaker());
        }
        return chargeList;

    }

}