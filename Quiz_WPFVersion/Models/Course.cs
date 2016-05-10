using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_WPFVersion.Models
{
    public class Course
    {
        public Course()
        {
            this.Users = new Collection<User>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? EducationId { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
