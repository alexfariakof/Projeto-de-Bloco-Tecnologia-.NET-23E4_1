using PixCharge.Domain.Transactions.Aggreggates;

namespace PixCharge.Domain.Account.Aggegrates;
public class Customer : AbstractAccount<Customer>
{
    public string? TaxID { get; set; }
    public string? Email { get; set; }
    public string? CorrelationID { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
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