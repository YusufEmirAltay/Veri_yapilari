using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Student_Lesson
	{
        [Key]
        public int Student_Lesson_Id { get; set; }
        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Lesson")]
        public int Lesson_Id { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
