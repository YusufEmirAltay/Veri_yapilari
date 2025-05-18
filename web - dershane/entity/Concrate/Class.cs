using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Class
	{
		[Key]
		public int Class_Id { get; set; }
		public int Number { get; set; }
		public string? Branch { get; set; }
		public bool Status { get; set; }
		public List<Student>? Students { get; set; }
		public List<Schedule>? Schedules { get; set; }
	}
}
