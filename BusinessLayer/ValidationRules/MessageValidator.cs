using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class MessageValidator:AbstractValidator<Message>
	{
		public MessageValidator() 
		{
			RuleFor(x => x.receiverMail).NotEmpty().WithMessage("Alıcı Maili Boş Geçilemez");
			RuleFor(x => x.subject).NotEmpty().WithMessage("Konu Başlığı Boş Geçilemez");
			RuleFor(x => x.messageContent).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez");
			RuleFor(x => x.subject).MaximumLength(40).WithMessage("Konu 40 Karakterden Fazla Girilemez");
		}
	}
}
