using Newtonsoft.Json;

namespace VCorp.Demo.ViewModels.Common.JsonParse
{
    public class PhotoParse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("img")]
        public ImageParse Image{ get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
