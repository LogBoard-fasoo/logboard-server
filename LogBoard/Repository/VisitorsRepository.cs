using LogBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogBoard.Repository
{
    public class VisitorsRepository
    {
        private readonly DatabaseService _databaseService;

        public VisitorsRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<PieChartModel> VisitorsByCategory(int count, string startDate, string endDate)
        {
            List<PieChartModel> visitors = new List<PieChartModel>();


            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "VisitorsByCategory";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PieChartModel visitor = new PieChartModel();
                            visitor.id = reader.GetString(0);
                            visitor.value = reader.GetInt32(1);

                            visitors.Add(visitor);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return visitors;
        }


        public List<PieChartModel> VisitorsByIndustry(int count, string startDate, string endDate)
        {
            List<PieChartModel> visitors = new List<PieChartModel>();


            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    string procedureName = "VisitorsByIndustry";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PieChartModel visitor = new PieChartModel();
                            visitor.id = reader.GetString(0);
                            visitor.value = reader.GetInt32(1);

                            visitors.Add(visitor);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return visitors;
        }


        public List<PieChartModel> VisitorsByTechnology(int count, string startDate, string endDate)
        {
            List<PieChartModel> visitors = new List<PieChartModel>();


            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    string procedureName = "VisitorsByTechnology";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PieChartModel visitor = new PieChartModel();
                            visitor.id = reader.GetString(0);
                            visitor.value = reader.GetInt32(1);

                            visitors.Add(visitor);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return visitors;
        }
        


    }
}
