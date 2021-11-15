using EasyCheckout.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCheckout.Data.Services
{
    public class SkuService
    {
        private readonly IMongoCollection<Sku> _skus;

        public SkuService(IEasyCheckoutDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _skus = database.GetCollection<Sku>(settings.SkuCollectionName);
        }

        public List<Sku> Get() => _skus.Find(sku => true).ToList();

        public Sku Get(Guid Id) => _skus.Find<Sku>(sku => sku.Id == Id).FirstOrDefault();

        public Sku Create(Sku sku)
        {
            _skus.InsertOne(sku);
            return sku;
        }

        public void Update(Guid id, Sku skuIn) => _skus.ReplaceOne(sku => sku.Id == id, skuIn);

        public void Remove(Sku skuIn) => _skus.DeleteOne(sku => sku.Id == skuIn.Id);

        public void Remove(Guid id) => _skus.DeleteOne(skus => skus.Id == id);
    }
}
