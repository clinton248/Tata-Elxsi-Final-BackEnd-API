using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Admin_API.Domain.Entities
{
    public class FeedbackEntity
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Feedback { get; set; }
        public DateTime Date { get; set; }

#nullable enable
        public string? Reply { get; set; }
        public DateTime? ReplyDate { get; set; }

        //public static implicit operator FeedbackDto(List<FeedbackDto> v)
        //{
        //    return v;
        //}
    }
}
