using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Inventory;
using Domain.Interfaces.Inventory;
using Persistence.Data;

namespace Application.Repository.Inventory;

public class GendertypeRepo : GenericRepository<Gendertype>, IGendertype
{
    private readonly ApiNikeContext _context;

    public GendertypeRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}