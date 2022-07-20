using Models;

namespace DataAccess;

public interface IUserRepository
{
    List<User> GetAllUsers();

    User GetUserByUsername(string username);

    User GetUserById(int Userid);

    int CreateUser(User newUser);
}
