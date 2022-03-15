using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;

namespace Application.Interfaces.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ApplicationUser> Users { get; }
        Task<bool> Complete();
        Task<bool> Complete(bool usingTransaction);
        IMapper mapper { get; }

    }
}