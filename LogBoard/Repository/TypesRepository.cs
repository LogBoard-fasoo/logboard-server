#pragma warning disable CS1591
using LogBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Type = LogBoard.Models.Type;

namespace LogBoard.Repository
{
    public class TypesRepository
    {
        private readonly DatabaseService _databaseService;

        public TypesRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<Type> CategoryTypes()
        {
            List<Type> types = new List<Type>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {
                

                try
                {
                    // Procedure Execution
                    string procedureName = "CategoryTypes";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Type type = new Type();
                            type.value = reader.GetInt32(0);
                            type.label = reader.GetString(1);

                            types.Add(type);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return types;
        }

        public List<Type> IndustryTypes()
        {
            List<Type> types = new List<Type>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {


                try
                {
                    // Procedure Execution
                    string procedureName = "IndustryTypes";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Type type = new Type();
                            type.value = reader.GetInt32(0);
                            type.label = reader.GetString(1);

                            types.Add(type);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return types;
        }


        public List<Type> TechnologyTypes()
        {
            List<Type> types = new List<Type>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {


                try
                {
                    // Procedure Execution
                    string procedureName = "TechnologyTypes";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Type type = new Type();
                            type.value = reader.GetInt32(0);
                            type.label = reader.GetString(1);

                            types.Add(type);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return types;
        }

        public List<Type> CompanyTypes()
        {
            List<Type> types = new List<Type>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {


                try
                {
                    // Procedure Execution
                    string procedureName = "CompanyTypes";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Type type = new Type();
                            type.value = reader.GetInt32(0);
                            type.label = reader.GetString(1);

                            types.Add(type);
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return types;
        }

        public List<Type> URLTypes()
        {
            List<Type> types = new List<Type>();

            using (IDbConnection conn = _databaseService.GetDbConnection())
            {


                try
                {
                    // Procedure Execution
                    string procedureName = "URLTypes";
                    MySqlCommand cmd = new MySqlCommand(procedureName, (MySqlConnection)conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var index = 1;
                        while (reader.Read())
                        {
                            Type type = new Type();
                            type.value = index;
                            type.label = reader.GetString(0).Replace("https://www.fasoo.com/","");

                            types.Add(type);
                            index++;
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while running the procedure: " + ex.Message);
                }
            }

            return types;
        }


    }
}
