using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstonTech.AstonEngineer.Web
{
    /// <summary>
    /// Represents the employee subheader navigation when navigating within the
    /// Employee pages. the text of the enum should also match the physical name of
    /// the ASPX file.
    /// </summary>
    public enum EmployeeNavigation
    {
        /// <summary>
        /// Default to none value.
        /// </summary>
        None,
        /// <summary>
        /// This page contains the physical addresses.
        /// </summary>
        Address,
        /// <summary>
        /// This page is going to contain a form to capture the employee's basic information
        /// such as first, last name, etc.
        /// </summary>
        EmployeeBasic,
        /// <summary>
        /// This page contains the email addresses.
        /// </summary>
        Email,
        /// <summary>
        /// This page contains any loyalty programs such as frequent flyer programs,
        /// car rental, etc.
        /// </summary>
        LoyaltyPrograms,
        /// <summary>
        /// This page contains any projects associated with the Employee.
        /// </summary>
        Projects,
        /// <summary>
        /// This page contains any reviews associated wih the Employee.
        /// </summary>
        Reviews,
        /// <summary>
        /// This page contains any vehicle information such as leased vehicle, employee
        /// driver license number, etc
        /// </summary>
        VehicleInfo
    }
}