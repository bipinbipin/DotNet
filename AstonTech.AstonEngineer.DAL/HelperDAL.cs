using System.Data;
using System.Data.SqlClient;

namespace AstonTech.AstonEngineer
{
    public static class HelperDAL
    {
        public static SqlParameter GetReturnParameterInt(string returnParameterName)
        {
            SqlParameter returnParameter = new SqlParameter();
            returnParameter.ParameterName = "@" + returnParameterName;
            returnParameter.SqlDbType = SqlDbType.Int;
            returnParameter.Direction = ParameterDirection.Output;

            return returnParameter;
        }
    }
}