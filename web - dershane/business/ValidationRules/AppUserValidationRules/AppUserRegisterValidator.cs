using dto.dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.ValidationRules.AppUserValidationRules
{
	public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen isminizi giriniz.");
			RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyisminizi giriniz.");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen parola oluşturunuz.");
			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen parolanızı tekrar giriniz.");
			RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Girdiğiniz parolalar eşleşmiyor.");
		}
	}
}
