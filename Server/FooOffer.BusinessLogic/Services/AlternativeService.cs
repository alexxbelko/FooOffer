using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FooOffer.BusinessLogic.Common.Attributes;
using FooOffer.BusinessLogic.Dto.Alternative;
using FooOffer.BusinessLogic.Interfaces;
using FooOffer.BusinessLogic.Repository.Repositories;
using FooOffer.Core.Entities;

namespace FooOffer.BusinessLogic.Services
{
    [AutoRegisterService]
    public class AlternativeService : BaseService, IAlternativeService
    {
        private readonly AlternativeRepository _alternativeRepository;
        private readonly IMapper _mapper;

        public AlternativeService(AlternativeRepository alternativeRepository, IMapper mapper) : base(mapper)
        {
            _alternativeRepository = alternativeRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<AlternativeDto>> GetAvailableServicesByCityIdAsync(int cityId)
        {
            var alternatives = 
                await _alternativeRepository.GetAvailableServicesByCityIdAsync(cityId);

            return _mapper.Map<IEnumerable<AlternativeDto>>(alternatives);
        }

        public async Task<AlternativeDto> GetAlternativeByIdAsync(int alternativeId)
        {
            try
            {
                var alternative = await _alternativeRepository.Get(alternativeId);
                return _mapper.Map<AlternativeDto>(alternative);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}