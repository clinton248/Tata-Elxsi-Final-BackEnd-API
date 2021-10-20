using Admin_API.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_API.Application.AdminAppLayer.Usecases.Feedback.DeleteFeedback
{
    public class DeleteFeedbackCommand: IRequest<FeedbackDto>
    {
        public int Id { get; set; }

    }
}
