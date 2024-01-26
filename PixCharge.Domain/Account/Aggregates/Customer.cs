using PixCharge.Domain.Transactions.Aggregates;
using System.Text.Json.Serialization;

namespace PixCharge.Domain.Account.Aggregates;
public class Customer : AbstractAccount<Customer>
{
    public Guid? CorrelationID { get; set; }
    public string? TaxID { get; set; }
    public string? Email { get; set; }
    
    [JsonIgnore]
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    [JsonIgnore] 
    public List<Charge> Charges { get; set; } = new List<Charge>();
    public override void CreateAccount(Customer customer)
    {        
        this.Name = customer.Name;
        this.CPF = customer.CPF;
        this.Birth = customer.Birth;
        this.Phone = customer.Phone;
        this.Address = customer.Address;
        this.Login = customer.Login;
    }
}