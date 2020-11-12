using System;
using System.Collections.Generic;
using System.Linq;
using Commmander31.Models;

namespace Commander31.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof (cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
           if(cmd == null)
            {
                throw new ArgumentNullException(nameof (cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
           //Nothing AutoMapper mach die Update

           
         /*  var entry = _context.Entry(cmd);
          entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified; // EntryState.Modified;
          _context.SaveChanges(); */
        }
    }
}