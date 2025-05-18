using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dto.dtos.AppUserDtos
{
	public class AppUserEditDto
	{
		//ad,soyad,e-posta,parola
		public int Id { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? ConfirmPassword { get; set; }
	}
}
