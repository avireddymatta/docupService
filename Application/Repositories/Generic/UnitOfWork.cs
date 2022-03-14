using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Application.Repositories.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private DocUpContext _context;
        private readonly Type ContextType;
        public UnitOfWork(DocUpContext context)
        {
            _context = context;
        }

        private IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return new GenericRepository<ApplicationUser>(_context);
            }
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Complete(bool usingTransaction)
        {
            if (!usingTransaction)
                return await Complete();

            bool status = false;
            using (var ts = _context.Database.BeginTransaction())
            {
                try
                {
                    status = await _context.SaveChangesAsync() > 0;
                    await ts.CommitAsync();
                }
                catch (Exception)
                {
                    await ts.RollbackAsync();
                    throw;
                }
            }
            return status;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}