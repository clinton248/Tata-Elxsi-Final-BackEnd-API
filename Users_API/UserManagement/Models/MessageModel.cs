using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Authentication;

namespace UserManagement.Models
{
    public class MessageModel
    {
        [Key]
        public int MsgId { get; set; }
        public string MsgFrom { get; set; }
        public string MsgTo { get; set; }
        public string MsgText { get; set; }
        public string Time { get; set; }
        

    }
}
