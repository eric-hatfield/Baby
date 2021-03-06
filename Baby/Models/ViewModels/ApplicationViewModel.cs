﻿using System;
using System.ComponentModel.DataAnnotations;


namespace Baby.Models.ViewModels
{
	public class ApplicationViewModel
	{
		[Required]
		public string OrganizationName { get; set; }

		[Required]
		[Display( Name = "Organization Identification #" )]
		public string OfficialOrganizationId { get; set; }

		[Required]
		[EmailAddress]
		[Display( Name = "Email" )]
		public string Email { get; set; }

		[Display( Name = "Country Code" )]
		public string CountryCode { get; set; }

		[Required]
		[Display( Name = "Phone Number" )]
		public string PhoneNumber { get; set; }

		[Display( Name = "Street Address" )]
		public string StreetAddress { get; set; }

		[Required]
		[Display( Name = "City" )]
		public string City { get; set; }

		[Display( Name = "State or Province" )]
		public string StateOrProvince { get; set; }

		[Display( Name = "Postal Code" )]
		public string PostalCode { get; set; }

		[Required]
		[Display( Name = "Country" )]
		public Guid CountryId { get; set; }
	}
}
