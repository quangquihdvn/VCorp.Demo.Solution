using Newtonsoft.Json;

namespace VCorp.Demo.ViewModels.Common.JsonParse
{
    public class ImageParse
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("original_img")]
        public string Original_img { get; set; }

        [JsonProperty("size")]
        public ImageSizeParse Size { get; set; }
    }

    public class ImageSizeParse
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

}
