using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class QuizPayload
    {
        public int Id { get; set; }
        public bool SentToAdmin { get; set; }
        public bool SentToStudent { get; set; }
        public Quiz QuizId { get; set; }
        public User UserId { get; set; }
    }
}
