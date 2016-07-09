using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopStudent.ExerciseJoy.Entities;
using TopStudent.ExerciseJoy.IDAL;
using MySql.Data.MySqlClient;

namespace TopStudent.ExerciseJoy.MysqlDAL
{
    public class ExponentialDal : IExponential
    {
        public Exponential GetExponentialByID(string id, IDbConnection conn)
        {
            Exponential exponential = null;
            Guid guidId = Guid.Empty;
            bool isValidGuid = Guid.TryParse(id, out guidId);
            if (string.IsNullOrEmpty(id) || !isValidGuid || null == conn)
            {
                throw new ArgumentException("invalid argument passed in");
            }

            try
            {

                using (MySqlConnection mysqlConn = conn as MySqlConnection)
                {
                    if (mysqlConn.State != ConnectionState.Open)
                    {
                        mysqlConn.Open();
                    }

                    string sqlCmd = "select * from Exponentials where ID=@ID";
                    MySqlCommand cmd = new MySqlCommand(sqlCmd, mysqlConn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            exponential = new Exponential();
                            exponential.ID = reader["ID"] == DBNull.Value ? string.Empty : reader["ID"].ToString();
                            exponential.BaseID = reader["BaseID"] == DBNull.Value ? string.Empty : reader["BaseID"].ToString();
                            exponential.PowerID = reader["PowerID"] == DBNull.Value ? string.Empty : reader["PowerID"].ToString();
                            exponential.BaseType = reader["BaseType"] == DBNull.Value ? -1 : Convert.ToInt32(reader["BaseType"]);
                            exponential.PowerType= reader["PowerType"] == DBNull.Value ? -1 : Convert.ToInt32(reader["PowerType"]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return exponential;

        }
    }
}
