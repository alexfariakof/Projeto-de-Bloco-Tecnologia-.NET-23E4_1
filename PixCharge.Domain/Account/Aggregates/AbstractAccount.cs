using PixCharge.Domain.Account.Agreggates;
using PixCharge.Domain.Account.ValueObject;
using PixCharge.Domain.Core.Aggregates;

namespace PixCharge.Domain.Account.Aggregates;
public abstract class AbstractAccount<T> : BaseModel
{
    public virtual User User { get; set; } = new User();
    public string Name { get; set; } = String.Empty;
    public string CPF { get; set; } = String.Empty;
    public DateTime Birth { get; set; }
    public Phone Phone { get; set; } = new Phone();
    public virtual Address Address { get; set; } = new Address();
    public virtual IList<Flat> Flats { get; set; } = new List<Flat>();
    public abstract void CreateAccount(T obj);

    public void AddFlat(Customer customer, Flat flat)
    {
        DisableActiveFlat();
        flat.DtActivation = DateTime.Now;
        flat.Active = true;
        this.Flats.Add(flat);
    }
    private void DisableActiveFlat()
    {
        if (this.Flats.Count > 0 && this.Flats.Any(x => x.Active))
            this.Flats.First(x => x.Active).Active = false;
    }
}
