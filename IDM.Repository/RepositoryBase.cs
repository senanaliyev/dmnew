using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IDM.Repository
{
    public class RepositoryBase : IRepository
    {
        public int IUD(string query, CommandType cmdType)
        {
            SqlCommand cmd = null;
            try
            {
                using (cmd = MyQuery(query, cmdType))
                {
                    AddParamsToQuery(cmd);
                    int result = cmd.ExecuteNonQuery();
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return 0;
        }
        public DataTable GetList(string query, CommandType cmdType)
        {
            try
            {
                using (SqlCommand cmd = MyQuery(query, cmdType))
                {
                    AddParamsToQuery(cmd);
                    DataTable dt = new DataTable();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private SqlCommand MyQuery(string query, CommandType cmdType)
        {
            SqlCommand cmd = Connect.ToDB.CreateCommand();
            cmd.CommandText = query;
            cmd.CommandType = cmdType;
            return cmd;
        }
        List<SqlParameter> Parameters = new List<SqlParameter>();
        public void AddInputParameters(string paramName, object paramValue)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            Parameters.Add(parameter);
        }
        public void AddOutputParameters(string paramName, object paramValue)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            parameter.Direction = ParameterDirection.Output;
            Parameters.Add(parameter);
        }
        private void AddParamsToQuery(SqlCommand cmd)
        {
            cmd.Parameters.AddRange(Parameters.ToArray());
        }
        public object GetParamValue(string paramName)
        {
            foreach (var item in Parameters)
            {
                if (item.ParameterName == paramName)
                {
                    return item.Value.ToString();
                }
            }
            return null;
        }
    }
}
