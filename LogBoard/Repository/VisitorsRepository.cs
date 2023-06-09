﻿#pragma warning disable CS1591
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

        public List<GraphChartModel> WeeklyTrendsByCompany(int[] companyIds, string startDate, string endDate)
        {

            List<GraphChartModel> graphChartModels = new List<GraphChartModel>();

            foreach (int companyId in companyIds)
            {
                GraphChartModel graphChart = new GraphChartModel();
                graphChart.data = new List<Data>(); // data 속성 초기화

                using (IDbConnection conn = _databaseService.GetDbConnection())
                {
                    try
                    {
                        string companyNameQuery = "SELECT company_name FROM wp_clearbit_company WHERE company_id = @companyId";
                        MySqlCommand companyNameCmd = new MySqlCommand(companyNameQuery, (MySqlConnection)conn);
                        companyNameCmd.Parameters.AddWithValue("@companyId", companyId);

                        string companyName = string.Empty;

                        using (MySqlDataReader companyNameReader = companyNameCmd.ExecuteReader())
                        {
                            if (companyNameReader.Read())
                            {
                                companyName = companyNameReader.GetString(0);
                            }
                        }
                        graphChart.id = companyName;


                        string procedureName = "WeeklyTrendsByCompany";
                        MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Data data = new Data();
                                data.x = DateTime.TryParse(reader.GetString(0), out DateTime dt) ? dt.ToString("M\\/d") : "날짜 형식이 잘못되었습니다.";
                                data.y = reader.GetInt32(1);


                                graphChart.data.Add(data);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error while retrieving the company name: " + ex.Message);
                    }


                }

                graphChartModels.Add(graphChart);
            }



            return graphChartModels;
        }

        public GraphChartModel WeeklyTrendsByURL(string url, string startDate, string endDate)
        {
            GraphChartModel graphChart = new GraphChartModel();
            graphChart.data = new List<Data>(); // data 속성 초기화

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                try
                {
                    string procedureName = "WeeklyTrendsByURL";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@url", url);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Data data = new Data();
                            data.x = DateTime.TryParse(reader.GetString(0), out DateTime dt) ? dt.ToString("M\\/d") : "날짜 형식이 잘못되었습니다.";
                            data.y = reader.GetInt32(1);


                            graphChart.data.Add(data);
                        }
                        graphChart.id = url;
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while retrieving the company name: " + ex.Message);
                }


            }

            return graphChart;
        }

    }
}
