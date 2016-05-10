using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_StudentApp.Models
{
    public partial class Course
    {
        public Course()
        {
            this.Users = new Collection<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int? EducationId { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
