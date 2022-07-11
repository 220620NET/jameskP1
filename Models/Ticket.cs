namespace Models{

    public class Ticket
    {


            public string ID {get; set;}
            public string author {get; set;}
            public string resolver {get; set;}
            public string description {get; set;}
            public string status {get; set;}
            public double amount {get; set;}


        public Ticket(string ID, string author, string resolver, string description, string status, double amount)
        {
            this.ID = ID;
            this.author = author;
            this.resolver = resolver;
            this.description = description;
            this.status = status;
            this.amount = amount;
        }
        public Ticket(){}
    }
}