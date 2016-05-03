using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Education
    {
        public Education()
        {
            this.Courses = new List<Course>();
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
