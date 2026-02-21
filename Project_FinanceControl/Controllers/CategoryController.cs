using FinanceCotrol.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceCotrol.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_FinanceControl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public CategoryController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _context.Categories.Include(c => c.User).ToList();
            if(categories == null)
            {
                return BadRequest("Categorias não encontradas...");
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories
                .Include(c => c.User)
                .FirstOrDefault(c => c.CategoryId == id);
            if(category == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if(category == null)
            {
                return BadRequest("Categoria invalida...");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Categoria criada com sucesso...");
        }
    }
}
