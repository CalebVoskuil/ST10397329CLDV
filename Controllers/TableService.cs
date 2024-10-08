﻿using Azure.Data.Tables;
using ST10397329CLDV.Models;
using System.Threading.Tasks;
namespace ST10397329CLDV.Controllers
{
    public class TableService
    {
        private readonly TableClient _tableClient;
        public TableService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureStorage:ConnectionString"];
            var serviceClient = new TableServiceClient(connectionString);
            _tableClient = serviceClient.GetTableClient("CustomerProfiles");
            _tableClient.CreateIfNotExists();
        }

        public async Task AddEntityAsync(CustomerProfile profile)
        {
            await _tableClient.AddEntityAsync(profile);
        }
    }
}
        



