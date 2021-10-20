using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Admin_API.Application.AdminAppLayer;
using Admin_API.Application.AdminAppLayer.Usecases.Feedback.CreateFeedback;
using Admin_API.Application.Gateway;
using Admin_API.Domain.Entities;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Admin_API.Application.DTOs;
using System.Net.Http;

namespace Admin_API.Infrastructure.FeedbackRepository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDbContext _dbContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ProfanityFilter _profanity =new ProfanityFilter();
        public FeedbackRepository(FeedbackDbContext feedbackDbContext)
        {
            _dbContext = feedbackDbContext;
        }
        public async Task<FeedbackDto> AddAsync(FeedbackDto feedback)
        {
            Console.WriteLine($"Feedback::::{feedback}");
            var profanity = _profanity.OnPost(feedback.Feedback);
            string json = JsonConvert.SerializeObject(profanity.Result);
            Console.WriteLine($"profanityTodb::::{json}");
            //var objResponse1 = JsonConvert.DeserializeObject<FeedbackDto>(json);
            var command = await _dbContext.feedbackEntity.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();

            //return CreatedAtAction("GetByIdAsync", new { id = feedback.Id }, feedback);
            return feedback;

        }

        public async Task<FeedbackDto> DeleteAsync(int id)
        {
            var deleteFeedback = await _dbContext.feedbackEntity.FindAsync(id);
            if (deleteFeedback != null)
            {
                _dbContext.feedbackEntity.Remove(deleteFeedback);
                await _dbContext.SaveChangesAsync();
            }

            return deleteFeedback;
        }

        public async Task<IEnumerable<FeedbackDto>> GetAsync()
        {
            var res = new FeedbackDto();
            var feedbacks = await _dbContext.feedbackEntity.ToListAsync<FeedbackDto>();
            //string json = JsonConvert.SerializeObject(feedbacks);
            //var objResponse1 = JsonConvert.DeserializeObject<FeedbackDto>(json);

            Console.WriteLine($"objResponse11:::: {feedbacks}");
            //var serializer = JsonConvert.DeserializeObject<FeedbackDto>(json);
            //List<FeedbackDto> res = serializer.Deserialize<List<FeedbackDto>>(json);
            //IEnumerable<FeedbackDto> result = JsonConvert.DeserializeObject<IEnumerable<FeedbackDto>>(json);

            return feedbacks;


            //var res = new FeedbackDto
            //{
            //    Id = json.
            //};
            //var res = new FeedbackDto
            //{
            //    Id = feedbacks.Id,
            //    UserName = feedbacks.UserName,
            //    Feedback = feedbacks.Feedback,
            //    Date = feedbacks.Date,

            //};
        }

        public async Task<FeedbackDto> GetByIdAsync(int id)
        {
            var feedback = await _dbContext.feedbackEntity.FindAsync(id);
            return feedback;
        }

        public async Task<FeedbackDto> UpdateAsync(int id, FeedbackDto feedback)
        {
            //var updateFeedback = await _dbContext.feedbackEntity.Update(feedback);
            string json = JsonConvert.SerializeObject(feedback);
            Console.WriteLine($"Update::: {json}");
            _dbContext.Entry(feedback).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return feedback;

        }
    }
}
