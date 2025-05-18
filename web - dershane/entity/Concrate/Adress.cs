using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Adress
	{
        [Key]
        public int Adress_Id { get; set; }
        public string? Town { get; set; }   
        public string? Neighbourhood { get; set; }   
        public string? Street { get; set; }
        public int NO { get; set; }
        public int Apartment { get; set; }

		[ForeignKey("City")]
		public int City_Id { get; set; }
		public City? City { get; set; }
		public List<Student>? Students { get; set; }
        public List<Teacher>? Teachers { get; set; }
        public List<Parent>? Parents { get; set; }
    }
}
