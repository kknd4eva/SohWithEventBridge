using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SohWithEventBridge.Models
{
    public class StockEvent
    {
        public string Version { get; set; }
        public string Id { get; set; }
        public string DetailType { get; set; }
        public string Source { get; set; }
        public string Account { get; set; }
        public DateTime Time { get; set; }
        public string Region { get; set; }
        public List<object> Resources { get; set; }
        public Detail Detail { get; set; }
    }

    public class Detail
    {
        public string EventID { get; set; }
        public string EventName { get; set; }
        public string EventVersion { get; set; }
        public string EventSource { get; set; }
        public string AwsRegion { get; set; }
        public DynamodbEvent dynamodb { get; set; }
        public string EventSourceARN { get; set; }
    }

    public class DynamodbEvent
    {
        public long ApproximateCreationDateTime { get; set; }
        public Dictionary<string, AttributeValue> Keys { get; set; }
        public Dictionary<string, AttributeValue> NewImage { get; set; }
        public Dictionary<string, AttributeValue>? OldImage { get; set; } = null; // Optional, can be null
        public string SequenceNumber { get; set; }
        public int SizeBytes { get; set; }
        public string StreamViewType { get; set; }
    }

    public class AttributeValue
    {
        public string S { get; set; } // String type
        public string N { get; set; } // Number type, can be null if the attribute is not a number
    }
}
