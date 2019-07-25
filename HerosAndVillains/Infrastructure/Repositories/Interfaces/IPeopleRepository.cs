using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerosAndVillains.Models;

namespace HerosAndVillains.Infrastructure
{
    public interface IPeopleRepository
    {
        Task<List<Person>> GetPersons(string searchVal);
    }
}

