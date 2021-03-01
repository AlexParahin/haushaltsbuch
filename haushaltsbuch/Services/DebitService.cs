using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using haushaltsbuch.Models;
using MongoDB.Driver;

namespace haushaltsbuch.Services
{
    public class DebitService
    {
        private readonly IMongoCollection<Debit> _debits;
        public DebitService(IHaushalstBuchDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _debits = database.GetCollection<Debit>(settings.BudgetbookCollectionName);
        }
        // Get list of all documents in Debit collection

        public List<Debit> Get() =>
                _debits.Find(debit => true).ToList();

        public Debit Get(string id) =>
            _debits.Find<Debit>(debit => debit.Id == id).FirstOrDefault();

        // Create one Debit document
        public Debit Create(Debit debit)
        {
            _debits.InsertOne(debit);
            return debit;
        }
        // Update one Debit document
        public void Update(string id, Debit debitIn) =>
            _debits.ReplaceOne(debit => debit.Id == id, debitIn);


    }
}
