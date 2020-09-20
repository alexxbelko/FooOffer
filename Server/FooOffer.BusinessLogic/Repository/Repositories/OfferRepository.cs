using FooOffer.BusinessLogic.Repository.Interfaces;
using FooOffer.Core.Entities;
using FooOffer.Infrastructure.Data;

namespace FooOffer.BusinessLogic.Repository.Repositories
{
    public class OfferRepository : RepositoryBase<Offer, DataContext>, IOfferRepository
    {
        private readonly DataContext _context;

        public OfferRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}