namespace AstonTech.AstonEngineer
{
    /// <summary>
    /// Correlates to the values in the Entity table in the database.
    /// EntityName values can be used to pass as filters to retrieve EntityTypes.
    /// </summary>
    public enum EntityEnum
    {
        /// <summary>
        /// Defaults to none.
        /// </summary>
        None,
        /// <summary>
        /// Category such as Internal, Trainee, etc.
        /// </summary>
        EmployeeCategory,
        /// <summary>
        /// Tier level of employee.
        /// </summary>
        EmployeeTierLevel,
        /// <summary>
        /// Type of laptop assigned to employee.
        /// </summary>
        EmployeeLaptop
    }
}

