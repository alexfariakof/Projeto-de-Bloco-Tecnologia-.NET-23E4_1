using PixCharge.Domain.Account.Aggregates;

namespace PixCharge.Repository.Persistency;
public class CustomerRepository : RepositoryBase<Customer>, IRepository<Customer>
{
    public CustomerRepository(RegisterContext context) : base(context)
    {
        Context = context;
    }
}