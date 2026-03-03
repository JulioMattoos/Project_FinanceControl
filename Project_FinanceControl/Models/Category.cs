using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Transactions;

namespace FinanceCotrol.Models;

[Table("Categories")]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Nome da categoria é obrigatorio...")]
    [StringLength(40)]
    public string? CategoryName { get; set; }

    public int? UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public Transaction? Transaction { get; set; }
}