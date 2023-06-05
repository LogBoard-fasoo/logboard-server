﻿using LogBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
                            type.index = reader.GetInt32(0);
                            type.type = reader.GetString(1);

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
                            type.index = reader.GetInt32(0);
                            type.type = reader.GetString(1);

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
                            type.index = reader.GetInt32(0);
                            type.type = reader.GetString(1);

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


    }
}
