using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.UpdateFeedback
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, FeedbackDto>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public readonly IMapper _mapper;
        public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
        public async Task<FeedbackDto> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var updateFeedback = _mapper.Map<FeedbackDto>(request);
            var feedbacks = await _feedbackRepository.UpdateAsync(request.Id, updateFeedback);
            Console.WriteLine($"FeedbackInHandler::{feedbacks}");
            return feedbacks;
        }
    }
}
