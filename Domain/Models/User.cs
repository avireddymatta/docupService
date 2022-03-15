using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public string BloodGroup { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        // UserName
        // NormalizedUserName
        // Email
        // NormalizedEmail
        // EmailConfirmed
        // PasswordHash
        // SecurityStamp
        // ConcurrencyStamp
        // PhoneNumber
        // PhoneNumberConfirmed
        // TwoFactorEnabled
        // LockoutEnd
        // LockoutEnabled
        // AccessFailedCount

    }
}