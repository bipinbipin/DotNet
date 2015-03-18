using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.AstonEngineer.Web.EmployeeSection
{
    public partial class Email : BasePage
    {
        #region LOCAL VARIABLES

        private int _employeeId;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _employeeId = base.GetQueryStringNumber("EmployeeId");

            this.BindEmployeeNavigation();
        }

        #region BIND CONTROLS

        private void BindEmployeeNavigation()
        {
            //notes:    set custom user control for employee subheader navigation
            CustomEmployeeNavigation.CurrentNavigationLink = EmployeeNavigation.Email;

            //notes:    get the employeeID from the query string
            CustomEmployeeNavigation.EmployeeId = _employeeId;
        }

        #endregion
    }
}