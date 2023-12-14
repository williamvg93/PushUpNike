using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.UserAuthenti;
using Domain.Interfaces.UserAuthenti;
using Persistence.Data;

namespace Application.Repository.UserAuthenti;

public class UserRepo : GenericRepository<User>, IUser
{
    private readonly ApiNikeContext _context;

    public UserRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}