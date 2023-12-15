using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.categoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
			RuleFor(x => x.categoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez");
			RuleFor(x => x.categoryName).MaximumLength(20).WithMessage("Kategori Adı 20 Kareterden Fazla Girilemez");

		}
	}
}
