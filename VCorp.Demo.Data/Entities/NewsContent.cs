using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VCorp.Demo.Common.Enums;

namespace VCorp.Demo.Data.Entities
{
    public class NewsContent
    {
        /// <summary>
        /// ID tin
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// Tiêu đề bài
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Đoạn trích ngắn
        /// </summary>
        public string Sapo { get; set; }

        /// <summary>
        /// Avatar bài
        /// </summary>
        public string Avatar { get; set; }
        public string Avatar2 { get; set; }
        public string Avatar3 { get; set; }

        /// <summary>
        /// Ảnh cover
        /// </summary>
        public string Avatar4 { get; set; }
        public string Avatar5 { get; set; }

        /// <summary>
        /// Chứa Nội dung html
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        /// <summary>
        /// Ngày xuất bản
        /// </summary>
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Nguồn tin
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// List ID liên quan
        /// </summary>
        public string NewsRelation { get; set; }

        /// <summary>
        /// List tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Tác giả bài viết
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TagPrimary { get; set; }

        /// <summary>
        /// Link bài viết (Không domain)
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// ID chuyên mục chính
        /// </summary>
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }

        /// <summary>
        /// Mã số của nguồn tin
        /// </summary>
        public int OriginalId { get; set; }

        public string TagItem { get; set; }

        public string SubTitle { get; set; }

        public string InitSapo { get; set; }

        public int? InterviewId { get; set; }

        public string OriginalUrl { get; set; }

        /// <summary>
        /// Kiểu
        /// </summary>
        public NewsContentType? Type { get; set; }

        public string AvatarDesc { get; set; }

        /// <summary>
        /// Kiểu nội dung
        /// </summary>
        public short? NewsType { get; set; }

        public int? RollingNewsId { get; set; }

        public bool? AdStore { get; set; }

        public string AdStoreUrl { get; set; }

        public int? TagSubTitleId { get; set; }
        public int? ThreadId { get; set; }
        public int? Position { get; set; }
        public int? PrPosition { get; set; }
        public bool? IsOnMobile { get; set; }
        public bool? UseTemplate { get; set; }
        public int? LocationType { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string SourceUrl { get; set; }

        /// <summary>
        /// Id gốc
        /// </summary>
        public int ParentNewsId { get; set; } 

        public DateTime? LastModifiedDate { get; set; }

        public List<NewsExtension> NewsExtensions { get; set; }
    }
}
