using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.BusinessMovements;
using Domain.Interfaces.BusinessMovements;
using Persistence.Data;

namespace Application.Repository.BusinessMovements;

public class OrderRepo : GenericRepository<Order>, IOrder
{
    private readonly ApiNikeContext _context;

    public OrderRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}