using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;
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
            if (categories == null)
            {
                return BadRequest("Categorias não encontradas...");
            }
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories
                .Include(c => c.User)
                .FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return Ok(category);
        }

        [HttpPost]
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

        [HttpPut("{id:int}")]
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

        [HttpDelete("{id:int}")]
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