using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Astontech.Common.Extensions;

namespace AstonTech.AstonEngineer.Web.EmployeeSection
{
    public partial class Email : BasePage
    {
        #region LOCAL VARIABLES

        private int _employeeId;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _employeeId = base.EmployeeId;
            if (!IsPostBack)
            {
                this.BindEmployeeNavigation();
                this.BindEmailType();
            }
        }

        #region BIND CONTROLS

        private void BindEmployeeNavigation()
        {
            //notes:    set custom user control for employee subheader navigation
            CustomEmployeeNavigation.CurrentNavigationLink = EmployeeNavigation.Email;

            //notes:    get the employeeID from the query string
            CustomEmployeeNavigation.EmployeeId = _employeeId;
        }

        private void BindEmailType()
        {
            EntityTypeCollection emailCollection = EntityTypeManager.GetCollection(EntityEnum.Email);

            EmailTypeList.DataSource = emailCollection;
            EmailTypeList.DataBind();

            EmailTypeList.Items.Insert(0, new ListItem("(Select Email Type)", "0"));
        }

        #endregion

        private void ProcessEmail()
        {
            EmailAddress emailToSave = new EmailAddress(EmailTypeList.SelectedItem.Value.ToInt(), EmailAddressField.Text);

            //notes:    call middle tier to save
            EmailAddressManager.Save(base.EmployeeId, emailToSave);

            Response.Redirect("Email.aspx?EmployeeId=" + base.EmployeeId.ToString());

        }

        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessEmail();
        }


        #endregion
    }
}