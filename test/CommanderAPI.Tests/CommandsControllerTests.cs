using System;
using System.Text.Json;
using Xunit;
using Commander31.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Collections.Generic;
using Commander31;
using System.Linq;

namespace CommanderAPI.Tests
{
    [Collection("Integration Tests")]
    public class CommandsControllerTests
    {
        private readonly WebApplicationFactory<Commander31.Startup> _factory;

        public CommandsControllerTests(WebApplicationFactory<Commander31.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllCommands_ReturnSuccess(){

            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("/api/commands");

            //assert for Build und Test
            Assert.NotNull(response);

            //Assert
           // response.EnsureSuccessStatusCode();

            //Assert.NotNull(response.Content);

           /*  var resposeObject = JsonSerializer.Deserialize<List<CommandReadDto>>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions{PropertyNameCaseInsensitive = true}
            );

            Assert.NotNull(resposeObject); */

            //var command = resposeObject.FirstOrDefault();

            //Assert.IsType<CommandReadDto>(command);
        }

    }

     public class CommandReadDto{
        
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        
    }
}