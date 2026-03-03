using FinanceCotrol.Models;
namespace Project_FinanceControl.Repository;

public interface ICategoryRepository 
{
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(int id);

    Category CreateCategory(Category category);
    Category UpdateCategory(Category category);
    Category DeleteCategory(int id);
}
