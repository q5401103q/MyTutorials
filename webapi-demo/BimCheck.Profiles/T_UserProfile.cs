using AutoMapper;
using BimCheck.Model.Dto;
using BimCheck.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Profiles
{
    public class T_UserProfile : Profile
    {
        public T_UserProfile()
        {
            CreateMap<T_User, T_UserDto>();
        }
    }
}
