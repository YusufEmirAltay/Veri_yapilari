using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Parent
	{
        [Key]
        public int Parent_Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long TC { get; set; }
        public DateTime BirthDay { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }  
        public bool Status { get; set; }
        [ForeignKey("Adress")]
        public int Adress_Id { get; set; }
        public Adress? Adress { get; set; }
        public List<Student>? Students { get; set; }
    }
}
