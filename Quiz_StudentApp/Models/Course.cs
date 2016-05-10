using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Course
    {
        public Course()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> EducationId { get; set; }
        public virtual Education Education { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
