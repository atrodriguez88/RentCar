using AutoMapper;
using RentCar.Dtos;
using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Brand, BrandDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CarDto, Car>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}