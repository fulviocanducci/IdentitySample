using IdentitySample.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
