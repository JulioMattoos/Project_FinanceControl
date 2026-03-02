using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCotrol.Models;

[Table("Transactions")]
public class Transaction
{
    [Key]
    public int TransactionId { get; set; }

    [Required]
    [StringLength(150)]
    public string? TransactionDescription { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valr minimo deve ser maior que 0")]
    public decimal TransactionValue { get; set; }

    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}