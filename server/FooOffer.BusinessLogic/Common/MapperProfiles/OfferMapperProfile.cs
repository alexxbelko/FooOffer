using AutoMapper;
using FooOffer.BusinessLogic.Dto.Offer;
using FooOffer.Core.Entities;

namespace FooOffer.BusinessLogic.Common.MapperProfiles
{
    public class OfferMapperProfile : Profile
    {
        public OfferMapperProfile()
        {
            CreateMap<Offer, OfferDto>().ReverseMap();
            CreateMap<OfferItem, OfferItemDto>().ReverseMap();
        }
    }
}