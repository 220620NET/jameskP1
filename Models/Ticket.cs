namespace Models{

    public class Ticket
    {


            public int ID {get; set;}
            public int authorid {get; set;}
            public int resolverid {get; set;}
            public string reason {get; set;}
            public string status {get; set;}
            public double amount {get; set;}


        public Ticket(int ID, int authorid, int resolveid, string reason, string status, double amount)
        {
            this.ID = ID;
            this.authorid = authorid;
            this.resolverid = resolveid;
            this.reason = reason;
            this.status = status;
            this.amount = amount;
        }
        public Ticket(){}
    }
}