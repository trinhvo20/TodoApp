using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private IConfiguration _configuration;
        public TodoAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get all notes
        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes()
        {
            string query = "select * from dbo.Notes";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("connectionString");
            SqlDataReader myReader;

            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }

        // Create a note
        [HttpPost]
        [Route("AddNotes")]
        public JsonResult AddNotes([FromForm] string newNotes)
        {
            string query = "insert into dbo.Notes values(@newNotes)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("connectionString");
            SqlDataReader myReader;

            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@newNotes", newNotes);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("Added Successfully!");
        }

        // Delete a note
        [HttpDelete]
        [Route("DeleteNotes")]
        public JsonResult DeleteNotes(int id)
        {
            string query = "delete from dbo.Notes where id=@id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("connectionString");
            SqlDataReader myReader;

            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("Deleted Successfully!");
        }
    }
}
