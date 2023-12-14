using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Person;
using Domain.Interfaces.Person;
using Persistence.Data;

namespace Application.Repository.Person;

public class ContactRepo : GenericRepository<Contact>, IContact
{
    private readonly ApiNikeContext _context;

    public ContactRepo(ApiNikeContext context) : base(context)
    {
        _context = context;
    }
}