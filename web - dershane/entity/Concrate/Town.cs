using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Town
	{
		[Key]
        public int Town_Id { get; set; }
        public string? Name { get; set; }
    }
}
