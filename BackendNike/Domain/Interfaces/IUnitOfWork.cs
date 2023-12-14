using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.BusinessMovements;
using Domain.Interfaces.Inventory;
using Domain.Interfaces.Location;
using Domain.Interfaces.Person;
using Domain.Interfaces.UserAuthenti;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IOrder Orders { get; }
    IOrderdetail OrderDetails { get; }
    IOrderstatus OrderStates { get; }
    IPaymenttype PaymentTypes { get; }
    IGendertype GenderTypes { get; }
    IProdcategory ProductCategories { get; }
    IProdcolor ProductColors { get; }
    IProduct Products { get; }
    IAddress Addresses { get; }
    IAddresstype AddressTypes { get; }
    ICity Cities { get; }
    ICountry Countries { get; }
    IDepartment Departments { get; }
    IClient Clients { get; }
    IContact Contacts { get; }
    IContacttype ContactTypes { get; }
    IToken Tokens { get; }
    IUser Users { get; }
    IUserrol UserRoles { get; }
    Task<int> SaveAsync();
}