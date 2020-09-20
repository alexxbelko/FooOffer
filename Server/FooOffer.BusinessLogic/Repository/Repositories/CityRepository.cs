using System;
using System.Collections;
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
    public class CityRepository : RepositoryBase<City, DataContext>, ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}