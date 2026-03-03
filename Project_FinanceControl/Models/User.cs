using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Project_FinanceControl.Models;

namespace FinanceCotrol.Models;

[Table("Users")]
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Nome é obrigatorio")]
    [StringLength(100)]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Informe seu email")]
    [StringLength(200)]
    public string? UserEmail { get; set; }

    [Required]
    [StringLength(20)]
    public string? Password { get; set; }

    public UserType UserType { get; set; }

    public DateTime DateCreated { get; set; }

    [JsonIgnore]
    public ICollection<Transaction>? Transactions { get; set; }

    [JsonIgnore]
    public ICollection<Category>? Categories { get; set; }
}