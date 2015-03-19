using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public class EmailAddress : BaseBO
    {
        #region CONSTRUCTORS

        public EmailAddress()
        {
            this.EmailType = new EntityType();
        }
        public EmailAddress(int entityTypeId, string emailAddress)
        {
            this.EmailType = new EntityType { EntityTypeId = entityTypeId };
            this.EmailValue = emailAddress;
        }


        #endregion

        #region PROPERTIES

        public int EmailId { get; set; }
        public string EmailValue { get; set; }
        public EntityType EmailType { get; set; }

        #endregion
    }
}
