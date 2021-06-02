using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Description).Length(0, 10);
			RuleFor(x => x.DailyPrice).GreaterThan(5);
		}
	}
}
