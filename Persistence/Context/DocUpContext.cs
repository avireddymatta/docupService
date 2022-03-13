using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DocUpContext : IdentityDbContext<User>
    {
        public DocUpContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}