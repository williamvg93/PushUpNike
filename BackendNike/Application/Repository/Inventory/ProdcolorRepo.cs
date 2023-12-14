using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Inventory;
using Domain.Interfaces.Inventory;
using Persistence.Data;

namespace Application.Repository.Inventory;

public class ProdcolorRepo : GenericRepository<Prodcolor>, IProdcolor
{
    private readonly ApiNikeContext _context;

    public ProdcolorRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}