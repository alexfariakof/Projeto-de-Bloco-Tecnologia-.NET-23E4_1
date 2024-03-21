using System.ComponentModel.DataAnnotations;

namespace  PixCharge.Application.Transactions.Dto;
public class ChargeDto
{
    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public Guid FlatId { get; set; }

    [Required]
    public DateTime ChargeDate { get; set; }

    public string? ChargeStatus {  get; set; }

    [Required]
    public decimal Value { get; set; }
}