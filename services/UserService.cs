using Models;
using DataAccess;



namespace services{

    public class UserService{

        UserRepository tree = new UserRepository();
        public User getUserByUsername(String username){
            User ocean = new User();

            ocean = tree.GetUserByUsername(username);

            return ocean;

        }

        public User GetUserById(int ID){
            User wind = new User();

            wind = tree.GetUserById(ID);

            return wind;


        }

        public List<User> GetAllUsers(){
            List<User> ducks = new List<User>();
            ducks = tree.GetAllUsers();

            return ducks;




        }
        public int CreateUser(User use){
            int din = 0;
            din = tree.CreateUser(use);

            return din;

        }

        }

    }
