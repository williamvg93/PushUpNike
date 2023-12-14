using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.BusinessMovements;
using Domain.Interfaces.BusinessMovements;
using Persistence.Data;

namespace Application.Repository.BusinessMovements;

public class OrderstatusRepo : GenericRepository<Orderstatus>, IOrderstatus
{
    private readonly ApiNikeContext _context;

    public OrderstatusRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}