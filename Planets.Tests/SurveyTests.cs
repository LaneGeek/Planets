using System;
using Planets.Controllers;
using Planets.Models;
using Xunit;

namespace Planets.Tests
{
    public class SurveyTests
    {
        public IRepository Repository = new FakeRepository();

        public SurveyTests()
        {
            // Fill the empty repository with data for testing
        }

        [Fact]
        public void AddSurveyTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }
    }
}
