using PixCharge.Domain.Transactions.Aggregates;

namespace PixCharge.Repository.Persistency;
public class ChargeRepository : RepositoryBase<Charge>, IRepository<Charge>
{
    public RegisterContext Context { get; set; }
    public ChargeRepository(RegisterContext context) : base(context)
    {
        Context = context;
    }
}