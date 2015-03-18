using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstonTech.AstonEngineer
{
    /// <summary>
    /// Values correspond to the @QueryId in the EXECUTE stored procedures.
    /// the integer value needs to be passed to the procedures from DAL.
    /// </summary>
    public enum ExecuteTypeEnum
    {
        /// <summary>
        /// defaults to none.
        /// </summary>
        None=0,
        /// <summary>
        /// Insert
        /// </summary>
        InsertItem = 10,
        /// <summary>
        /// Update
        /// </summary>
        UpdateItem = 20,
        /// <summary>
        /// Delete
        /// </summary>
        DeleteItem = 30
    }
}
