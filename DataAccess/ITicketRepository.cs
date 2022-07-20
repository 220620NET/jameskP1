using Models;

namespace DataAccess;

public interface ITicketRepository
{
    List<Ticket> GetAllTickets();

    List<Ticket>  GetTicketsByAuthor(int authorID);

    Ticket GetTicketsById(int ID);

    List<Ticket> GetTicketsByStatus(String status);

    int CreateTicket(Ticket gelapi);

    int UpdateTicket(Ticket jilli);
}
