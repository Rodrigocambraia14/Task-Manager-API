using AutoMapper;
using LawTech.Application.Models.Queries.Users.Get;
using LawTech.Application.Models.Queries.Users.List;
using LawTech.Context.Default.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Application.Models.Queries.Users
{
    public class UserQueryProfile : Profile
    {
        public UserQueryProfile()
        {
            CreateMap<User, ListUserQueryResponse>();

            CreateMap<User, GetUserQueryResponse>();
        }
    }
}
