using AutoMapper;
using Blog.Models;
using Blog.Models.Views;

namespace Blog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, EditViewModel> ().ForMember(x => x.TagIds, opt => opt.MapFrom(x => x.Tags.Select(y => y.Id)))
                .ForMember(x =>x.Categories, opt => opt.Ignore())
                .ForMember(x => x.Tags, opt => opt.Ignore());
        }
    }
}
