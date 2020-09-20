using AutoMapper;
using FooOffer.BusinessLogic.Dto.City;
using FooOffer.Core.Entities;

namespace FooOffer.BusinessLogic.Common.MapperProfiles
{
    public class CityMapperProfile : Profile
    {
        public CityMapperProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}