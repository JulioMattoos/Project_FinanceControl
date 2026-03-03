using FinanceCotrol.Models;

namespace Project_FinanceControl.Repository;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactions();

    Transaction GetTransactionById(int id);

    Transaction CreateTransaction(Transaction transaction);

    Transaction UpdateTransaction(Transaction transaction);

    Transaction DeleteTransaction(int id);
}