#pragma warning disable CS1591
using LogBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LogBoard.Repository
{
    public class VisitedUrlsRepository
    {
        private readonly DatabaseService _databaseService;

        public VisitedUrlsRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        
        public List<VIsitedUrl> VisitedUrlByCategory(int id, string startDate, string endDate)
        {
            List<VIsitedUrl> visitedUrls = new List<VIsitedUrl>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "VisitedUrlByCategory";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VIsitedUrl vIsitedUrl = new VIsitedUrl();
                            vIsitedUrl.url = reader.GetString(0).Replace("https://www.fasoo.com/", "");
                            vIsitedUrl.count = reader.GetInt32(1);

                            visitedUrls.Add(vIsitedUrl);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }
            return visitedUrls;
        }

        public List<VIsitedUrl> VisitedUrlByIndustry(int id, string startDate, string endDate)
        {
            List<VIsitedUrl> visitedUrls = new List<VIsitedUrl>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "VisitedUrlByIndustry";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VIsitedUrl vIsitedUrl = new VIsitedUrl();
                            vIsitedUrl.url = reader.GetString(0).Replace("https://www.fasoo.com/", "");
                            vIsitedUrl.count = reader.GetInt32(1);

                            visitedUrls.Add(vIsitedUrl);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }
            return visitedUrls;
        }


        public List<VIsitedUrl> VisitedUrlByTechnology(string idStr, string startDate, string endDate)
        {
            List<VIsitedUrl> visitedUrls = new List<VIsitedUrl>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    // Procedure Execution
                    string procedureName = "VisitedUrlByTechnology";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idStr", idStr);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VIsitedUrl vIsitedUrl = new VIsitedUrl();
                            vIsitedUrl.url = reader.GetString(0).Replace("https://www.fasoo.com/", "");
                            vIsitedUrl.count = reader.GetInt32(1);

                            visitedUrls.Add(vIsitedUrl);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }
            return visitedUrls;
        }



    }
}
