using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int? User_Id { get; set; }
        public User User { get; set; }
        public int? Quiz_Id { get; set; }
        public Quiz Quiz { get; set; }
    }
}
