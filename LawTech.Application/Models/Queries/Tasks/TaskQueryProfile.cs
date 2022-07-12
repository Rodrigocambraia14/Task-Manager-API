using AutoMapper;
using LawTech.Application.Models.Queries.Tasks.List;
using LawTech.Context.Default.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LawTech.Context.Default.Entities.Task;

namespace LawTech.Application.Models.Queries.Tasks
{
    public class TaskQueryProfile : Profile
    {
        public TaskQueryProfile()
        {
            CreateMap<Task, ListTaskQueryResponse>();
        }
    }
}
