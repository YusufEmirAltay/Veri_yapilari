using entity;
using entity.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Concrate
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=ELITEBOOK\\MSSQLSERVER2012;database=DershaneDB;integrated security=true;TrustServerCertificate=True;");
		}
		public DbSet<Blog>? Blogs { get; set; }
		public DbSet<Comment>? Comments { get; set; }
		public DbSet<Contact>? Contacts { get; set; }
		public DbSet<Subscribe>? Subscribes { get; set; }
		public DbSet<Testimonial>? Testimonials { get; set; }
        public DbSet<Adress>? Adresses { get; set; }
        public DbSet<Class>? Classes { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Parent>? Parents { get; set; }
        public DbSet<Schedule>? Schedules { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<City>? Cities { get; set; }
    }
}
