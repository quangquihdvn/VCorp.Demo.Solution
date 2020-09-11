using Newtonsoft.Json;
using System.Collections.Generic;

namespace VCorp.Demo.ViewModels.Common.JsonParse
{
    public class LayoutAlbumParse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("img")]
        public List<TempwidgetsImageViewModel> Img { get; set; }
    }

    public class TempwidgetsImageViewModel
    {
        [JsonProperty("row")]
        public int Row { get; set; }

        [JsonProperty("img")]
        public List<TempwidgetsImageDetailModel> Img { get; set; }
    }

    public class TempwidgetsImageDetailModel
    {
        public TempwidgetsImageDetailModel()
        {
            Original_img = "";
            Size = new ImageSizeParse
            {
                Width = -1,
                Height = -1
            };
        }
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("original_img")]
        public string Original_img { get; set; }

        [JsonProperty("size")]
        public ImageSizeParse Size { get; set; }
    }
}
