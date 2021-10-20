using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    public class NotificationModel
    {
        [Key]
        public int id { get; set; }
        public int count { get; set; }
        public string Notification_Message { get; set; }
        public DateTime Date { get; set; }
        //public int Enp_Id { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
    }
}
