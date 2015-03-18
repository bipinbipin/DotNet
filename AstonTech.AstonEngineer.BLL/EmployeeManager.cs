using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public static class EmployeeManager
    {
        #region RETRIEVE

        public static Employee GetItem(int employeeId)
        {
            return EmployeeDAL.GetItem(employeeId);
        }

        public static EmployeeCollection GetCollection()
        {
            //notes:    returns a collection of all the Employees
            return EmployeeDAL.GetCollection();
        }

        #endregion 

        #region SAVE
        public static int Save(Employee employeeToSave)
        {
            //notes:    first need to save person information and get Id
            int personId = SavePerson(employeeToSave);
            employeeToSave.PersonId = personId;

            //notes:    call data access layer to save employee info
            return EmployeeDAL.Save(employeeToSave);
        }

        #endregion

        #region DELETE
        public static bool Delete(int personId, int employeeId)
        {
            //notes:    make sure the person delete is successful before deleting employee
            if (EmployeeDAL.Delete(employeeId))
            {
                //notes:    call employee DAL to delete employee
                return PersonManager.Delete(personId);
            }
            else
                return false;
        }
        #endregion

        #region PRIVATE METHODS

        private static int SavePerson(Employee employeeToSave)
        {
            Person tempPerson = new Person();
            tempPerson.PersonId = employeeToSave.PersonId;

            if (employeeToSave.FirstName != null)
                tempPerson.FirstName = employeeToSave.FirstName;

            if (employeeToSave.MiddleName != null)
                tempPerson.MiddleName = employeeToSave.MiddleName;

            if (employeeToSave.LastName != null)
                tempPerson.LastName = employeeToSave.LastName;

            if (employeeToSave.SocialSecurityNumber != null)
                tempPerson.SocialSecurityNumber = employeeToSave.SocialSecurityNumber;

            if (employeeToSave.BirthDate != DateTime.MinValue)
                tempPerson.BirthDate = employeeToSave.BirthDate;

            //notes:    call PersonManager class to do the save()
            return PersonManager.Save(tempPerson);
        }

        #endregion
    }
}
