using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FooOffer.BusinessLogic.Common.Attributes;
using FooOffer.BusinessLogic.Repository.Interfaces;
using FooOffer.Core.Entities;
using FooOffer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FooOffer.BusinessLogic.Repository.Repositories
{
    [AutoRegisterService]
    public abstract class RepositoryBase<TEntity, TContext>: IRepositoryBase<TEntity> 
        where TEntity : class, IEntity
        where TContext : DataContext
    {
        private readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}