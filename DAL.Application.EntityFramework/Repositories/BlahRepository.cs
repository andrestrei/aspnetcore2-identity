using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DAL.Application.Interfaces.Repositories;
using DAL.Interfaces;

namespace DAL.Application.EntityFramework.Repositories
{
    public class BlahRepository : BaseRepository<Blah>, IBlahRepository
    {
        public BlahRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public List<Blah> GetAll(string startingLetter)
        {
            throw new NotImplementedException();
        }
    }
}
