using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Grade
	{
        [Key]
        public int Grade_Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
		public List<Student>? Students { get; set; }
		public List<Lesson>? Lessons { get; set; }
	}
}
