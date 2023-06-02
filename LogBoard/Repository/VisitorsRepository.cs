using LogBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LogBoard.Repository
{
    public class VisitorsRepository
    {
        private readonly DatabaseService _databaseService;

        public VisitorsRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<CategoryVisitor> VisitorsByCategory(int count, string startDate, string endDate)
        {
            string result = string.Empty;
            List<CategoryVisitor> visitors = new List<CategoryVisitor>();


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
                            CategoryVisitor visitor = new CategoryVisitor();
                            visitor.category = reader.GetString(0);
                            visitor.count = reader.GetInt32(1);

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
