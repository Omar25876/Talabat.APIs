﻿using System.ComponentModel.DataAnnotations;

namespace Talabat.APIs.DTOs
{
	public class AddrssDto
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public string Street { get; set; }
	}
}
