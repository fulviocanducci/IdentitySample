using IdentitySample.Domain.Entities;
using IdentitySample.Domain.Interfaces.Repository;
using IdentitySample.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IdentitySampleDbContext context) 
            : base(context)
        {
        }
    }
}
