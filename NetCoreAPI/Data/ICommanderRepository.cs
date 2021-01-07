using System.Collections.Generic;
using NetCoreAPI.Model;

namespace NetCoreAPI.Data
{
    public interface ICommanderRepository
    {
        bool SaveChanges(); 
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
    }
}