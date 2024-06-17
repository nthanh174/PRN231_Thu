using AutoMapper;
using Event_CodeFirst.DTO;
using Event_CodeFirst.Models;

namespace API.Cofnig
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Event, EventDTO>();
                config.CreateMap<EventDTO, Event>();

                config.CreateMap<Feedback, FeedbackDTO>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Event.EventId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Event.Title));

/*                config.CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Category, opt => opt.Ignore()); // Bỏ qua ánh xạ Category vì nó là đối tượng phức tạp*/
            });

            return mapperConfig.CreateMapper();
        }
    }
}
