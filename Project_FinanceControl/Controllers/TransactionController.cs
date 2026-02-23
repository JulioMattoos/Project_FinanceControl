using FinanceCotrol.Context;
using Microsoft.AspNetCore.Mvc;

namespace Project_FinanceControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public TransactionController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delet(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(c => c.TransactionId == id);
            if (transaction == null)
            {
                return NotFound("Transação não encontrada...");
            }
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
            return Ok("Transaçao removida com sucesso...")
        }
    }
}