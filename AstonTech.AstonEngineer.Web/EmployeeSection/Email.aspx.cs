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
                this.BindEmailList();
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
        private void BindEmailList()
        {
            EmailAddressCollection emailList = EmailAddressManager.GetCollection(base.EmployeeId);

            EmailList.DataSource = emailList;
            EmailList.DataBind();
        }
        private void BindUpdateInfo(int emailId)
        {
            //notes:    get a single item from the database
            EmailAddress emailAddress = EmailAddressManager.GetItem(emailId);

            if (emailAddress != null)
            {
                //notes:    set hidden field so page knows to update
                EmailId.Value = emailAddress.EmailId.ToString();

                //notes:    set textbox for email address
                if (emailAddress.EmailValue != null)
                    EmailAddressField.Text = emailAddress.EmailValue;

                //notes:    select item from drop-down
                if (emailAddress.EmailType != null)
                    EmailTypeList.SelectedValue = emailAddress.EmailType.EntityTypeId.ToString();

                //notes:    set the display text of the button to indicate its an UPDATE
                SaveButton.Text = "Save Email";
            }
            else
                base.DisplayPageMessage(PageMessage, "Email Address could not be retrieved. Contact an Administrator.");
        }
        #endregion

        private void ProcessEmail()
        {
            EmailAddress emailToSave = new EmailAddress(EmailTypeList.SelectedItem.Value.ToInt(), EmailAddressField.Text);

            //notes:    set emailId for updates
            emailToSave.EmailId = EmailId.Value.ToInt();

            //notes:    call middle tier to save
            EmailAddressManager.Save(base.EmployeeId, emailToSave);

            Response.Redirect("Email.aspx?EmployeeId=" + base.EmployeeId.ToString());
        }
        private void DeleteEmail(int emailId)
        {
            //notes:    pass emailId to delete item from database
            if (EmailAddressManager.Delete(emailId))
            {
                //notes:    redirect back to same page to clear deleted email.
                Response.Redirect("Email.aspx?EmployeeId=" + base.EmployeeId.ToString());
            }
            else
            {
                //notes:    display message to user.
                base.DisplayPageMessage(PageMessage, "Email Address could not be deleted. Contact an Administrator.");
            }
        }

        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessEmail();
        }
        protected void EmailButton_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    this.BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;

                case "Delete":
                    this.DeleteEmail(e.CommandArgument.ToString().ToInt());
                    break;
            }
        }
        protected void EmailList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EmailAddress emailAddress = (EmailAddress)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                //notes:    set the value of the command  argument
                editButton.CommandArgument = emailAddress.EmailId.ToString();
                deleteButton.CommandArgument = emailAddress.EmailId.ToString();
            }
        }

        #endregion
    }
}