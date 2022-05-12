namespace CatalogService.Data
{
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Configuration;

    public class CosmosDbContext
    {
        private Database _database;
        public Container _Giftcards;
        public Container _Partners;

        public IConfiguration Configuration { get; }
        public CosmosDbContext(IConfiguration configuration)
        {

            Configuration = configuration;
            string account = configuration["DB:Account"];
            string key = configuration["DB:Key"];
            string databaseName = configuration["DB:DB_Artemis"];

            var dbClient = new Microsoft.Azure.Cosmos.CosmosClient(account, key);

            this._database =  dbClient.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();

            this._Giftcards =  _database.CreateContainerIfNotExistsAsync("Giftcards", "/id").GetAwaiter().GetResult();
            this._Partners  =  _database.CreateContainerIfNotExistsAsync("Partners", "/id").GetAwaiter().GetResult();
       
        }
    }
}
