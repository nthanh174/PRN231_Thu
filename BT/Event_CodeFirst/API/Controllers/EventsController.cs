using AutoMapper;
using Event_CodeFirst.DTO;
using Event_CodeFirst.Models;
using Event_CodeFirst.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventRepository _eventRepository = new EventRepository();
        private IMapper mapper;

        public EventsController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _eventRepository.GetAll();
            var eventDTO = mapper.Map<List<Event>>(events);
            return Ok(eventDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var eventEntity = _eventRepository.Get(id);

            if (eventEntity == null)
            {
                return NotFound();
            }
            var eventDTO = mapper.Map<Event>(eventEntity);

            return Ok(eventDTO);
        }

        [HttpPost]
        public IActionResult PostEvent(EventDTO eventEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var evt = mapper.Map<Event>(eventEntity);
                _eventRepository.Insert(evt);
                return Created(Request.GetDisplayUrl(), eventEntity);
            }
            catch
            {
                return Conflict("Have error!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, EventDTO eventEntity)
        {
            if (id != eventEntity.EventId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var evt = mapper.Map<Event>(eventEntity);
                evt.EventId = eventEntity.EventId;
                _eventRepository.Update(evt);
                return NoContent();
            }
            catch
            {
                if (_eventRepository.Get(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    return Conflict("Have error!");
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var eventEntity = _eventRepository.Get(id);

            if (eventEntity == null)
            {
                return NotFound();
            }

            try
            {
                _eventRepository.Delete(eventEntity);
                return NoContent();
            }
            catch
            {
                return Conflict("Have error!");
            }
        }
    }
}
