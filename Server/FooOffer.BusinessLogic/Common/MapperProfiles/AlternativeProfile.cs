using AutoMapper;
using FooOffer.BusinessLogic.Dto.Alternative;
using FooOffer.Core.Entities;

namespace FooOffer.BusinessLogic.Common.MapperProfiles
{ 
    public class AlternativeProfile : Profile
    {
        public AlternativeProfile()
        {
            CreateMap<Alternative, AlternativeDto>().ReverseMap();
        }
    }
}