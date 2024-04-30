using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using VitagoraAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VitagoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzController : ControllerBase
    {
        [HttpGet] // Répond à une demande HTTP GET sur l'URL de base du contrôleur.
        public IEnumerable<Quizz> Get()
        {
            List<Quizz> _quizz = new List<Quizz>();
            string connectionString = @"Data Source=legumineuses.database.windows.net;Initial Catalog=SIO2024VitagoraLegumineusesAAEOEG;User ID=DEV;Password=Azerty@1"; ;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string selectQuery = "SELECT * FROM Quiz";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _quizz.Add(new Quizz
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            });
                        }
                    }
                }
                sqlConnection.Close();
            }
            return _quizz;
        }
    }
}
