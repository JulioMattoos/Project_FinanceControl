using FinanceCotrol.Context;
using FinanceCotrol.Models;

namespace Project_FinanceControl.Repository;

public class UserRepository : IUserRepository
{
    private readonly FinanceDbContext _context;

    public UserRepository(FinanceDbContext context)
    {
        _context = context;
    }


    public IEnumerable<User> GetAllUsers()
    {
        var users = _context.Users.ToList();
        return users;
    }

    public User GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(c => c.UserId == id);
        if (user == null)
            throw new KeyNotFoundException($"Usuario com id:{id} não encontrado");
        return user;
    }

    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User UpdateUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return user;
    }

    public User DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        _context.Users.Remove(user);
        _context.SaveChanges();
        return user;
    }
}