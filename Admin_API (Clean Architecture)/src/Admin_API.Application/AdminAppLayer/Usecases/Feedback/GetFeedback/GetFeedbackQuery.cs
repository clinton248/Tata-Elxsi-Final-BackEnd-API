using Admin_API.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.GetFeedback
{
    public class GetFeedbackQuery : IRequest<IEnumerable<FeedbackDto>>
    {
        //public int Id { get; set; } 
    }
}
