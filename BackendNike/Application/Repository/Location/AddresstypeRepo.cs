using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Domain.Interfaces.Location;
using Persistence.Data;

namespace Application.Repository.Location;

public class AddresstypeRepo : GenericRepository<Addresstype>, IAddresstype
{
    private readonly ApiNikeContext _context;

    public AddresstypeRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}