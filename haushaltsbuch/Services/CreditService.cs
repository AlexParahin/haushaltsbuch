using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using haushaltsbuch.Models;
using MongoDB.Driver;

namespace haushaltsbuch.Services
{
    public class CreditService
    {
        private readonly IMongoCollection<Credit> _credits;

        public CreditService(IHaushalstBuchDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _credits = database.GetCollection<Credit>(settings.BudgetbookCollectionName);
        }
        // Get list of all documents in Credit collection.
        public List<Credit> Get() =>
            _credits.Find(credit => true).ToList();

        // Get one credit document by id. 
        public Credit Get(string id) =>
            _credits.Find<Credit>(credit => credit.Id == id).FirstOrDefault();

        // Create one Credit document.
        public Credit Create(Credit credit)
        {
            _credits.InsertOne(credit);
            return credit;
        }

        // Update one Credit document.
        public void Update(string id, Credit creditIn) =>
            _credits.ReplaceOne(credit => credit.Id == id, creditIn);

        // Delete one Credit document by id in body.
        public void Remove(Credit creditIn) =>
            _credits.DeleteOne(credit => credit.Id == creditIn.Id);

        // Delete one Credit document by id.
        public void Remove(string id) =>
            _credits.DeleteOne(credit => credit.Id == id);
    }
}
