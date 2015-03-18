using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AstonTech.AstonEngineer;

namespace AstonTech.AstonEngineer
{
    public class EntityTypeManager
    {
        #region RETRIEVE SINGLE ITEM

        public static EntityType GetItem(int EntityTypeId)
        {
            
            //notes:    call DAL to retrieve item by ID
            return new EntityType();

        }

        #endregion


        #region RETRIEVE COLLECTION
        public static EntityTypeCollection GetCollection()
        {
            
            //notes:    call DAL to retrieve collection
            return new EntityTypeCollection();

        }

        public static EntityTypeCollection GetCollection(EntityEnum entityName)
        {
            
            //notes:    call DAL to retrieve collection
            EntityTypeCollection entityTypeCollection = EntityTypeDAL.GetCollection(entityName);
            return entityTypeCollection;
        }

        #endregion

    }
}
