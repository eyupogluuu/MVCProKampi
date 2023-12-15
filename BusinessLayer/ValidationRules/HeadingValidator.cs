﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class HeadingValidator:AbstractValidator<Heading>
	{
		public HeadingValidator() 
		{
			RuleFor(x=>x.headingName).NotEmpty().WithMessage("Başlık Adı Boş Geçilemez");
			
		}
	}
}
