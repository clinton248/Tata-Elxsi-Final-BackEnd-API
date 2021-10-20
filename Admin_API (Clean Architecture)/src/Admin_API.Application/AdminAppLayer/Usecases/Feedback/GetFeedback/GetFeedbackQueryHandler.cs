using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using Admin_API.Domain.Entities;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.GetFeedback
{
    public class GetFeedbackQueryHandler : IRequestHandler<GetFeedbackQuery, IEnumerable<DTOs.FeedbackDto>>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public GetFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<DTOs.FeedbackDto>> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackRepository.GetAsync();
            Console.WriteLine($"FeedbackInHandler::{feedbacks}");
            return feedbacks;
        }
    }
}
