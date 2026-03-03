using FinanceCotrol.Models;
namespace Project_FinanceControl.Repository;

public interface ICategoryRepository
{
    public IEnumerable<Category> GetCategories();
    public Category GetCategoryById(int id);
    public Category CreateCategory(Category category);
    public Category UpdateCategory(Category category);
    public Category DeleteCategory(int id);


}
