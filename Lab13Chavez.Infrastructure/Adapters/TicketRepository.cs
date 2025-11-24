using Lab13Chavez.Domain;
using Lab13Chavez.Domain.Ports;

namespace Lab13Chavez.Infrastructure.Adapters;

public class TicketRepository : ITicketRepository
{
    public async Task<Ticket> GetTicketByIdAsync(int ticketId)
    {
        // Adaptador (Simulación de DB)
        return await Task.FromResult(new Ticket
        {
            Id = ticketId,
            Title = $"Simulated Ticket {ticketId}",
            Status = "Resolved by Infrastructure"
        });
    }
}