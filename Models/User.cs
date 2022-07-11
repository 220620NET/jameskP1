namespace Models
{
    public class User
    {
        public string role {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public string ID {get; set;}

        public User (string role, string username, string password, string ID)
        {
            this.role = role;
            this.username = username;
            this.password = password;
            this.ID = ID;
        }
        public User(){}
    }
}