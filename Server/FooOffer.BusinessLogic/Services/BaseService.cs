using AutoMapper;

namespace FooOffer.BusinessLogic.Services
{
    public class BaseService
    {
        private readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}