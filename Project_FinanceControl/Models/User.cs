using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCotrol.Models;

[Table("Users")]
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(150)]
    public string? Name { get; set; }

    [Required]
    [StringLength(200)]
    public string? Email { get; set; }

    [Required]
    [StringLength(20)]
    public string? Password { get; set; }

    public DateTime DateCreated { get; set; }
    public List<Transaction> Transactions { get; set; }
    public List<Category> Categories { get; set; }
}