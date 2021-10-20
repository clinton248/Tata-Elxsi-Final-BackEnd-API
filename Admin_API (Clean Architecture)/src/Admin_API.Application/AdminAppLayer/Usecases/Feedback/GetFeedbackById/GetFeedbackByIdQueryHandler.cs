using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.GetFeedbackById
{
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, FeedbackDto>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        public GetFeedbackByIdQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;

        }
        public async Task<FeedbackDto> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            string json = JsonConvert.SerializeObject(request);
            Console.WriteLine($"ReqIdjson::{json}");
            var feedbacks = await _feedbackRepository.GetByIdAsync(request.Id);
            return feedbacks;
        }
    }
}
