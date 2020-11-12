using Commmander31.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander31.Data
{
    public class CommanderContext:DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt): base(opt)
        {

        }

        public DbSet<Command> Commands {get; set;}
    }
}