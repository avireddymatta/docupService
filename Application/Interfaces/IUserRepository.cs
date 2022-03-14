using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {

    }
}