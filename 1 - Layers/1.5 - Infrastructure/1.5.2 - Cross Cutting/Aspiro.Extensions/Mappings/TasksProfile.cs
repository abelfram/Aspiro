using Aspiro.Library.Entities;
using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using AutoMapper;

namespace Aspiro.Extensions.Mappings
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Tasks, DTO.Tasks>().ReverseMap();
            CreateMap<DTO.TasksInput, Tasks>();
        }
    }
}
