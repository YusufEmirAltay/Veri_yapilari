using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Course
	{
		[Key]
		public int Course_Id { get; set; }
		public string? Name { get; set; }
		public bool Status { get; set; }
        public List<Lesson>? Lessons { get; set; }
    }
}
