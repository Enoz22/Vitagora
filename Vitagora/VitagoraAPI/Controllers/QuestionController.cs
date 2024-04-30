using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using VitagoraAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VitagoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        [HttpGet] // Répond à une demande HTTP GET sur l'URL de base du contrôleur.
        public IEnumerable<Question> Get()
        {
            List<Question> questions = new List<Question>();
            string connectionString = @"Data Source=legumineuses.database.windows.net;Initial Catalog=SIO2024VitagoraLegumineusesAAEOEG;User ID=DEV;Password=Azerty@1"; ;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string selectQuery = "SELECT * FROM Question";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new Question
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1)
                            });
                        }
                    }
                }
                sqlConnection.Close();
            }
            return questions;
        }


    }
}
