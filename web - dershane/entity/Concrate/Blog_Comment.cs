using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Blog_Comment
	{
		[Key]
		public int Blog_Comment_Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Comment { get; set; }
		public bool Status { get; set; }
		[ForeignKey("Blog_Post")]
		public int Blog_Post_Id { get; set; }
		public Blog_Post? Blog_Post { get; set; }
	}
}
