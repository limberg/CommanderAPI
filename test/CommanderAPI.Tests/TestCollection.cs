using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CommanderAPI.Tests
{
    [CollectionDefinition("Integration Tests")]
   public class TestCollection : ICollectionFixture<WebApplicationFactory<Commander31.Startup>>
   {

   }
}
