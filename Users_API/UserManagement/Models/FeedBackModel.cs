using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("TblFeedBack")]
    public class FeedBackModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "FeedBack Can't Empty")]
        public string Comments { get; set; }
        public int Rate { get; set; }
    }
}
