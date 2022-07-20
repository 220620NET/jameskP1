
using services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;
public class Ticketcontroller{

private readonly TicketServices _service;

    public Ticketcontroller(TicketServices service)
    {
        _service = service;
    }

    public List<Ticket> GetAllTickets(){
        return _service.GetAllTickets();


    }

    public List<Ticket> GetTicketsByAuthor(int authorID){
        return _service.GetTicketsByAuthor(authorID);



    }

    public Ticket GetTicketsByID(int ID){
        return _service.GetTicketsByID(ID);



    }


    public List<Ticket> GetTicketsByStatus(string status){

        return _service.GetTicketsByStatus(status);
    }

    public int CreateTicket(Ticket zeld){

        return _service.CreateTicket(zeld);
    }

    public int UpdateTicket(Ticket zeld){

        return _service.UpdateTicket(zeld);

}
}