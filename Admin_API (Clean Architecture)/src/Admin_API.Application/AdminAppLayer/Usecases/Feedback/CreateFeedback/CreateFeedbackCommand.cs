using Admin_API.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.CreateFeedback
{
    public class CreateFeedbackCommand : IRequest<FeedbackDto>
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Feedback { get; set; }
        public DateTime Date { get; set; }

#nullable enable
        public string? Reply { get; set; }
        public DateTime? ReplyDate { get; set; }
    }
}
