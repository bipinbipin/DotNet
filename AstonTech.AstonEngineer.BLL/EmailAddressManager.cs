using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public static class EmailAddressManager
    {
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
