using Amazon.Lambda.CloudWatchEvents;
using Amazon.Lambda.Core;
using SohWithEventBridge.Models;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SohWithEventBridge;

public class Function
{ 
    public string StockOnHandEventHandler(CloudWatchEvent<dynamic> stockEvent, ILambdaContext context)
    {
        Detail payload = JsonSerializer.Deserialize<Detail>(stockEvent.Detail.ToString());

        context.Logger.LogInformation($"SKU: {payload.dynamodb.NewImage["sku"].S}");

        if (payload.dynamodb.NewImage["soh"].N != null && int.Parse(payload.dynamodb.NewImage["soh"].N) > 0)
        {
            context.Logger.LogInformation("Stock is available");
            return "Stock is available";
        }
        else
        {
            context.Logger.LogError("Stock is not available");
            return "Stock is not available";
        }
    }
}
