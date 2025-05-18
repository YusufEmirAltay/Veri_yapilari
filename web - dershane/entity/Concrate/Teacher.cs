using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Teacher
	{
        [Key]
        public int Teacher_Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long TC { get; set; }
        public DateTime BirthDay { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }
        public string? PreBio { get; set; }
        public string? DetailBio { get; set; }
		public string? PhotoURL { get; set; }
		public bool Status { get; set; }
        [ForeignKey("Lesson")]
        public int Lesson_Id { get; set; }
        public Lesson? Lesson { get; set; }
		[ForeignKey("Adress")]
		public int Adress_Id { get; set; }
		public Adress? Adress { get; set; }
		public List<Schedule>? Schedules { get; set; }
    }
}
