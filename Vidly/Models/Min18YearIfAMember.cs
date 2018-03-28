using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Min18YearIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;

			if (customer.MembershipTypeId == (byte)MembershipType.unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;

			if (customer.Birthdate == null)
				return new ValidationResult("生日是必须的!");

			var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

			return (age > 18) ? ValidationResult.Success : new ValidationResult("年龄必须大于18岁!");
		}
	}
}