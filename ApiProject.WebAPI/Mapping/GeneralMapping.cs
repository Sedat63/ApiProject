using ApiProject.WebAPI.Dtos.FeatureDtos;
using ApiProject.WebAPI.Dtos.MessageDtos;
using ApiProject.WebAPI.Dtos.ProductDtos;
using ApiProject.WebAPI.Entities;
using AutoMapper;

namespace ApiProject.WebAPI.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(c => c.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
        }
    }
}
