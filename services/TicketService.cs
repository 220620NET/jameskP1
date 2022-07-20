using Models;
using DataAccess;


namespace services{
    public class TicketServices{
        TicketRepository shrub = new TicketRepository();

        public int CreateTicket(Ticket dell){
            int boulder;

            boulder = shrub.CreateTicket(dell);

            return boulder;
            }

        public int UpdateTicket(Ticket wiscon){
            int doorhinge;
            doorhinge = shrub.UpdateTicket(wiscon);
            return doorhinge;

            }

        public Ticket GetTicketsByID(int ID){
            Ticket hallway = new Ticket();
            hallway = shrub.GetTicketsById(ID);
            return hallway;


        }
        public List<Ticket> GetTicketsByAuthor(int authorid){
            List<Ticket> jewel = new List<Ticket>();
            jewel = shrub.GetTicketsByAuthor(authorid);
            return jewel;
    }
        public List<Ticket> GetTicketsByStatus(string status){
            List<Ticket> cellar = new List<Ticket>();
            cellar = shrub.GetTicketsByStatus(status);
            return cellar;       
        }
        public List<Ticket> GetAllTickets(){
            List<Ticket> dinsfire = new List<Ticket>();
            dinsfire = shrub.GetAllTickets();
            return dinsfire;

        }

        
}
}