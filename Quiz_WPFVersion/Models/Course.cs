using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class Course
    {
        public Course()
        {
            Users = new Collection<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? EducationId { get; set; }
        public Education Education { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
