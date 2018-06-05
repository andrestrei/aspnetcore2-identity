using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Application.Interfaces.Repositories
{
    public interface IBlahRepository : IRepository<Blah>
    {
        List<Blah> GetAll(string startingLetter);
    }
}
