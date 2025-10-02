using Azure;
using Azure.Data.Tables;
using System;

public record Product : ITableEntity
{
    public required string RowKey { get; set; }
    public required string PartitionKey { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required bool Clearance { get; set; }
    public ETag ETag { get; set; } = ETag.All;
    public DateTimeOffset? Timestamp { get; set; }
}
