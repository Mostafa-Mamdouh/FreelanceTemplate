using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Vendor.Portal.Code
{
    public class SqlHelper
    {
        public static SqlParameter CreateSqlParameter(string parameterName, SqlDbType sqlDbType, object value)
        {
            SqlParameter parameter = new SqlParameter(parameterName, sqlDbType)
            {
                IsNullable = true,
                Value = value ?? DBNull.Value,
                Direction = ParameterDirection.Input
            };
            return parameter;
        }
    }
}