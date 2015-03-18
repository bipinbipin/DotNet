using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public static class PersonManager
    {
        #region SAVE
        public static int Save(Person personToSave)
        {
            int returnValue;
            returnValue = PersonDAL.Save(personToSave);

            return returnValue;
        }
        #endregion

        #region DELETE
        public static bool Delete(int personId)
        {
            //notes:    call DAL to delete person record
            return PersonDAL.Delete(personId);
        }
        #endregion
    }
}
