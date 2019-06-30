using AutoMapper;
using Library.Entity;
using Library.Presentation.Models;

namespace Library.Presentation.Core
{
    public class ControllerProfile
    {
        public static IMapper Mapper { get; set; }

        public static void Configure()
        {
            var MapperConfiguration = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<BorrowedBook, BorrowModel>()
                .ForMember(dto => dto.Book, opt => opt.MapFrom(src => src.Book))
                .ReverseMap();
                cfg.CreateMap<Book, BookModel>().ReverseMap();

            });

            Mapper = MapperConfiguration.CreateMapper();

        }
    }
}