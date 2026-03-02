using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project_FinanceControl.Models;

namespace FinanceCotrol.Models;

[Table("Users")]
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(150)]
    public string? UserName { get; set; }

    [Required]
    [StringLength(200)]
    public string? UserEmail { get; set; }

    [Required]
    [StringLength(20)]
    public string? Password { get; set; }

    public UserType UserType { get; set; }

    public DateTime DateCreated { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
    public ICollection<Category>? Categories { get; set; }
}