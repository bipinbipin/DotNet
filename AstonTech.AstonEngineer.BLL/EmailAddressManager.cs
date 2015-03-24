using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public static class EmailAddressManager
    {

        #region RETRIEVE
        /// <summary>
        /// Gets a single email address by EmailId
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public static EmailAddress GetItem(int emailId)
        {
            return EmailAddressDAL.GetItem(emailId);
        }
        /// <summary>
        /// Gets a collection of email addresses by Employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static EmailAddressCollection GetCollection(int employeeId)
        {
            //notes:    calls DAL to retrieve email collection by employeeId
            return EmailAddressDAL.GetCollection(employeeId);
        }

        #endregion
        #region SAVE
        public static int Save(int employeeId, EmailAddress emailAddress)
        {
            int returnValue;
            returnValue = EmailAddressDAL.Save(employeeId, emailAddress);

            return returnValue;
        }
        #endregion

        #region DELETE
        public static bool Delete(int emailId)
        {
            //notes:    call DAL to delete person record
            return EmailAddressDAL.Delete(emailId);
        }
        #endregion


    }
}
