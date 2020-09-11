using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VCorp.Demo.Data.EF;
using VCorp.Demo.ViewModels.Common;
using VCorp.Demo.ViewModels.Request;
using VCorp.Demo.ViewModels.ViewModels;

namespace VCorp.Demo.Service.Services.NewsContent
{
    public class NewsContentService : INewsContentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NewsContentService(
            DataContext context,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedResult<NewsContentViewModel>> GetAllPaging(GetNewsContentPagingRequest request)
        {
            var query = _context.NewsContents
                .OrderByDescending(x => x.PublishedDate).AsQueryable();
            var totalRow = await query.CountAsync();

            var newsContentPaging = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(x => x.Zone)
                .Include(x => x.NewsExtensions);

            var newsContents = await newsContentPaging.ToListAsync();
            var data = _mapper.Map<List<NewsContentViewModel>>(newsContents);

            var pagedResult = new PagedResult<NewsContentViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<NewsContentViewModel> GetByNewsId(long newsId)
        {
            var newContent = await _context.NewsContents
                .Include(x => x.Zone)
                .Include(x => x.NewsExtensions)
                .FirstOrDefaultAsync(x => x.NewsId == newsId);

            if(newContent == null)
            {
                throw new DemoException($"Id {newsId} not found");
            }

            var data = _mapper.Map<NewsContentViewModel>(newContent);
            return data;
        }
    }
}
