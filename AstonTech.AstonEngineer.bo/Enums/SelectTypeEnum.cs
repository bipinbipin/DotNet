
namespace AstonTech.AstonEngineer
{
    /// <summary>
    /// Values correspond to the @QueryId in the SELECT (usp_GetXXX) stored procedures
    /// the integer values need to be passed from the DAL.
    /// </summary>
    public enum SelectTypeEnum
    {
        /// <summary>
        /// Defaults to None
        /// </summary>
        None = 0,
        /// <summary>
        /// Get a single item from the database.
        /// </summary>
        GetItem = 10,
        /// <summary>
        /// Get a single item by Id.
        /// </summary>
        GetItemById = 11,
        /// <summary>
        /// get the collection of items from the database.
        /// </summary>
        GetCollection = 20,
        /// <summary>
        /// get the collection of items by Id.
        /// </summary>
        GetCollectionById = 21,
        /// <summary>
        /// get the collection of items by name.
        /// </summary>
        GetCollectionByName = 22
        
       
    }
}
