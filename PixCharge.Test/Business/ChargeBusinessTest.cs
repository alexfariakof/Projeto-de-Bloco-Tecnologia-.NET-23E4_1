using PixCharge.Business;
using PixCharge.Business.Interfaces;

namespace Business;
public class ChargeBusinessTest
{
    [Fact]
    public void Should_Create_PIX_Transaction_With_Success()
    {
        var customer = MockCustomer.GetFaker();
        PIX pix = new PIX(customer);
        IChargeBusiness business = new ChargeBusiness();

        business.CreateTransaction(pix, 4236.25m, "Teste Incusão Business Implementation");
        
        Assert.NotNull(pix.QrCode.Url);
        Assert.NotNull(pix.QrCode.BrCode);
    }
}
