using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AstonTech.AstonEngineer
{
    public class PersonDAL
    {
        #region INSERT and UPDATE

        public static int Save(Person personToSave)
        {
            int result = 0;
            int queryId = 10;

            //notes:    check for valid PersonId - if exists, UPDATE else INSERT
            //          10 = INSERT_ITEM
            //          20 = DELETE_ITEM
            if (personToSave.PersonId > 0)
                queryId = 20;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecutePerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@PersonId", personToSave.PersonId);

                    if (personToSave.FirstName != null)
                        myCommand.Parameters.AddWithValue("@FirstName", personToSave.FirstName);

                    if (personToSave.MiddleName != null)
                        myCommand.Parameters.AddWithValue("@MiddleName", personToSave.MiddleName);

                    if (personToSave.LastName != null)
                        myCommand.Parameters.AddWithValue("@LastName", personToSave.LastName);

                    if (personToSave.BirthDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@BirthDate", personToSave.BirthDate);

                    if (personToSave.SocialSecurityNumber != null)
                        myCommand.Parameters.AddWithValue("@SocialSecurityNumber", personToSave.SocialSecurityNumber);

                    //notes:    add return out parameterto command object
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

        #endregion
    }
}
