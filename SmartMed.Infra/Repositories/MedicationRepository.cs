using Dapper;
using Microsoft.Extensions.Configuration;
using SmartMed.Domain.Entities;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;

namespace SmartMed.Infra.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly IConfiguration _config;
        private string connectionString = string.Empty;

        public MedicationRepository(IConfiguration config)
        {
            _config = config;
            connectionString = config.GetSection("ConnectionStrings").GetSection("SmartMed").Value;
        }
        public async Task<IEnumerable<Medication>> GetAsync()
        {
            using (var connDB = new SqlConnection(connectionString))
            {
                var query = $"SELECT Id, Name, Quantity, CreationDate " +
                            $"FROM Medication ";

                var medications = await connDB.QueryAsync<Medication>(query);

                if (medications == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return medications;
            }
        }

        public async Task<bool> CreateAsync(Medication medication)
        {
            using (var connDB = new SqlConnection(connectionString))
            {
                var param = new
                {
                    Name = medication.Name,
                    Quantity = medication.Quantity,
                    CreationDate = medication.CreationDate
                };

                var query = $"INSERT INTO Medication " +
                            $"(Name, Quantity, CreationDate) " +
                            $"VALUES (@Name, @Quantity, @CreationDate) ";

                var created = await connDB.ExecuteAsync(query, param);

                return created == 1;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var connDB = new SqlConnection(connectionString))
            {
                var query = $"DELETE FROM Medication " +
                            $"WHERE Id = '{id}'; ";

                var deleted = await connDB.ExecuteAsync(query);

                return deleted >= 1;
            }
        }
    }
}
