using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RealTimeSpreadsheetAPI.Controllers;
using RealTimeSpreadsheetAPI.Models;
using RealTimeSpreadsheetAPI.Services;
using System.Collections.Generic;

namespace RealTimeSpreadsheetAPI.Tests.Controllers
{
    [TestClass]
    public class SpreadsheetControllerTests
    {
        private SpreadsheetController _controller;
        private Mock<ISpreadsheetService> _mockService;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<ISpreadsheetService>();
            _controller = new SpreadsheetController(_mockService.Object);
        }

        [TestMethod]
        public void GetSpreadsheet_ReturnsSpreadsheet_WhenExists()
        {
            // Arrange
            var spreadsheetId = 1;
            var spreadsheet = new SpreadsheetModel { Id = spreadsheetId, Name = "Test Spreadsheet", Data = "Sample Data" };
            _mockService.Setup(service => service.GetSpreadsheetById(spreadsheetId)).Returns(spreadsheet);

            // Act
            var result = _controller.GetSpreadsheet(spreadsheetId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(spreadsheet, result.Value);
        }

        [TestMethod]
        public void CreateSpreadsheet_ReturnsCreatedSpreadsheet()
        {
            // Arrange
            var newSpreadsheet = new SpreadsheetModel { Name = "New Spreadsheet", Data = "New Data" };
            _mockService.Setup(service => service.AddSpreadsheet(newSpreadsheet)).Returns(newSpreadsheet);

            // Act
            var result = _controller.CreateSpreadsheet(newSpreadsheet) as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newSpreadsheet, result.Value);
        }

        [TestMethod]
        public void UpdateSpreadsheet_ReturnsUpdatedSpreadsheet_WhenExists()
        {
            // Arrange
            var spreadsheetId = 1;
            var updatedSpreadsheet = new SpreadsheetModel { Id = spreadsheetId, Name = "Updated Spreadsheet", Data = "Updated Data" };
            _mockService.Setup(service => service.UpdateSpreadsheet(updatedSpreadsheet)).Returns(updatedSpreadsheet);

            // Act
            var result = _controller.UpdateSpreadsheet(spreadsheetId, updatedSpreadsheet) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedSpreadsheet, result.Value);
        }
    }
}