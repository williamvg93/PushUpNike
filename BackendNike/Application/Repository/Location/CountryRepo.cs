using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class CountryRepo : GenericRepository<Country>, ICountry
{
    private readonly ApiNikeContext _context;

    public CountryRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}