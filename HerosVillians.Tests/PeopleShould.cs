using NUnit.Framework;
using HerosAndVillains.Controllers;
using HerosAndVillains.Infrastructure;
using HerosAndVillains.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace HerosVillians.Tests
{
    [TestFixture]
    public class PeopleShould
    {
        private readonly IPeopleRepository _people;

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Test]
        public async Task Get_AllPersons()
        {
            IConfiguration _configuration = InitConfiguration();

            var p = new PeopleRepository(_configuration);

            var x = await p.GetPersons("");

            Assert.IsTrue(x.Count==10);

        }
    }
}
