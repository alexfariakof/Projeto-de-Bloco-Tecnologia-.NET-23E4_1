namespace PixCharge.Domain.Core.ValueObject;
public record Monetary
{
    public decimal Value { get; set; }
    public long Cents { get { return (int)(Value * 100); } }
    public static implicit operator decimal(Monetary d) => d.Value;
    public static implicit operator Monetary(decimal value) => new Monetary(value);
    public Monetary(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Valor monetário não pode ser negativo");

        Value = value;
    }    
    public string Formatted_ptBr()
    {
        return $"R$ {Value.ToString("N2")}";
    }
}