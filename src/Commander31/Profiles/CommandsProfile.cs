using AutoMapper;
using Commmander31.Dtos;
using Commmander31.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Convert
            //Source -> Target
            CreateMap<Command, CommandReadDto>();//get

            CreateMap<CommandCreateDto, Command>();//Post
            CreateMap<CommandUpdateDto, Command>();//Put
            
            CreateMap<Command,CommandUpdateDto>();//Patch
            
        }
    }
}