using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    //En klass med elever
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
