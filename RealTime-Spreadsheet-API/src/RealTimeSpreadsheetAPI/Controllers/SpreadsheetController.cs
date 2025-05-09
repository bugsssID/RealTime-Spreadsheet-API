using Microsoft.AspNetCore.Mvc;
using RealTimeSpreadsheetAPI.Models;
using RealTimeSpreadsheetAPI.Services;
using System.Collections.Generic;

namespace RealTimeSpreadsheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpreadsheetController : ControllerBase
    {
        private readonly SpreadsheetService _spreadsheetService;

        public SpreadsheetController(SpreadsheetService spreadsheetService)
        {
            _spreadsheetService = spreadsheetService;
        }

        [HttpGet("{id}")]
        public ActionResult<SpreadsheetModel> GetSpreadsheet(int id)
        {
            var spreadsheet = _spreadsheetService.GetSpreadsheetById(id);
            if (spreadsheet == null)
            {
                return NotFound();
            }
            return Ok(spreadsheet);
        }

        [HttpPost]
        public ActionResult<SpreadsheetModel> CreateSpreadsheet([FromBody] SpreadsheetModel spreadsheetModel)
        {
            var createdSpreadsheet = _spreadsheetService.AddSpreadsheet(spreadsheetModel);
            return CreatedAtAction(nameof(GetSpreadsheet), new { id = createdSpreadsheet.Id }, createdSpreadsheet);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSpreadsheet(int id, [FromBody] SpreadsheetModel spreadsheetModel)
        {
            if (id != spreadsheetModel.Id)
            {
                return BadRequest();
            }

            var updated = _spreadsheetService.UpdateSpreadsheet(spreadsheetModel);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}