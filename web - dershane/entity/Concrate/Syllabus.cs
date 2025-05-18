using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Syllabus
	{
		[Key]
        public int Syllabus_Id { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("Class")]
        public int Class_Id { get; set; }
        public Class? Class { get; set; }
    }
}
