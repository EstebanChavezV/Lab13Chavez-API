using Lab13Chavez.Domain;

namespace Lab13Chavez.Domain.Ports;

public interface ITicketRepository
{
    Task<Ticket> GetTicketByIdAsync(int ticketId);
}