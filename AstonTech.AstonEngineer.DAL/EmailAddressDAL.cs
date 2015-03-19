using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AstonTech.AstonEngineer;

namespace AstonTech.AstonEngineer
{
    public class EmailAddressDAL
    {




        #region INSERT UPDATE DELETE

        public static int Save(int employeeId, EmailAddress emailAddress)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            //notes:    check for valid PersonId - if exists, UPDATE else INSERT
            //          10 = INSERT_ITEM
            //          20 = UPDATE_ITEM
            if (emailAddress.EmailId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    
                    if (emailAddress.EmailId != null)
                    myCommand.Parameters.AddWithValue("@EmailId", emailAddress.EmailId);

                    if (emailAddress.EmailValue != null)
                        myCommand.Parameters.AddWithValue("@EmailAddress", emailAddress.EmailValue);

                    if (emailAddress.EmailType.EntityTypeId > 0)
                        myCommand.Parameters.AddWithValue("@EntityTypeId", emailAddress.EmailType.EntityTypeId);

                    //notes:    add return output parameter to command object
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    //notes:    get return value from stored procedure and return Id
                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }

                myConnection.Close();
            }
            return result;
        }

        public static bool Delete(int emailId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EmailId", emailId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }
        #endregion
    }
}
