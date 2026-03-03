using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_FinanceControl.Repository;

namespace Project_FinanceControl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _repository.GetAllCategories();
            return Ok(categories);  
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            var category = _repository.GetCategoryById(id);
            if (category == null)
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
                return BadRequest();
            }
            var categoryCreated = _repository.CreateCategory(category);
            return new CreatedAtRouteResult("ObterCategoria",
                 new { id = categoryCreated.CategoryId }, categoryCreated);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Id invalido...");
            }
            _repository.UpdateCategory(category);
            return Ok("Categoria atualizada com sucesso");
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var category = _repository.DeleteCategory(id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return Ok(category);
        }
    }
}