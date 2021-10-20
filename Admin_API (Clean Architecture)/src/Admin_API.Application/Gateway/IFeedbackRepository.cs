using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Admin_API.Application.DTOs;
using Admin_API.Domain.Entities;
namespace Admin_API.Application.Gateway
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackDto>> GetAsync();
        Task<FeedbackDto> GetByIdAsync(int id);
        Task<FeedbackDto> AddAsync(FeedbackDto feedback);
        Task<FeedbackDto> UpdateAsync(int id, FeedbackDto feedback);
        Task<FeedbackDto> DeleteAsync(int id);


    }
}
