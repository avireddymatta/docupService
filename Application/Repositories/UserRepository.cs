using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Repositories.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Application.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(DbContext _context) :
            base(_context)
        {
        }
    }
}