using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public class EmailAddress : BaseBO
    {
        #region

        public EmailAddress()
        {
            this.EmailType = new EntityType();
        }



        #endregion

        #region PROPERTIES

        public int EmailId { get; set; }
        public string EmailValue { get; set; }
        public EntityType EmailType { get; set; }

        #endregion
    }
}
