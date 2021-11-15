using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCheckout.Data
{
    public class EasyCheckoutDatabaseSettings : IEasyCheckoutDatabaseSettings
    {
        public string SkuCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEasyCheckoutDatabaseSettings
    {
        string SkuCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
