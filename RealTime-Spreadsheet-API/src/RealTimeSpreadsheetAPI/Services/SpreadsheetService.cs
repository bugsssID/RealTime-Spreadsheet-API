using System.Collections.Generic;
using System.Linq;

namespace RealTimeSpreadsheetAPI.Services
{
    public class SpreadsheetService
    {
        private readonly List<SpreadsheetModel> _spreadsheets = new List<SpreadsheetModel>();

        public void AddSpreadsheet(SpreadsheetModel spreadsheet)
        {
            _spreadsheets.Add(spreadsheet);
        }

        public SpreadsheetModel GetSpreadsheetById(int id)
        {
            return _spreadsheets.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateSpreadsheet(SpreadsheetModel updatedSpreadsheet)
        {
            var existingSpreadsheet = GetSpreadsheetById(updatedSpreadsheet.Id);
            if (existingSpreadsheet != null)
            {
                existingSpreadsheet.Name = updatedSpreadsheet.Name;
                existingSpreadsheet.Data = updatedSpreadsheet.Data;
            }
        }

        public IEnumerable<SpreadsheetModel> GetAllSpreadsheets()
        {
            return _spreadsheets;
        }
    }
}