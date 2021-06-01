using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ProductService
    {
        IGridFSBucket gridFS;
        IMongoCollection<Product> Products;

        public ProductService()
        {
            string connectionString = "mongodb://localhost:27017/mobilestore";
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(database);
            Products = database.GetCollection<Product>("Products");
        }

        public async Task<IEnumerable<Product>> GetProducts(int? minPrice, int? maxPrice, string name)
        {
            var builder = new FilterDefinitionBuilder<Product>();
            var filter = builder.Empty;
            if (!String.IsNullOrWhiteSpace(name))
            {
                filter = filter & builder.Regex("Name", new BsonRegularExpression(name));
            }

            if (minPrice.HasValue)
            {
                filter = filter & builder.Gte("Price", minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filter = filter & builder.Lte("Price", maxPrice.Value);
            }

            return await Products.Find(filter).ToListAsync();
        }

        public async Task Create(Product p)
        {
            await Products.InsertOneAsync(p);
        }

        public async Task Remove(string id)
        {
            await Products.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
