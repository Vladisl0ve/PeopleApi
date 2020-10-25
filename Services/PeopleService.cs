using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using PeopleApi.Models;

namespace PeopleApi.Services
{
    public class PeopleService
    {
        private readonly IMongoCollection<People> _people;

        public PeopleService(IPeopleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _people = database.GetCollection<People>(settings.PeopleCollectionName);
        }

        public List<People> Get() => _people.Find(p => true).ToList();

        public People Get(string id) => _people.Find<People>(p => p.Id == id).FirstOrDefault();

        public People Create(People p)
        {
            _people.InsertOne(p);
            return p;
        }

        public void Update(string id, People p) => _people.ReplaceOne(person => person.Id == id, p);
        public void Remove(People p) => _people.DeleteOne(person => person.Id == p.Id);
        public void Remove(string id) => _people.DeleteOne(person => person.Id == id);
    }
}
