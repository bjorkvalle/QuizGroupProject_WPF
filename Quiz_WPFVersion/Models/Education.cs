using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz_WPFVersion.Models
{
    //En klass med elever
    public class Education
    {
        public Education()
        {
            this.Users = new Collection<User>();
            this.Courses = new Collection<Course>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
