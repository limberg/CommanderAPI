using System.Collections.Generic;
using AutoMapper;
using Commander31.Data;
using Commmander31.Dtos;
using Commmander31.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander31.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            IEnumerable<Command> commandItems = _repository.GetAllCommands();
            
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //Get api/commands/{id}s
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto > CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commadModel = _mapper.Map<Command>(commandCreateDto);//Create mapper

            _repository.CreateCommand(commadModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commadModel);//Get Mapper

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
           
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();

            _mapper.Map(commandUpdateDto, commandModelFromRepo);  //Update mapper  

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();        
        }

        //PATCH api/commands({id})
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commadModelFromRepo = _repository.GetCommandById(id);

            if (commadModelFromRepo == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commadModelFromRepo); //Convert commandModelFromRepo to CommandUpdateDto

            patchDoc.ApplyTo(commandToPatch, ModelState); //Partial Update patchDoc to commandToPatch

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commadModelFromRepo); //commandToPatch to commandModelFrom Repo

            _repository.UpdateCommand(commadModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commadModelFromRepo = _repository.GetCommandById(id);

            if (commadModelFromRepo == null)
                return NotFound();

            _repository.DeleteCommand(commadModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }

    }
}