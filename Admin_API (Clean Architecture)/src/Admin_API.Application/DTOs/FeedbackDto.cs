using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin_API.Application.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Feedback { get; set; }
        public DateTime Date { get; set; }

        #nullable enable
        public string? Reply { get; set; }
        public DateTime? ReplyDate { get; set; }

        //public static explicit operator Task<object>(FeedbackDto v)
        //{
        //    return (Task<object>)v;
        //}
    }
}
