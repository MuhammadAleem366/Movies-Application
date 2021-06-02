using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVCApp.Dtos;
using MVCApp.Models;
namespace MVCApp.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to Dtos
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<Genre, GenresDto>();

            //Dtos to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto,Movie>();
        }

    }
}