using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            Repository.AddSurvey(new Survey
            {
                SurveyId = 1,
                FirstName = "John",
                LastName = "Smith",
                City = "London",
                Country = "England",
                Rating = 3,
                Comment = "Average site",
                SurveyDateTime = new DateTime(2012, 6, 12)
            });

            Repository.AddSurvey(new Survey
            {
                SurveyId = 2,
                FirstName = "David",
                LastName = "Brown",
                City = "Birmingham",
                Country = "England",
                Rating = 1,
                Comment = "Rubbish site",
                SurveyDateTime = new DateTime(2014, 9, 3)
            });

            Repository.AddSurvey(new Survey
            {
                SurveyId = 3,
                FirstName = "Michael",
                LastName = "Sleep",
                City = "Perth",
                Country = "Australia",
                Rating = 5,
                Comment = "Excellent site",
                SurveyDateTime = new DateTime(2012, 6, 12)
            });
        }

        // This test verifies that a survey is added correctly
        [Fact]
        public void AddSurveyTest()
        {
            // Arrange
            var homeController = new HomeController(Repository);

            // Act
            homeController.TakeSurvey("Peter", "Atkins", "Rome", "Italy", "2", "Boring site");

            // Assert
            Assert.Equal("Peter", Repository.Surveys[^1].FirstName);
            Assert.Equal("Atkins", Repository.Surveys[^1].LastName);
            Assert.Equal("Rome", Repository.Surveys[^1].City);
            Assert.Equal("Italy", Repository.Surveys[^1].Country);
            Assert.Equal(2, Repository.Surveys[^1].Rating);
            Assert.Equal("Boring site", Repository.Surveys[^1].Comment);
            // Put today's date below to test
            Assert.Equal(new DateTime(2019, 12, 5), Repository.Surveys[^1].SurveyDateTime.Date);
            // Lets also ensure that we now have a total of four surveys in our repository
            Assert.Equal(4, Repository.Surveys.Count);
        }

        [Fact]
        public void GetSurveysByCountriesTest()
        {
            // Arrange
            var homeController = new HomeController(Repository);

            // Act
            // Get surveys with a countries of Belgium and England
            var result = (ViewResult)homeController.SearchByCountry("Belgium");
            var surveysBelgium = ((IEnumerable<Survey>)result.Model).ToList();
            result = (ViewResult)homeController.SearchByCountry("England");
            var surveysEngland = ((IEnumerable<Survey>)result.Model).ToList();

            // Assert
            // The surveys from Belgium should be empty
            Assert.Empty(surveysBelgium);
            // There should be 2 surveys from England
            Assert.Equal(2, surveysEngland.Count);
            // Check that they are John Smith and David Brown
            Assert.Equal("John", surveysEngland[0].FirstName);
            Assert.Equal("Smith", surveysEngland[0].LastName);
            Assert.Equal("David", surveysEngland[1].FirstName);
            Assert.Equal("Brown", surveysEngland[1].LastName);
        }

        [Fact]
        public void GetSurveysByRatingsTest()
        {
            // Arrange
            var homeController = new HomeController(Repository);

            // Act
            // Get surveys with a ratings of 4 and 5
            var result = (ViewResult) homeController.SearchByRating(4);
            var surveysRating4 = ((IEnumerable<Survey>) result.Model).ToList();
            result = (ViewResult) homeController.SearchByRating(5);
            var surveysRating5 = ((IEnumerable<Survey>) result.Model).ToList();

            // Assert
            // The surveys with a rating of 4 should be empty
            Assert.Empty(surveysRating4);
            // There should be only one survey of a rating of 5
            Assert.Single(surveysRating5);
            // Check that it is Michael Sleep
            Assert.Equal("Michael", surveysRating5[0].FirstName);
            Assert.Equal("Sleep", surveysRating5[0].LastName);
        }
    }
}
