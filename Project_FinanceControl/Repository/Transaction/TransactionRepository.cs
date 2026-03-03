using FinanceCotrol.Context;
using FinanceCotrol.Models;

namespace Project_FinanceControl.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly FinanceDbContext _context;

    public TransactionRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
        var transactions = _context.Transactions.ToList();
        if (transactions == null)
            throw new KeyNotFoundException("Transações não encontradas");
        return transactions;
    }

    public Transaction GetTransactionById(int id)
    {
        var transaction = _context.Transactions.FirstOrDefault(c => c.TransactionId == id);
        if (transaction == null)
            throw new KeyNotFoundException($"Transação com id:{id} não encontrada");
        return transaction;
    }

    public TransactionRepository CreateTransaction(Transaction transaction)
    {
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction), "Transação inválida");
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
        return this;
    }

    public Transaction UpdateTransaction(Transaction transaction)
    {
        if (transaction == null)
            throw new AbandonedMutexException(nameof(transaction));
        _context.Entry(transaction).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return transaction;
    }
}