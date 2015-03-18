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
    public class EntityTypeDAL
    {
        #region RETRIEVE SINGLE ITEM

        #endregion

        #region RETRIEVE COLLECTION

        public static EntityTypeCollection GetCollection(EntityEnum entityName)
        {
            EntityTypeCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollectionByName);
                    myCommand.Parameters.AddWithValue("@EntityName", entityName.ToString());

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EntityTypeCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }
        
        #endregion

        #region PRIVATE METHODS

        private static EntityType FillDataRecord(IDataRecord myDataRecord)
        {
            EntityType myObject = new EntityType();

            myObject.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityTypeId"));
            myObject.EntityTypeValue = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityTypeValue"));

            return myObject;
        }
        #endregion

    }
}
