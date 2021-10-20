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

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.CreateFeedback
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, DTOs.FeedbackDto>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
        public async Task<DTOs.FeedbackDto> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            //FeedbackEntity feedback = new FeedbackEntity();
            //feedback.Id = 1;
            //feedback.UserName = "Sreehari";
            //feedback.Feedback = "Good app..!";
            //feedback.Date = new DateTime(2021, 10, 10);
            //string json = JsonConvert.SerializeObject(request);
            var feedback = _mapper.Map<FeedbackDto>(request);
            

            var result = await _feedbackRepository.AddAsync(feedback);
            Console.WriteLine($"Logging::{feedback}");

            //var response = new DTOs.FeedbackDto {
            //    Id = result.Id,
            //    UserName = result.UserName,
            //    Feedback = result.Feedback,
            //    Date = result.Date
            //};

            return feedback;
        }
    }
}
