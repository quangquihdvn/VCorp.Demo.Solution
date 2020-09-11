using System;
using System.Collections.Generic;
using VCorp.Demo.Common.Enums;

namespace VCorp.Demo.Data.Entities
{
    public class Zone
    {
        /// <summary>
        /// Id chuyên mục
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tên chuyên mục
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Lưu shorturl
        /// </summary>
        public string ShortUrl { get; set; }

        /// <summary>
        /// Lưu stt
        /// </summary>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Id chuyên mục cha
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Hiển thị ngoài site hay không
        /// </summary>
        public bool Invisibled { get; set; }

        /// <summary>
        /// Trạng thái sử dụng
        /// </summary>
        public ZoneStatus Status { get; set; }

        public bool? AllowComment { get; set; }

        public string Domain { get; set; }

        public bool UseForFunnyNews { get; set; }

        /// <summary>
        /// Ảnh cover
        /// </summary>
        public string AvatarCover { get; set; }

        public bool? IsHot { get; set; }

        public List<NewsContent> NewsContents { get; set; }
    }
}
