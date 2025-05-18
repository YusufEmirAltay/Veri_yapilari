using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Class_Teacher
	{
		[Key]
		public int Class_Teacher_Id { get; set; }
		public DateTime Time { get; set; }
		public bool Status { get; set; }
		[ForeignKey("Teacher")]
		public int Teacher_Id { get; set; }
		public Teacher? Teacher { get; set; }
		[ForeignKey("Class")]
		public int Class_Id { get; set; }
		public Class? Class { get; set; }
	}
}
