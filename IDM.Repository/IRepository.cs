using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IDM.Repository
{
    interface IRepository
    {
        int IUD(string query, CommandType cmdType);
        DataTable GetList(string query, CommandType cmdType);
    }
}
