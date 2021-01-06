using AutoMapper;
using NetCoreAPI.DTOs;
using NetCoreAPI.Model;

namespace NetCoreAPI.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
        
    }
}