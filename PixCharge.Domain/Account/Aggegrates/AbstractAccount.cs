using PixCharge.Domain.Account.ValueObject;
using PixCharge.Domain.Core.Aggreggates;

namespace PixCharge.Domain.Account.Aggegrates;
public abstract class AbstractAccount<T> : BaseModel
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateTime Birth { get; set; }
    public Phone Phone { get; set; } = new Phone();
    public Address Address { get; set; } = new Address();
    public Login Login { get; set; }        
    public abstract void CreateAccount(T obj);
}
