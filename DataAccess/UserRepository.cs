using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using CustomExceptions;
using System.Data;

namespace DataAccess{

    public class UserRepository : IUserRepository {

            string ConnectionString = 

            public List<User> GetAllUsers(){
                string sql = "select * from foundationproject.users;";
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                List<User> users = new List<User>();        
                try{
            
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    users.Add(new User((string)(reader[3]), (string)reader[1], (string)reader[2], (int)reader[0]));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e){
            
                Console.WriteLine(e.Message);
                return new List<User>();
            }
            return users;
        }
            

            public User GetUserById(int userId)
        {
            string sql = "select * from foundationproject.users where ID = @x";           
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@x", userId);
            User beach = new User();          
            try{
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    beach = new User((string)(reader[3]), (string)reader[1], (string)reader[2], (int)reader[0]);
                }
                reader.Close();
                connection.Close();
            }
            catch (ResourceNotFound){
                throw new ResourceNotFound();
            }
            return beach;
        }


        
            public int CreateUser(User newUser){
            string sql = "insert into foundationproject.users(username,password, roles) values (@a, @b, @c);";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@a", newUser.username);
            command.Parameters.AddWithValue("@b", newUser.password);
            command.Parameters.AddWithValue("@c", newUser.role);
            try {
                connection.Open();
                int forest = command.ExecuteNonQuery();
                connection.Close();
                
                return forest;
            }
            catch (UsernameNotAvailable e)
            {
                Console.WriteLine(e.Message);
            }
            return -1;
        }

            public User GetUserByUsername(string username)
        {
            string sql = "select * from foundationproject.users where username = @a;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@a", username);
            User hills = new User();
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    hills = new User((string)(reader[3]), (string)reader[1], (string)reader[2], (int)reader[0]);            
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return new User();
            }
            return hills;
        }

    }


    
}








