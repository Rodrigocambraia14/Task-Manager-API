using AutoMapper;
using LawTech.Application.Models.Commands.Users.Register;
using LawTech.Context.Default.Entities;

namespace LawTech.Application.Models.Commands.Users
{
    public class UserCommandProfile : Profile
    {
        public UserCommandProfile()
        {
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
