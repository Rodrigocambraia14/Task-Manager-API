using AutoMapper;
using LawTech.Application.Models.Queries.Users.Get;
using LawTech.Application.Models.Queries.Users.List;
using LawTech.Context.Default.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LawTech.Context.Default.Entities.Task;

namespace LawTech.Application.Models.Queries.Users
{
    public class UserQueryProfile : Profile
    {
        public UserQueryProfile()
        {
            //list mapping
            CreateMap<User, ListUserQueryResponse>();

            //get mapping

            CreateMap<User, GetUserQueryResponse>();

            CreateMap<UserLogin, GetUserLoginResponse>();

            CreateMap<Task, GetUserTaskResponse>();
        }
    }
}
