using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator:AbstractValidator<Contact>
	{
		public ContactValidator() 
		{
			RuleFor(x => x.userMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
			RuleFor(x => x.subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
			RuleFor(x => x.message).NotEmpty().WithMessage("İçerik Boş Geçilemez");
			RuleFor(x => x.userName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
			RuleFor(x => x.subject).MaximumLength(50).WithMessage("50 Karakterden Uzun Girilemez");
		}
	}
}
