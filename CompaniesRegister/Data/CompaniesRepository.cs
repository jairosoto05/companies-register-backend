using CompaniesRegister.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;



namespace CompaniesRegister.Data
{
    public class CompaniesRepository
    {
        private readonly string _connectionString;

        public CompaniesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CSConectionSQLServer");
        }
        public async Task<List<Company>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getCompanies", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Company>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Company MapToValue(SqlDataReader reader)
        {
            return new Company()
            {
                Id = (int)reader["Id"],
                rnc = (string)reader["rnc"],
                name = (string)reader["name"],
                tradeName = (string)reader["tradeName"],
                category = (string)reader["category"],
                paymentScheme = (string)reader["paymentScheme"],
                state = (string)reader["state"],
                economicActivity = (string)reader["economicActivity"],
                localManagement = (string)reader["localManagement"],
                createdDate = (DateTime)reader["createdDate"]
            };
        }

        public async Task<Company> GetByRNC(string rnc)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getCompany", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rnc", rnc));
                    Company response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task Insert(Company value)
        {
            
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createCompany", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@rnc", value.rnc));
                        cmd.Parameters.Add(new SqlParameter("@name", value.name));
                        cmd.Parameters.Add(new SqlParameter("@tradeName", value.tradeName));
                        cmd.Parameters.Add(new SqlParameter("@category", value.category));
                        cmd.Parameters.Add(new SqlParameter("@paymentScheme", value.paymentScheme));
                        cmd.Parameters.Add(new SqlParameter("@state", value.state));
                        cmd.Parameters.Add(new SqlParameter("@economicActivity", value.economicActivity));
                        cmd.Parameters.Add(new SqlParameter("@localManagement", value.localManagement));                       
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return;
                    }
                }
            }
        }

        public async Task UpdateByRNC(string rnc, Company value)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("updateCompany", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rnc", rnc));
                    cmd.Parameters.Add(new SqlParameter("@name", value.name));
                    cmd.Parameters.Add(new SqlParameter("@tradeName", value.tradeName));
                    cmd.Parameters.Add(new SqlParameter("@category", value.category));
                    cmd.Parameters.Add(new SqlParameter("@paymentScheme", value.paymentScheme));
                    cmd.Parameters.Add(new SqlParameter("@state", value.state));
                    cmd.Parameters.Add(new SqlParameter("@economicActivity", value.economicActivity));
                    cmd.Parameters.Add(new SqlParameter("@localManagement", value.localManagement));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task DeleteByRNC(string rnc)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("deleteCompany", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rnc", rnc));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}
