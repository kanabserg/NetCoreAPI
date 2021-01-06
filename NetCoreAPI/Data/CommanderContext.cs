using Microsoft.EntityFrameworkCore;
using NetCoreAPI.Model;

namespace NetCoreAPI.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options): base(options)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}