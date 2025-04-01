using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Library.Entities;
using AutoMapper;

namespace Aspiro.Extensions.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {
            CreateMap<Users,DTO.Users>().ReverseMap();
            CreateMap<DTO.UsersInput, Users>();
        }
    }
}
