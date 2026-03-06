using FinanceCotrol.Models;

namespace Project_FinanceControl.Repository;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();

    User GetUserById(int id);

    User CreateUser(User user);

    User UpdateUser(User user);

    User DeleteUser(int id);
}