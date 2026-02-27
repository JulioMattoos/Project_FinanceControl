using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _context.Categories.Include(c => c.User).Where(c => c.CategoryId <= 30).AsNoTracking().ToListAsync();
            if (categories == null)
            {
                return BadRequest("Categorias não encontradas...");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]  //alterado para fazer requisição pelo nome da categoria, mais "facil" para requição
        public async Task<ActionResult<Category>> Get([FromBody][BindRequired] string name, int id)
        {
            var categoryName = name;
            var category = await _context.Categories
                .Include(c => c.User).AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryName == name);
            if (category == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return Ok(category);
        }

        [HttpPost("/Register")]
        public ActionResult Post(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCategoria",
                 new { id = category.CategoryId }, category);
        }

        [HttpPut("/update {id:int:min(1)}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Id invalido...");
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}