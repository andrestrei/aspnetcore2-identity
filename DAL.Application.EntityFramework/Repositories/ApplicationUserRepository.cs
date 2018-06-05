using System;
using System.Collections.Generic;
using System.Text;
using DAL.Application.Interfaces.Repositories;
using DAL.Interfaces;
using Domain;

namespace DAL.Application.EntityFramework.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDataContext dataContext) : base(dataContext)
        {
            
        }
    }
}
