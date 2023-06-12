using LogBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogBoard.Repository
{
    public class CompaniesRepository
    {
        private readonly DatabaseService _databaseService;

        public CompaniesRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<Company> CompaniesVisitedRank(string startDate, string endDate)
        {
            List<Company> companies = new List<Company>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "CompaniesVisitedRank";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int index = 1;
                        while (reader.Read())
                        {
                            Company company = new Company();
                            company.rank = index;
                            company.count = reader.GetInt32(0);
                            company.name = reader.GetString(1);
                            company.domain = reader.IsDBNull(2) ? null : reader.GetString(2);
                            company.description = reader.IsDBNull(3) ? null : reader.GetString(3);
                            company.revenueRange = reader.IsDBNull(4) ? null : reader.GetString(4);
                            company.country = reader.IsDBNull(5) ? null : reader.GetString(5);
                            company.foundedYear = reader.IsDBNull(6) ? null : reader.GetInt32(6).ToString();
                            company.employeeRange = reader.IsDBNull(7) ? null : reader.GetString(7);
                            company.industry = reader.GetString(8);
                            company.categories = reader.GetString(9).Split(", ");
                            company.technologies = reader.GetString(10).Split(", ");

                            companies.Add(company);
                            index++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }
            return companies;
        }
        
        public List<PieChartModel> InterestedProductsByCompany(int companyId, string startDate, string endDate)
        {
            List<PieChartModel> interestedProducts = new List<PieChartModel>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "InterestedProductsByCompany";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@companyid", companyId);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PieChartModel data = new PieChartModel();
                            data.id = reader.GetString(0);
                            data.value = reader.GetInt32(1);

                            interestedProducts.Add(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }
            return interestedProducts;

        }

        public List<PieChartModel> InterestedCategoryByCompany(int companyId, string startDate, string endDate)
        {
            List<PieChartModel> interestedCategory = new List<PieChartModel>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "InterestedCategoryByCompany";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@companyid", companyId);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PieChartModel data = new PieChartModel();
                            data.id = reader.GetString(0);
                            data.value = reader.GetInt32(1);

                            interestedCategory.Add(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }
            return interestedCategory;

        }

        public CompanyDeatil CompanyInfo(int companyId)
        {
            CompanyDeatil company = new CompanyDeatil();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "CompanyInfo";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@companyid", companyId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            company.companyId = reader.GetInt32(0);
                            company.name = reader.GetString(1);
                            company.domain = reader.GetString(2);
                            company.domain = reader.IsDBNull(2) ? null : reader.GetString(2);
                            company.foundedYear = reader.IsDBNull(3) ? null : reader.GetString(3);
                            company.description = reader.IsDBNull(4) ? null : reader.GetString(4);
                            company.revenueRange = reader.IsDBNull(5) ? null : reader.GetString(5);
                            company.employeeRange = reader.IsDBNull(6) ? null : reader.GetString(6);
                            company.country = reader.GetString(7);
                            company.industry = reader.GetString(8);
                            company.categories = reader.GetString(9).Split(", ");
                            company.technologies = reader.GetString(10).Split(", ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return company;
        }

    }
}
