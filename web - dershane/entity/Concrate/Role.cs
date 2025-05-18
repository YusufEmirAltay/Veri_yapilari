using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Role
	{
		[Key]
		public int Role_Id { get; set; }
		public string? Name { get; set; }
		public bool Status { get; set; }
        public List<Teacher>? Teachers { get; set; }
    }
}
