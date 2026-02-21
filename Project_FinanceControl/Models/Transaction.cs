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

    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public int UserId { get; set; }
    public User? UserName { get; set; }
    public int CategoryId { get; set; }
    public Category? CategoryName { get; set; }
}