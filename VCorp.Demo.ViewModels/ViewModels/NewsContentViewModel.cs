using System.Collections.Generic;

namespace VCorp.Demo.ViewModels.ViewModels
{
    public class NewsContentViewModel
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public string Avatar { get; set; }
        public string Avatar4 { get; set; }
        public string Title { get; set; }
        public string Sapo { get; set; }
        public string Author { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string BackgroupColor { get; set; }
        public string TextColor { get; set; }
        public string CoverSize { get; set; }
        public List<dynamic> Body { get; set; }
    }
}
