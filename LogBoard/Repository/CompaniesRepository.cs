﻿using LogBoard.Models;
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
    }
}