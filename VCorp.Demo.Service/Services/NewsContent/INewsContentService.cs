using System.Threading.Tasks;
using VCorp.Demo.ViewModels.Common;
using VCorp.Demo.ViewModels.Request;
using VCorp.Demo.ViewModels.ViewModels;

namespace VCorp.Demo.Service.Services.NewsContent
{
    public interface INewsContentService
    {
        Task<PagedResult<NewsContentViewModel>> GetAllPaging(GetNewsContentPagingRequest request);
        Task<NewsContentViewModel> GetByNewsId(long newsId);
    }
}
