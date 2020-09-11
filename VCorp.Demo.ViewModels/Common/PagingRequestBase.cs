using System.ComponentModel.DataAnnotations;

namespace VCorp.Demo.ViewModels.Common
{
    public class PagingRequestBase
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page size is positive number only")]
        public int PageIndex { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Page index is positive number only")]
        public int PageSize { get; set; }
    }
}
