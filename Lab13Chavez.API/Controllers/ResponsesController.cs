using Lab13Chavez.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

// Referencia al nuevo namespace

namespace Lab13Chavez.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponsesController : ControllerBase
{
    private readonly GetTicketQueryHandler _handler;

    // Inyección del Caso de Uso
    public ResponsesController(GetTicketQueryHandler handler)
    {
        _handler = handler;
    }

    [HttpGet("ticket/{ticketId}")]
    public async Task<IActionResult> GetTicket(int ticketId)
    {
        try
        {
            var ticket = await _handler.Execute(ticketId);
            return Ok(ticket);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}