using System.Collections.Generic;
using NetCoreAPI.Model;

namespace NetCoreAPI.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>()
            {
                new() {Id = 0, Name = "Test Command", HowTo = "Use it for test", Platform = "Mac"},
                new() {Id = 1, Name = "New Command", HowTo = "Use it for fun", Platform = "Mac"}
            };
        }
 
        public Command GetCommandById(int id)
        {
            return new() {Id = 0, Name = "Test Command", HowTo = "Use it for test", Platform = "Mac"};
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}