using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="姓名是必须的!")]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubscribedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		[Display(Name="MembershipType")]
		public byte? MembershipTypeId { get; set; }

		[Min18YearIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}