using System.Collections.Generic;
using NetCoreAPI.Model;

namespace NetCoreAPI.Data
{
    public interface ICommanderRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}