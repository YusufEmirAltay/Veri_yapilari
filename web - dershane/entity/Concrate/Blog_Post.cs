using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Blog_Post
	{
        [Key]
        public int Blog_Post_Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Article { get; set; }
        public string? PhotoURL { get; set; }
        public bool Status { get; set; }
        public List<Blog_Comment>? Blog_Comments { get; set; }
    }
}
