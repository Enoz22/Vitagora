using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using VitagoraAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VitagoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        [HttpGet] // Répond à une demande HTTP GET sur l'URL de base du contrôleur.
        public IEnumerable<Answer> Get()
        {
            List<Answer> _answers = new List<Answer>();
            string connectionString = @"Data Source=legumineuses.database.windows.net;Initial Catalog=SIO2024VitagoraLegumineusesAAEOEG;User ID=DEV;Password=Azerty@1";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string selectQuery = "SELECT * FROM Answer";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _answers.Add(new Answer
                            {
                                Id = reader.GetInt32(0),
                                Content = reader.GetString(1)
                            });
                        }
                    }
                }
                sqlConnection.Close();
            }
            return _answers;
        }

    }
}
