using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haushaltsbuch.Models
{
    public class BudgetbookDatabaseSettings : IBudgetbookDatabaseSettings
    {
        public string CreditCollectionName { get; set; }
        public string DebitCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IBudgetbookDatabaseSettings
    {
        string CreditCollectionName { get; set; }
        string DebitCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
