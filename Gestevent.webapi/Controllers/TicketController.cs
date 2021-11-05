using Gestevent.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gestevent.Core.Repositories;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Gestevent.webapi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketsRepository _ticketsRepository;
        private readonly IEventsRepository _eventRepository;
        public TicketController(ITicketsRepository tickets, IEventsRepository events)
        {
            _ticketsRepository = tickets;
            _eventRepository = events;
        }

        [HttpPost]
        public async Task<ActionResult<TicketModel>> Post([FromBody] CreateTicketCommand command)
        {
            try
            {
                var aEvent = await _eventRepository.Get(command.EventId);
                if (aEvent is null)
                {
                    return Problem($"Cannot find a event with id {command.EventId}", statusCode: 400);
                }
                
                var aTicket = new TicketModel() 
                {
                    EventId = command.EventId,
                    Price = command.Price,
                    WasSold = false,
                };
                
                await _ticketsRepository.Add(aTicket);
                return Ok(aTicket);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<TicketModel>> Get()
        {
            try
            {
                var ticket = await _ticketsRepository.GetAll();
                return Ok(ticket);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketModel>> Get(Guid id)
        {
            try
            {
                var aTicket = await _ticketsRepository.Get(id);
                return aTicket is null ? NotFound() : Ok(aTicket);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var wasDeletes = await _ticketsRepository.Delete(id);
                return wasDeletes ? NoContent() : NotFound();
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

    }
}
