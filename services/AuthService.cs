using Models;
using DataAccess;
using CustomExceptions;


namespace services{
    public class AuthService{

    public User Login (User grass){
        UserRepository rocks = new UserRepository();
        User snow = new User();
        snow = rocks.GetUserByUsername(grass.username);
        
        try{
        if(grass.username.Equals(snow.username) && grass.password.Equals(snow.password)){

        return snow;

        }
        }
        catch(InvalidCredentials i){
            return null;
        }

        return null;
    }

    public User register(User dirt){
        try{
        UserRepository hail = new UserRepository();
        hail.CreateUser(dirt);

        return dirt;
        }
        catch(InvalidCredentials i){
            return null;
        }
        return null;
    }


    }

}