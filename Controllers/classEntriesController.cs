using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gradeDistributionMiddleware.Controllers
{ 
    public class classEntriesController : ControllerBase
    {
        private readonly petaPocoDBClass _database;

        public classEntriesController(petaPocoDBClass database)
        {
            _database = database;
        }

        [HttpGet]
        [Route("api/classEntries")]
        public IActionResult GetAllEntries() 
        {
            try
            {
                var table = _database.GetAllData("[dbo].[classEntries+]");
                return Ok(table);
            }
            catch (Exception ex)
            {
                // Extract the error message from the exception
                var errorMessage = ex.Message;

                // Return a user-friendly error response with the error message
                return StatusCode(500, new {Message = errorMessage});
            }

        }


        [HttpPost]
        [Route("api/classEntries")]
        public IActionResult InsertEntry([FromBody] dbo_classEntries data) 
        {
            if (data == null)
            {
                return BadRequest("Data is null");
            }

            try
            {
                _database.InsertData("dbo.classEntries", "entry_id", data);

                return Ok("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
