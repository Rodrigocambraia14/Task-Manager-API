using AutoMapper;
using LawTech.Application.Models.Commands.Tasks.Create;
using LawTech.Application.Models.Commands.Tasks.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawTech.Application.Models.Commands.Tasks
{
    public class TaskCommandProfile : Profile
    {
        public TaskCommandProfile()
        {
            CreateMap<CreateTaskCommand, Context.Default.Entities.Task>();

            CreateMap<UpdateTaskCommand, Context.Default.Entities.Task>();
        }
    }
}
