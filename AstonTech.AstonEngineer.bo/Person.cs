using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public class Person : BaseBO
    {
        #region PROPERTIES

        public int PersonId { get; set; }
        public DateTime BirthDate { get; set; }
        public string DisplayFirstName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }

        #endregion

        #region METHODS

        public virtual string GetFullName()
        {
            if (string.IsNullOrEmpty(this.FirstName) && string.IsNullOrEmpty(this.LastName))
                return "Not Valid";
            else
                return this.FirstName + " " + this.LastName;
        }

        #endregion
    }
}
