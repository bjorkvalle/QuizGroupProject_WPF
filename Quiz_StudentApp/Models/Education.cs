using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quiz_StudentApp.Models
{
    public partial class Education
    {
        public Education()
        {
            this.Courses = new Collection<Course>();
            this.Users = new Collection<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
