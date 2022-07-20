
using services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;
public class Usercontroller
{
    private readonly UserService _service;
    public Usercontroller(UserService service)
    {
        _service = service;
    }

    public List<User> GetAllUsers()
    {
        return _service.GetAllUsers();
    }

    public User GetUserById(int userID){

        return _service.GetUserById(userID);
    }

    public int CreateUser(User joe){

        return _service.CreateUser(joe);

    }



}