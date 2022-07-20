namespace Models
{
    public class User
    {
        public string role {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public int ID {get; set;}

        public User (string role, string username, string password, int ID)
        {
            this.role = role;
            this.username = username;
            this.password = password;
            this.ID = ID;
        }
        public User(){}
    }
}