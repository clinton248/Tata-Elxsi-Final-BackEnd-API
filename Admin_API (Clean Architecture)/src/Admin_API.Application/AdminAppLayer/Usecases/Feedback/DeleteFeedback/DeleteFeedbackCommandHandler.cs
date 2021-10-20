using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.DeleteFeedback
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, FeedbackDto>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task<FeedbackDto> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var deleteFeedback = await _feedbackRepository.DeleteAsync(request.Id);
            Console.WriteLine($"FeedbackInHandler::{deleteFeedback}");
            return deleteFeedback;
        }
    }
}
