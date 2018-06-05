using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.Application.Interfaces.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        
    }
}
