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
    public class FeedbacksController : ControllerBase
    {
        private IFeedbackRepository _feedbackRepository = new FeedbackRepository();
        private IMapper mapper;

        public FeedbacksController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeedbacks()
        {
            var feedbacks = _feedbackRepository.GetAll();
            var feedbackDTO = mapper.Map<List<Feedback>>(feedbacks);
            return Ok(feedbackDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeedback(int id)
        {
            var feedback = _feedbackRepository.Get(id);

            if (feedback == null)
            {
                return NotFound();
            }
            var feedbackDTO = mapper.Map<Feedback>(feedback);
            return Ok(feedbackDTO);
        }

        [HttpPost]
        public IActionResult PostFeedback(FeedbackDTO feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var fb = mapper.Map<Feedback>(feedback);
                _feedbackRepository.Insert(fb);
                return Created(Request.GetDisplayUrl(), feedback);
            }
            catch
            {
                return Conflict("Have error!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutFeedback(int id, FeedbackDTO feedback)
        {
            if (id != feedback.FId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var fb = mapper.Map<Feedback>(feedback);
                fb.FId = feedback.FId;
                _feedbackRepository.Update(fb);
                return NoContent();
            }
            catch
            {
                if (_feedbackRepository.Get(id) == null)
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
        public IActionResult DeleteFeedback(int id)
        {
            var feedback = _feedbackRepository.Get(id);

            if (feedback == null)
            {
                return NotFound();
            }

            try
            {
                _feedbackRepository.Delete(feedback);
                return NoContent();
            }
            catch
            {
                return Conflict("Have error!");
            }
        }
    }
}
