using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.writerName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
			RuleFor(x => x.writerSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
			RuleFor(x => x.writerTittle).MaximumLength(20).WithMessage("Yazar Etiketi 20 Kareterden Fazla Girilemez");

		}
	}
}
