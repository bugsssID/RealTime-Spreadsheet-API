using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealTimeSpreadsheetAPI.Models;
using RealTimeSpreadsheetAPI.Services;

namespace RealTimeSpreadsheetAPI.Tests.Services
{
    [TestClass]
    public class SpreadsheetServiceTests
    {
        private SpreadsheetService _spreadsheetService;

        [TestInitialize]
        public void Setup()
        {
            _spreadsheetService = new SpreadsheetService();
        }

        [TestMethod]
        public void AddSpreadsheet_ShouldAddSpreadsheet()
        {
            var spreadsheet = new SpreadsheetModel { Id = Guid.NewGuid(), Name = "Test Spreadsheet", Data = "Sample Data" };
            _spreadsheetService.AddSpreadsheet(spreadsheet);

            var result = _spreadsheetService.GetSpreadsheetById(spreadsheet.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(spreadsheet.Name, result.Name);
        }

        [TestMethod]
        public void GetSpreadsheetById_ShouldReturnCorrectSpreadsheet()
        {
            var spreadsheet = new SpreadsheetModel { Id = Guid.NewGuid(), Name = "Test Spreadsheet", Data = "Sample Data" };
            _spreadsheetService.AddSpreadsheet(spreadsheet);

            var result = _spreadsheetService.GetSpreadsheetById(spreadsheet.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(spreadsheet.Id, result.Id);
        }

        [TestMethod]
        public void UpdateSpreadsheet_ShouldUpdateExistingSpreadsheet()
        {
            var spreadsheet = new SpreadsheetModel { Id = Guid.NewGuid(), Name = "Test Spreadsheet", Data = "Sample Data" };
            _spreadsheetService.AddSpreadsheet(spreadsheet);

            spreadsheet.Name = "Updated Spreadsheet";
            _spreadsheetService.UpdateSpreadsheet(spreadsheet);

            var result = _spreadsheetService.GetSpreadsheetById(spreadsheet.Id);
            Assert.AreEqual("Updated Spreadsheet", result.Name);
        }
    }
}