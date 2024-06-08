using AutoMapper;
using CodeFirst;
using CodeFirst.DTO;

namespace CodeFirstAPI.Cofnig
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryDTO>();
                config.CreateMap<CategoryDTO, Category>();

/*                config.CreateMap<Book, BookDTO>()
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));*/
            });

            return mapperConfig.CreateMapper();
        }
    }
}
