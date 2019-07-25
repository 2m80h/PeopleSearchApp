using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using HerosAndVillains.Models;
using Dapper;

namespace HerosAndVillains.Infrastructure
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IConfiguration _configuration;


        public PeopleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task CreateDBAndInsertPersons()
        {

            try
            {
                IDbConnection dbConn = DataConnection.CatalystDBConnection(_configuration);

                string db = dbConn.Database;

                using (IDbConnection dbConnection = new SqlConnection(dbConn.ConnectionString.Replace(db, "Master")))
                {

                    string query = $"CREATE DATABASE " + db;
                    await dbConnection.ExecuteAsync(query);

                    query = string.Format("CREATE TABLE [{0}]", db) + @".[dbo].[person](
                        [personID][int] IDENTITY(1, 1) NOT NULL,
                        [firstName] [varchar] (50) NOT NULL,
                        [lastName] [varchar] (50) NOT NULL,
                        [address] [varchar] (50) NOT NULL,
                        [birthDate] [datetime] NOT NULL,
                        [intrests] [varchar] (512) NULL,
	                    [picture][varbinary] (max) NULL
                    ) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";

                    await dbConnection.ExecuteAsync(query);


                    query = string.Format("INSERT INTO [{0}]", db) + @".[dbo].[person]([FirstName], [LastName], [address], [birthDate], [intrests], [picture]) VALUES (@FirstName, @LastName, @address, @birthDate, @intrests, @picture)";
                    Person person = new Person("Dr", "Doom", "Mars", "1/1/1957", "Destruction", File.ReadAllBytes(@".\images\doom.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Bat", "Man", "Cave", "1/1/1958", "Bats, Villans", File.ReadAllBytes(@".\images\batman.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Dead", "Pool", "Downtown", "1/1/1967", "Swords, Conversation", File.ReadAllBytes(@".\images\deadpool.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Nick", "Fury", "Unknown", "1/1/1959", "Crime, Hydra", File.ReadAllBytes(@".\images\Fury.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Mag", "Neto", "Mars", "1/1/1937", "Metal", File.ReadAllBytes(@".\images\Magneto.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Mr", "Penguin", "Sewer", "1/1/1947", "Penguins", File.ReadAllBytes(@".\images\Penguin.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Two", "Face", "Gotham", "1/1/1947", "Coins", File.ReadAllBytes(@".\images\twoface.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Un", "known", "Dunno", "1/1/1977", "Mystery Novels", File.ReadAllBytes(@".\images\unknown.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Wolv", "Erine", "Poland", "1/1/1927", "Healing, Unobtanium", File.ReadAllBytes(@".\images\wolverine.png"));
                    await dbConnection.ExecuteAsync(query, person);
                    person = new Person("Joke", "Her", "Detroit", "1/1/1957", "Jokes, Makeup", File.ReadAllBytes(@".\images\Joker.png"));
                    await dbConnection.ExecuteAsync(query, person);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool IsDBAvailable(IDbConnection dbConnection)
        {

            try
            {
                dbConnection.Open();
                dbConnection.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Person>> GetPersons(IDbConnection dbConnection, string query, string searchVal)
        {
            var people = await dbConnection.QueryAsync<Person>(query);

            var selectPeople = people.Where(p =>
            p.FirstName.ToLower().Contains(searchVal) ||
            p.LastName.ToLower().Contains(searchVal) ||
            p.name.ToLower().Contains(searchVal));

            return selectPeople.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public async Task<List<Person>> GetPersons(string searchVal)
        {
            try
            {
                searchVal = searchVal.ToLower();

                using (IDbConnection dbConnection = DataConnection.CatalystDBConnection(_configuration))
                {

                    string query = $"Select personID,firstName,lastName,address,birthDate,intrests,picture, firstName + lastName as name from dbo.person";

                    if (!IsDBAvailable(dbConnection))
                    {
                        //Task.Run(() => CreateDBAndInsertPersons()).Wait();
                        await CreateDBAndInsertPersons();
                        await Task.Delay(5000); //pause after creation and inserts...
                        return await GetPersons(dbConnection, query, searchVal);
                    }
                    else
                    {
                        return await GetPersons(dbConnection, query, searchVal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
