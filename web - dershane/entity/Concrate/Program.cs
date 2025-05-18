using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Program
	{
		[Key]
		public int Program_Id { get; set; }
		[ForeignKey("Class_Teacher")]
		public int Class_Teacher_Id { get; set; }
		public Class_Teacher? Class_Teacher { get; set; }
		[ForeignKey("Student_Lesson")]
		public int Student_Lesson_Id { get; set; }
		public Student_Lesson? Student_Lesson { get; set; }
	}
}
