using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public class Employee : Person
    {
        #region CONSTRUCTOR
        public Employee()
        {
            this.Emails = new EmailAddressCollection(); 
        }
        public Employee(string firstName, string lastName)
        {
            this.Emails = new EmailAddressCollection(); 
            base.FirstName = firstName;
            base.LastName = lastName;
        }
        #endregion

        #region PROPERTIES

        private int employeeId;

        public int EmployeeId { get; set; }
        public int PayRate { get; set; }
        public DateTime DriversLicenseExpireDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TermDate { get; set; }
        public string Background { get; set; }
        public string DriversLicenseNumber { get; set; }

        public string FullName
        {
            get
            {
                return base.FirstName + " " + base.LastName;
            }
        }
        public string FullNameLastNameFirst
        {
            get
            {
                return base.LastName + ", " + base.FirstName;
            }
        }

        public EntityType Category { get; set; }
        public EntityType TierLevel { get; set; }
        public EntityType Laptop { get; set; }
        public EmailAddressCollection Emails { get; set; }

        #endregion

    }
}
