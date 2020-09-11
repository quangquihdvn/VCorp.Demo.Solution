using Newtonsoft.Json;
using System.Collections.Generic;

namespace VCorp.Demo.ViewModels.Common.JsonParse
{
    public class CreditParse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("item")]
        public List<ItemViewModel> Item { get; set; }

        [JsonProperty("source")]
        public SourceViewModel Source { get; set; }

        [JsonProperty("publishDate")]
        public string PublishDate { get; set; }
    }

    public class ItemViewModel
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class SourceViewModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
