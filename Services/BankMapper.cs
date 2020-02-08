using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Banky.Models.Entity;

namespace Banky.Services
{
    public class BankMapper : Profile
    {
        public BankMapper()
        {

            CreateMap<Users, Usermodel>()
                .ReverseMap();
          
    }
    }

    }
