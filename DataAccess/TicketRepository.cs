using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using CustomExceptions;


namespace DataAccess{
    public class TicketRepository: ITicketRepository{
            string ConnectionString = 
        public List<Ticket> GetAllTickets() {
            string sql = "select * from foundationproject.tickets;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            List<Ticket> tickets = new List<Ticket>();
            try{
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tickets.Add(new Ticket((int)(reader[0]), (int)reader[1], (int)reader[2], (string)reader[3], (string)reader[4], (double)reader[5] ));
                }
                reader.Close();
                connection.Close();
            }catch(Exception e) {
                Console.WriteLine(e.Message);
                return new List<Ticket>();
            }
            return tickets;
            }
    public List<Ticket> GetTicketsByAuthor(int authorid){
            string sql = "select * from foundationproject.tickets where authorid = @a;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@a", authorid);
            List<Ticket> tickets = new List<Ticket>();
            Ticket plains = new Ticket();
            try{
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    plains = (new Ticket((int)(reader[0]), (int)(reader[1]), (int)(reader[1]), (string)reader[3], (string)reader[4], (double)reader[5] ));
                    tickets.Add(plains);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return new List<Ticket>();
            }
            return tickets;
            }
        public Ticket GetTicketsById(int ID){
            string sql = "select * from foundationproject.tickets where ID = @a;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@a", ID);
            Ticket desert = new Ticket();
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()){     
                    desert = (new Ticket((int)(reader[0]), (int)reader[1], (int)reader[2], (string)reader[3], (string)reader[4], (double)reader[5] )); 
                                
                }
                
                reader.Close();
                connection.Close();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return new Ticket();
            }
            return desert;
            }
        public List<Ticket> GetTicketsByStatus(string current) {
            string sql = "select * from foundationproject.tickets where status = @a;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@a", current);
            List<Ticket> tickets = new List<Ticket>();
            Ticket valley = new Ticket();
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()){                   
                    valley = (new Ticket((int)(reader[0]), (int)reader[1], (int)reader[2], (string)reader[3], (string)reader[4], (double)reader[5] ));  
                    tickets.Add(valley);
                    
                }
                reader.Close();
                connection.Close();
            }
        
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return new List<Ticket>();
            }
            return tickets;
            }
        public int CreateTicket(Ticket newTicket)
        {
            string sql= "insert into foundationproject.tickets(authorID, description, resolverid, status, amount) values(@e, @f, @x, @g, @h);";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@e", newTicket.authorid);
            command.Parameters.AddWithValue("@f", newTicket.reason);
            command.Parameters.AddWithValue("@x", newTicket.resolverid);
            command.Parameters.AddWithValue("@g", newTicket.status);
            command.Parameters.AddWithValue("@h", newTicket.amount);
            try{
                connection.Open();
                int sea = command.ExecuteNonQuery();
                connection.Close();

                return sea;
                
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return -1;
            }
        public int UpdateTicket(Ticket update)
        {
            string sql = "update foundationproject.tickets set resolverid =@a, description  =@b, status =@c where id = @d;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@d", update.ID);
            command.Parameters.AddWithValue("@a", update.resolverid);
            command.Parameters.AddWithValue("@b", update.reason);
            command.Parameters.AddWithValue("@c", update.status);
            try{
                connection.Open();
                int k2 = command.ExecuteNonQuery();
                connection.Close();
                return k2;
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            return -1;
            }       
    }
}

