using Gestevent.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gestevent.Core.Repositories;
using System;

namespace Gestevent.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventsRepository;
        public EventsController(IEventsRepository events)
        {
            _eventsRepository = events;
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> Post([FromBody] EventModel aEvent)
        {
            try
            {
                await _eventsRepository.Add(aEvent);
                return Ok(aEvent);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<EventModel>> Get()
        {
            try
            {
                var events = await _eventsRepository.GetAll();
                return Ok(events);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> Get(Guid id)
        {
            try
            {
                var aEvent = await _eventsRepository.Get(id);
                return aEvent is null ? NotFound() : Ok(aEvent);
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
                var wasDeletes = await _eventsRepository.Delete(id);
                return wasDeletes ? NoContent() : NotFound();
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }
    }
}
