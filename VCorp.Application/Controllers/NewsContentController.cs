using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VCorp.Demo.Service.Services.NewsContent;
using VCorp.Demo.ViewModels.Request;

namespace VCorp.Demo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NewsContentController : Controller
    {
        public readonly INewsContentService _newsContentService;
        public NewsContentController(
            INewsContentService newsContentService
            )
        {
            _newsContentService = newsContentService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetNewsContentPagingRequest request)
        {
            var newsContents = await _newsContentService.GetAllPaging(request);
            return Ok(newsContents);
        }

        [HttpGet("{newsId}")]
        public async Task<IActionResult> Get([FromRoute]long newsId)
        {
            var newContent = await _newsContentService.GetByNewsId(newsId);
            return Ok(newContent);
        }
    }
}
