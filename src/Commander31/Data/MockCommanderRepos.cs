
using System.Collections.Generic;
using Commmander31.Models;

namespace Commander31.Data
{
    public class MockCommanderRepos : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command> { 
                new Command(){ Id = 1, HowTo = "Herman", Line= "soap", Platform="Nose"},
                new Command(){ Id = 2, HowTo = "Herman", Line= "soap", Platform="Nose"}
            };
        }

        public Command GetCommandById(int id)
        {
           return new Command(){ Id = 1, HowTo = "Herman", Line= "soap", Platform="Nose"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}
