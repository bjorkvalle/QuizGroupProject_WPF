using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public User UserId { get; set; }
        public Quiz QuizId { get; set; }
    }
}
