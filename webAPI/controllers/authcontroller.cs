using services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;
public class AuthController
{
    private readonly AuthService _service;
    public AuthController(AuthService service)
    {
        _service = service;
    }

    public IResult Register(User usertoregister)
    {
      if(usertoregister.username == null)
      {
        return Results.BadRequest("Username is null");
      }
      try
      {
        _service.register(usertoregister);
        return Results.Created("/register", usertoregister);

      }
      catch(DuplicateWaitObjectException)
      {
        return Results.Conflict("User already exists");
      }
    }
}