using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;

//using FinanceCotrol.Entities;
namespace FinanceCotrol.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public UserController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("Usuarios")]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _context.Users.ToList();
            if (users == null)
            {
                return NotFound("Usuarios não encontrados...");
            }
            return Ok(users);
        }
    }
}