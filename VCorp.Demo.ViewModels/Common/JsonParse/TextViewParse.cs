using Newtonsoft.Json;

namespace VCorp.Demo.ViewModels.Common.JsonParse
{
    public class TextViewParse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
