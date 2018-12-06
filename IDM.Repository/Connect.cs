using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Repository
{
    class Connect
    {
        private static SqlConnection contodb = new SqlConnection(ConfigurationManager.ConnectionStrings["IDMConStr"].ConnectionString);

        public static SqlConnection ToDB
        {
            get
            {
                if (contodb != null)
                {
                    if (contodb.State == ConnectionState.Closed)
                    {
                        contodb.Open();
                    }
                    return contodb;
                }
                else
                {
                    contodb = new SqlConnection();
                    if (contodb.State == ConnectionState.Closed)
                    {
                        contodb.Open();
                    }
                    return contodb;
                }
            }
            set { contodb = value; }
        }
    }
}
