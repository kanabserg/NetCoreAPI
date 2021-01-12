using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreAPI.Data;
using NetCoreAPI.DTOs;
using NetCoreAPI.Model;

namespace NetCoreAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CommandsController> _logger;

        public CommandsController(ICommanderRepository repository, IMapper mapper, ILogger<CommandsController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            _logger.LogInformation("Get All Commands Call");
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id )
        {
            var commandItem = _repository.GetCommandById(id);
            return commandItem != null ? Ok(_mapper.Map<CommandReadDto>(commandItem)) : NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandDto)
        {
            var commandModel = _mapper.Map<Command>(commandDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {commandReadDto.Id}, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandFromRepo); 
            
            _repository.UpdateCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandFromRepo);
            patchDocument.ApplyTo(commandToPatch,ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandFromRepo);

            _repository.UpdateCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }
            
            _repository.DeleteCommand(commandFromRepo);
            
            return NoContent();
        }
    }
} 