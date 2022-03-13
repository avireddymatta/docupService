using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DocUpContext : IdentityDbContext<ApplicationUser>
    {
        public DocUpContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplicationUser> User { get; set; }
    }
}