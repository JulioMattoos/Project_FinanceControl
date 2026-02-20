using FinanceCotrol.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;

namespace FinanceCotrol.Context;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
}