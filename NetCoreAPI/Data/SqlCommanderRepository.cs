using System;
using System.Collections.Generic;
using System.Linq;
using NetCoreAPI.Model;

namespace NetCoreAPI.Data
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepository(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentException(null, nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void UpdateCommand(Command command)
        {
            //Nothing
        }
    }
}