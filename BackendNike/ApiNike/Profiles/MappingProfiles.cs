using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.BusinessMovements;
using ApiNike.Dtos.Get.Inventory;
using ApiNike.Dtos.Get.Location;
using ApiNike.Dtos.Get.Person;
using AutoMapper;
using Domain.Entities.BusinessMovements;
using Domain.Entities.Inventory;
using Domain.Entities.Location;
using Domain.Entities.Person;
using Domain.Entities.UserAuthenti;

namespace ApiNike.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Order, OrderDto>()
        .ReverseMap();
        CreateMap<Orderdetail, OrderdetailDto>()
        .ReverseMap();
        CreateMap<Orderstatus, OrderstatusDto>()
        .ReverseMap();
        CreateMap<Paymenttype, PaymenttypeDto>()
        .ReverseMap();
        CreateMap<Gendertype, GendertypeDto>()
        .ReverseMap();
        CreateMap<Prodcategory, ProdcategoryDto>()
        .ReverseMap();
        CreateMap<Prodcolor, ProdcolorDto>()
        .ReverseMap();
        CreateMap<Product, ProductDto>()
        .ReverseMap();
        CreateMap<Address, AddressDto>()
        .ReverseMap();
        CreateMap<Addresstype, AddresstypeDto>()
        .ReverseMap();
        CreateMap<City, CityDto>()
        .ReverseMap();
        CreateMap<Country, CountryDto>()
        .ReverseMap();
        CreateMap<Department, DepartmentDto>()
        .ReverseMap();
        CreateMap<Client, ClientDto>()
        .ReverseMap();
        CreateMap<Contact, ContactDto>()
        .ReverseMap();
        CreateMap<Contacttype, ContacttypeDto>()
        .ReverseMap();
    }
}