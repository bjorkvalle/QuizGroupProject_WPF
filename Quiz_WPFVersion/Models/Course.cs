using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
        public Education EducationId { get; set; }
    }
}
