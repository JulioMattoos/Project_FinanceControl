using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace FinanceCotrol.Models;

[Table("Categories")]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(40)]
    public string? Name { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
    public Transaction Transaction { get; set; }
}