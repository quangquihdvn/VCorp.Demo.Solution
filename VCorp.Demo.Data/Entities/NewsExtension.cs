using VCorp.Demo.Common.Enums;

namespace VCorp.Demo.Data.Entities
{
    public class NewsExtension
    {
        /// <summary>
        /// ID tin
        /// </summary>
        public int NewsId { get; set; }
        public NewsContent NewsContent { get; set; }

        /// <summary>
        /// Mã số quy ước
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Giá trị cấu hinh
        /// </summary>
        public string Value { get; set; }
    }
}
