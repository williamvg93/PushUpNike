using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.UserAuthenti;

namespace Domain.Interfaces.UserAuthenti;

public interface IToken : IGenericRepository<Token>
{
}