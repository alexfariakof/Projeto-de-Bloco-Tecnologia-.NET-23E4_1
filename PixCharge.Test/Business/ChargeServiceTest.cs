using AutoMapper;
using Moq;
using PixCharge.Application.Transactions;
using PixCharge.Repository;

namespace Service;
public class ChargeServiceTest
{
    private Mock<IMapper> mapperMock;
    private Mock<IRepository<Charge>> chargeRepositoryMock;
    private readonly ChargeService chargeService;
    private readonly List<Charge> mockListCharge = MockCharge.GetListFaker(5);
    public ChargeServiceTest()
    {

        mapperMock = new Mock<IMapper>();
        chargeRepositoryMock = Usings.MockRepositorio(mockListCharge);

        chargeService = new ChargeService(mapperMock.Object, chargeRepositoryMock.Object);
    }
    [Fact]
    public void Should_Create_PIX_Transaction_With_Success()
    {
        var customer = MockCustomer.GetFaker();
        PIX pix = new PIX(customer);
        chargeService.CreateTransaction(pix, new  Monetary((decimal)new Random().NextSingle()*10000), "Teste Inclusão Service Implementation");
        
        Assert.NotNull(pix.QrCode.Url);
        Assert.NotNull(pix.QrCode.BrCode);
    }
}
