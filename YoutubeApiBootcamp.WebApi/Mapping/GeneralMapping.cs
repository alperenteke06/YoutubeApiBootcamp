using AutoMapper;
using YoutubeApiBootcamp.WebApi.Dtos.CategoryDtos;
using YoutubeApiBootcamp.WebApi.Dtos.FeatureDtos;
using YoutubeApiBootcamp.WebApi.Dtos.MessageDtos;
using YoutubeApiBootcamp.WebApi.Dtos.NotificationDtos;
using YoutubeApiBootcamp.WebApi.Dtos.ProductDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<ContactMessage, CreateContactMessageDto>().ReverseMap();
            CreateMap<ContactMessage, GetByIdContactMessageDto>().ReverseMap();
            CreateMap<ContactMessage, ResultContactMessageDto>().ReverseMap();
            CreateMap<ContactMessage, UpdateContactMessageDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetProductWithCategoryDto>().ForMember(x=>x.CategoryName, y=> y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();

            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
        }
    }
}
