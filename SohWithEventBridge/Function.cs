using Amazon.Lambda.CloudWatchEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SohWithEventBridge;

public class Function
{ 
    public string StockOnHandEventHandler(CloudWatchEvent<dynamic> stockEvent, ILambdaContext context)
    {
        context.Logger.LogLine($"StockOnHandEventHandler: {stockEvent.Detail}");
        return new string("StockOnHandEventHandler Completed");
    }
}
