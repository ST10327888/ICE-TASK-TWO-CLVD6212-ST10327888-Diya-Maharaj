using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Options;

public class TableService
{
    private readonly TableClient _tableClient;

    public TableService(IOptions<AppSettings> options)
    {
        var settings = options.Value;
        // Using DefaultAzureCredential will pick up your local dev credentials or managed identity in Azure
        var credential = new Azure.Identity.DefaultAzureCredential();
        var serviceClient = new TableServiceClient(new Uri(settings.TableEndpoint), credential);
        _tableClient = serviceClient.GetTableClient(settings.TableName);
        _tableClient.CreateIfNotExists();
    }

    public async Task UpsertProductAsync(Product p)
    {
        await _tableClient.UpsertEntityAsync(p, Azure.Data.Tables.TableUpdateMode.Replace);
    }

    public async Task<List<Product>> QueryByCategoryAsync(string category)
    {
        var results = _tableClient.QueryAsync<Product>(prod => prod.PartitionKey == category);
        var list = new List<Product>();
        await foreach (var item in results)
        {
            list.Add(item);
        }
        return list;
    }
}
