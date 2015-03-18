using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    public class EntityType : BaseBO
    {
        #region CONSTRUCTOR

        public EntityType() { }
        public EntityType(string entityTypeValue)
        {
            this.EntityTypeValue = entityTypeValue;
        }
        public EntityType(int entityTypeId, string entityTypeValue)
        {
            this.EntityTypeId = entityTypeId;
            this.EntityTypeValue = entityTypeValue;
        }
        
        
        #endregion



        #region PROPERTIES

        public int EntityTypeId { get; set; }
        public string EntityTypeValue { get; set; }

        #endregion
    }
}
