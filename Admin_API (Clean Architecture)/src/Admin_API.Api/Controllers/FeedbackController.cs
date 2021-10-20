using Admin_API.Application.AdminAppLayer.Usecases.Feedback.CreateFeedback;
using Admin_API.Domain.Entities;
using Admin_API.Infrastructure.FeedbackRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Admin_API.Application.AdminAppLayer.Usecases.Feedback.GetFeedback;
using Admin_API.Application.AdminAppLayer.Usecases.Feedback.GetFeedbackById;
using Admin_API.Application.AdminAppLayer.Usecases.Feedback.DeleteFeedback;
using Admin_API.Application.AdminAppLayer.Usecases.Feedback.UpdateFeedback;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace Admin_API.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackDbContext _context;
        private readonly FeedbackRepository _feedbackRepository;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private readonly ProfanityFilter _profanity = new ProfanityFilter();

        public FeedbackController(FeedbackDbContext feedbackDbContext, IMediator mediator)
        {
            _context = feedbackDbContext;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackCommand command)
        {
            var profanity = await _profanity.OnPost(command.Feedback);
            //if (command.Reply != null)
            //{
            //    var profanity_reply = await _profanity.OnPost(command.Reply);
            //    isBadReply = JObject.Parse(profanity_reply)["is-bad"].ToString();
            //    string profinedReply = JObject.Parse(profanity_reply)["censored-content"].ToString();
            //    badWordsReply = JObject.Parse(profanity_reply)["bad-words-list"].ToString().Replace(System.Environment.NewLine, string.Empty);
            //}
            var isBad = JObject.Parse(profanity)["is-bad"].ToString();
            string profinedFeedback = JObject.Parse(profanity)["censored-content"].ToString();
            string badWords = JObject.Parse(profanity)["bad-words-list"].ToString().Replace(System.Environment.NewLine, string.Empty);



            
            //Console.WriteLine($"Feedback::::{profanity}");
            //Console.WriteLine($"badWordsList::::{badWords}");
            //Console.WriteLine($"isBad::::{isBad}");

            if (isBad == "True")
            {
                var message = new { Status = "Error", Message = "Please dont use abusive language.", badWords = badWords };
                return BadRequest(message);
            }
            //else if (isBadReply == "True")
            //{
            //    var message = new { Status = "Error", Message = "Please dont use abusive language.", badWords = badWordsReply };

            //    return BadRequest(message);
            //}
            else
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction("GetFeedback", new { id = result.Id }, result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedback()
        {

            var query = new GetFeedbackQuery();
            var data = await _mediator.Send(query);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {

            var query = new GetFeedbackByIdQuery(){Id=id};
            var data = await _mediator.Send(query);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var command = new DeleteFeedbackCommand() { Id = id};
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(new  { Status = "Success", Message = "Feedback deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] UpdateFeedbackCommand command)
        {
            var profanity = await _profanity.OnPost(command.Feedback);
            var isBad = JObject.Parse(profanity)["is-bad"].ToString();
            string profinedFeedback = JObject.Parse(profanity)["censored-content"].ToString();
            string badWords = JObject.Parse(profanity)["bad-words-list"].ToString().Replace(System.Environment.NewLine, string.Empty);

            if (id != command.Id)
            {
                return BadRequest();
            }

            if (isBad == "True")
            {
                var message = new { Status = "Error", Message = "Please dont use abusive language.", badWords = badWords };
                return BadRequest(message);
            }

            var updateFeedback = await _mediator.Send(command);
            return Ok(new { Status = "Success", Message = "Feedback Updated" });
        }
    }
}
