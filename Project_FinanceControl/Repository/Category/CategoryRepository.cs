using FinanceCotrol.Context;
using FinanceCotrol.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Project_FinanceControl.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly FinanceDbContext _context;

    public CategoryRepository(FinanceDbContext context)
    {
        _context = context; 
    }

    public IEnumerable<Category> GetCategories()
    {
        var category = _context.Categories.ToList();
        if (category == null)
            throw new KeyNotFoundException("Categorias não encontradas");
        return category;
    }

    public Category GetCategoryById(int id)
    {
        var categories = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (categories == null)
            throw new KeyNotFoundException($"Categoria com id:{id} não localizada...");
        return categories;
    }


    public Category CreateCategory(Category category)
    {
        if (category == null)
            throw new ArgumentException(nameof(category), "Erro ao criar categoria");
        return category;
    }

    public Category UpdateCategory(Category category)
    {
        if (category == null)
            throw new ArgumentException(nameof(category));
        _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return category;

    }

    public Category DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if(category == null)
            throw new KeyNotFoundException(nameof(category));
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return(category);
    }



}
