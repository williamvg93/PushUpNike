using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.UserAuthenti;
using Domain.Interfaces.UserAuthenti;
using Persistence.Data;

namespace Application.Repository.UserAuthenti;

public class TokenRepo : GenericRepository<Token>, IToken
{
    private readonly ApiNikeContext _context;

    public TokenRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}