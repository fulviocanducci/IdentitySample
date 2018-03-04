using IdentitySample.Domain.Commands;
using IdentitySample.Domain.Interfaces;
using IdentitySample.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentitySampleDbContext _context;

        public UnitOfWork(IdentitySampleDbContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
