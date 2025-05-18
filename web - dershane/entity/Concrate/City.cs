using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class City
	{
		[Key]
		public int City_Id { get; set; }
		public string? Name { get; set; }
		public List<Adress>? Adresses { get; set; }
	}
}
