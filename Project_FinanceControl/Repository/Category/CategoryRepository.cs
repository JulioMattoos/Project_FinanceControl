using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_FinanceControl.Repository;

public class CategoryRepository : ICategoryRepository
{

    private readonly FinanceDbContext _context;

    public CategoryRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        var categories = _context.Categories.ToList();
        return categories;
    }
    public Category GetCategoryById(int id) {
        return _context.Categories.Include(c => c.User).FirstOrDefault(c => c.CategoryId == id);
    }

    public Category CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }   


    public Category UpdateCategory(Category category)
    {    
        if (category == null)
            throw new ArgumentNullException(nameof(category));
        _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return category;
    }

    public Category DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
            throw new ArgumentNullException(nameof(category));
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return category;
    }
}
