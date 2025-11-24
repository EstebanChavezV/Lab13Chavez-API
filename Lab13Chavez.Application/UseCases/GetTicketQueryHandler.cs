using Lab13Chavez.Domain;
using Lab13Chavez.Domain.Ports;

namespace Lab13Chavez.Application.UseCases; // Usamos UseCases aquí

public class GetTicketQueryHandler
{
    private readonly ITicketRepository _repository;

    // Inyección del Puerto
    public GetTicketQueryHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Ticket> Execute(int ticketId)
    {
        // Lógica de negocio (Caso de Uso)
        if (ticketId <= 0)
            throw new ArgumentException("Ticket ID must be positive.");

        return await _repository.GetTicketByIdAsync(ticketId);
    }
}