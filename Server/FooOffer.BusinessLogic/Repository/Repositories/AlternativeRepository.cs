using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FooOffer.BusinessLogic.Common.Attributes;
using FooOffer.BusinessLogic.Repository.Interfaces;
using FooOffer.Core.Entities;
using FooOffer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FooOffer.BusinessLogic.Repository.Repositories
{
    public class AlternativeRepository : RepositoryBase<Alternative, DataContext>, IAlternativeRepository
    {
        private readonly DataContext _context;

        public AlternativeRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Alternative>> GetAvailableServicesByCityIdAsync(int cityId)
        {
            return await _context.Alternatives.Where(x => x.CityId == cityId)
                .OrderByDescending(x => x.IsMainAlternative)
                .ToListAsync();
        }
    }
}