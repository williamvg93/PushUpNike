using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository.BusinessMovements;
using Application.Repository.Inventory;
using Application.Repository.Location;
using Application.Repository.Person;
using Application.Repository.UserAuthenti;
using Domain.Interfaces;
using Domain.Interfaces.BusinessMovements;
using Domain.Interfaces.Inventory;
using Domain.Interfaces.Location;
using Domain.Interfaces.Person;
using Domain.Interfaces.UserAuthenti;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiNikeContext _context;
    private IOrder _orders;
    private IOrderdetail _orderDetails;
    private IOrderstatus _orderStates;
    private IPaymenttype _paymentTypes;
    private IGendertype _genderTypes;
    private IProdcategory _productCategories;
    private IProdcolor _productColors;
    private IProduct _products;
    private IAddress _addresses;
    private IAddresstype _addressTypes;
    private ICity _cities;
    private ICountry _countries;
    private IDepartment _departments;
    private IClient _clients;
    private IContact _contacts;
    private IContacttype _contactTypes;
    private IToken _tokens;
    private IUser _users;
    private IUserrol _userRoles;


    public UnitOfWork(ApiNikeContext context)
    {
        _context = context;
    }

    public IOrder Orders
    {
        get
        {
            if (_orders == null)
            {
                _orders = new OrderRepo(_context);
            }
            return _orders;
        }
    }

    public IOrderdetail OrderDetails
    {
        get
        {
            if (_orderDetails == null)
            {
                _orderDetails = new OrderdetailRepo(_context);
            }
            return _orderDetails;
        }
    }

    public IOrderstatus OrderStates
    {
        get
        {
            if (_orderStates == null)
            {
                _orderStates = new OrderstatusRepo(_context);
            }
            return _orderStates;
        }
    }

    public IPaymenttype PaymentTypes
    {
        get
        {
            if (_paymentTypes == null)
            {
                _paymentTypes = new PaymenttypeRepo(_context);
            }
            return _paymentTypes;
        }
    }

    public IGendertype GenderTypes
    {
        get
        {
            if (_genderTypes == null)
            {
                _genderTypes = new GendertypeRepo(_context);
            }
            return _genderTypes;
        }
    }

    public IProdcategory ProductCategories
    {
        get
        {
            if (_productCategories == null)
            {
                _productCategories = new ProdcategoryRepo(_context);
            }
            return _productCategories;
        }
    }

    public IProdcolor ProductColors
    {
        get
        {
            if (_productColors == null)
            {
                _productColors = new ProdcolorRepo(_context);
            }
            return _productColors;
        }
    }

    public IProduct Products
    {
        get
        {
            if (_products == null)
            {
                _products = new ProductRepo(_context);
            }
            return _products;
        }
    }

    public IAddress Addresses
    {
        get
        {
            if (_addresses == null)
            {
                _addresses = new AddressRepo(_context);
            }
            return _addresses;
        }
    }

    public IAddresstype AddressTypes
    {
        get
        {
            if (_addressTypes == null)
            {
                _addressTypes = new AddresstypeRepo(_context);
            }
            return _addressTypes;
        }
    }

    public ICity Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepo(_context);
            }
            return _cities;
        }
    }

    public ICountry Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepo(_context);
            }
            return _countries;
        }
    }

    public IDepartment Departments
    {
        get
        {
            if (_departments == null)
            {
                _departments = new DepartmentRepo(_context);
            }
            return _departments;
        }
    }

    public IClient Clients
    {
        get
        {
            if (_clients == null)
            {
                _clients = new ClientRepo(_context);
            }
            return _clients;
        }
    }

    public IContact Contacts
    {
        get
        {
            if (_contacts == null)
            {
                _contacts = new ContactRepo(_context);
            }
            return _contacts;
        }
    }

    public IContacttype ContactTypes
    {
        get
        {
            if (_contactTypes == null)
            {
                _contactTypes = new ContacttypeRepo(_context);
            }
            return _contactTypes;
        }
    }

    public IToken Tokens
    {
        get
        {
            if (_tokens == null)
            {
                _tokens = new TokenRepo(_context);
            }
            return _tokens;
        }
    }
    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepo(_context);
            }
            return _users;
        }
    }
    public IUserrol UserRoles
    {
        get
        {
            if (_userRoles == null)
            {
                _userRoles = new UserrolRepo(_context);
            }
            return _userRoles;
        }
    }


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}