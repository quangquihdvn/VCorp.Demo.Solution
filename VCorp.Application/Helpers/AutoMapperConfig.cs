using AutoMapper;
using System.Linq;
using VCorp.Demo.Common.Enums;
using VCorp.Demo.Data.Entities;
using VCorp.Demo.Service.Helpers;
using VCorp.Demo.ViewModels.ViewModels;

namespace VCorp.Demo.Application.Helpers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsContent, NewsContentViewModel>()
                    .ForMember(x => x.Url, y => y.MapFrom(z => z.Url))
                    .ForMember(x => x.Type, y => y.MapFrom(z => z.Type.Value.ToString()))
                    .ForMember(x => x.Tags, y => y.MapFrom(z => z.Tags))
                    .ForMember(x => x.Avatar, y => y.MapFrom(z => z.Avatar))
                    .ForMember(x => x.Avatar4, y => y.MapFrom(z => z.Avatar4))
                    .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                    .ForMember(x => x.Sapo, y => y.MapFrom(z => z.Sapo))
                    .ForMember(x => x.Author, y => y.MapFrom(z => z.Avatar))
                    .ForMember(x => x.ZoneId, y => y.MapFrom(z => z.ZoneId))
                    .ForMember(x => x.ZoneName, y => y.MapFrom(z => z.Zone.Name))
                    .ForMember(x => x.BackgroupColor, y => y.MapFrom(z =>
                        z.NewsExtensions.FirstOrDefault(x => x.Type == NewsExtensionType.BackgroundColor.GetHashCode()).Value))
                    .ForMember(x => x.TextColor, y => y.MapFrom(z =>
                        z.NewsExtensions.FirstOrDefault(x => x.Type == NewsExtensionType.TextColor.GetHashCode()).Value))
                    .ForMember(x => x.CoverSize, y => y.MapFrom(z =>
                        z.NewsExtensions.FirstOrDefault(x => x.Type == NewsExtensionType.CoverSize.GetHashCode()).Value))
                    //.ForMember(x => x.Body, y => y.Ignore());
                    .ForMember(x => x.Body, y => y.MapFrom(z => HtmlHelpers.ConvertHtml(z.Body)));
            });
            return config.CreateMapper();
        }
    }
}
