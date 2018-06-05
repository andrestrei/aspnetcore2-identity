using DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using Domain;

namespace DAL.Application.EntityFramework.Repositories
{
    public class FooBarRepository : BaseRepository<FooBar>
    {
        public FooBarRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
