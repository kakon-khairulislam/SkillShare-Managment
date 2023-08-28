using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        [Key]
        public int TokenId { get; set; }
        public string TokenKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
