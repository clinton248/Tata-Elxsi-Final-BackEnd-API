using Admin_API.Application.AdminAppLayer.Usecases.Feedback.CreateFeedback;
using Admin_API.Application.AdminAppLayer.Usecases.Feedback.UpdateFeedback;
using Admin_API.Application.DTOs;
using Admin_API.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.Helpers
{
    class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<DTOs.FeedbackDto, CreateFeedbackCommand>().ReverseMap();
            CreateMap<DTOs.FeedbackDto, DTOs.FeedbackDto>().ReverseMap();
            CreateMap<IEnumerable<DTOs.FeedbackDto>, DTOs.FeedbackDto>().ReverseMap();
            CreateMap<UpdateFeedbackCommand, DTOs.FeedbackDto>().ReverseMap();



        }
    }
}
