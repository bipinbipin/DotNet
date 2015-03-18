using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AstonTech.AstonEngineer;
using Astontech.Common.Extensions;

namespace AstonTech.AstonEngineer.Web.EmployeeSection
{
    public partial class EmployeeBasic : BasePage
    {
        #region LOCAL VARIABLES

        private int _employeeId;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _employeeId = base.GetQueryStringNumber("EmployeeId");
            
            this.BindEmployeeNavigation();
            
            if (!IsPostBack)
            {
                this.BindEmployeeCategory();
                this.BindEmployeeTierLevel();
                this.BindEmployeeLaptop();

                //note:     check if in UPDATE mode
                this.BindUpdateInfo();
            }
        }

        #region BIND CONTROLS

        private void BindEmployeeNavigation()
        {
            //notes:    set custom user control for employee subheader navigation
            CustomEmployeeNavigation.CurrentNavigationLink = EmployeeNavigation.EmployeeBasic;

            //notes:    get the employeeID from the query string
            CustomEmployeeNavigation.EmployeeId = _employeeId;
        }
        private void BindEmployeeCategory()
        {
            EntityTypeCollection employeeCategoryCollection = EntityTypeManager.GetCollection(EntityEnum.EmployeeCategory);

            //notes:    bind to drop-down control
            Category.DataSource = employeeCategoryCollection;
            Category.DataBind();

            //notes:    set default text
            Category.Items.Insert(0, new ListItem { Text = "(Select Category)", Value = "0" });

        }
        private void BindEmployeeTierLevel()
        {
            EntityTypeCollection employeeTierLevel = EntityTypeManager.GetCollection(EntityEnum.EmployeeTierLevel);

            //notes:    bind to  drop-down control
            TierLevel.DataSource = employeeTierLevel;
            TierLevel.DataBind();

            //notes:    set  default text
            TierLevel.Items.Insert(0, new ListItem { Text = "(Select Tier Level)", Value = "0" });

        }
        private void BindEmployeeLaptop()
        {
            EntityTypeCollection employeeLaptop = EntityTypeManager.GetCollection(EntityEnum.EmployeeLaptop);

            //notes:    bind to drop-down control
            Laptop.DataSource = employeeLaptop;
            Laptop.DataBind();

            //notes:    set default text
            Laptop.Items.Insert(0, new ListItem { Text = "(Select Laptop)", Value = "0" });
        }

        #endregion

        private void ProcessForm()
        {
            StringBuilder formControlValues = new StringBuilder();

            string firstName = FirstName.Text;
            string middleName = MiddleName.Text;
            string lastName = LastName.Text;
            string socialSecurityNumber = SSN.Text;

            DateTime birthDate = BirthDate.Text.ToDate();
            DateTime hireDate = HireDate.Text.ToDate();
            DateTime termDate = TermDate.Text.ToDate();

            string categoryText = Category.SelectedItem.Text;
            string tierLevelText = TierLevel.SelectedItem.Text;
            string laptopText = Laptop.SelectedItem.Text;
            string background = Background.Text;

            int categoryValue = Category.SelectedValue.ToInt();
            int tierLevelValue = TierLevel.SelectedValue.ToInt();
            int laptopValue = Laptop.SelectedValue.ToInt();
            int payRate = PayRate.Text.ToInt();
            
            //notes:    set employee properties
            Employee employeeToSave = new Employee();

            //notes:    set Id's from hidden fields
            employeeToSave.EmployeeId = EmployeeId.Value.ToInt();
            employeeToSave.PersonId = PersonId.Value.ToInt();

            //notes:    person specific info
            employeeToSave.FirstName = firstName;
            employeeToSave.MiddleName = middleName;
            employeeToSave.LastName = lastName;
            employeeToSave.SocialSecurityNumber = socialSecurityNumber;
            employeeToSave.BirthDate = birthDate;

            //notes:    employee specific info
            employeeToSave.HireDate = hireDate;
            employeeToSave.TermDate = termDate;
            employeeToSave.PayRate = payRate;
            employeeToSave.Background = background;

            //notes:    complex properties
            employeeToSave.Category = new EntityType { EntityTypeId = categoryValue };
            employeeToSave.TierLevel = new EntityType { EntityTypeId = tierLevelValue };
            employeeToSave.Laptop = new EntityType { EntityTypeId = laptopValue };

            //notes:    call manager class to save to database
            int employeeId = EmployeeManager.Save(employeeToSave);

            //notes:    outputs string value to the label control
            if (employeeToSave.PersonId > 0 && employeeToSave.EmployeeId > 0)
            {
                //notes:    outputs string values to the label control
                base.DisplayPageMessage(PageMessage, "Update was successful.");
            }
            else
            {
                //notes:    INSERT was successful
                Response.Redirect("EmployeeBasic.aspx?EmployeeId=" + employeeId);
            }

            //notes:    this will output the values sent from the postback
            //this.DisplayPost();

        }
        private void BindUpdateInfo()
        {
            if(_employeeId >0)
            {
                Employee employeeToUpdate = EmployeeManager.GetItem(_employeeId);
                if (employeeToUpdate != null)
                {
                    if (employeeToUpdate.PersonId > 0 && employeeToUpdate.EmployeeId > 0)
                    {
                        //notes:    first change the text of the button to indicate that we're updating
                        SaveButton.Text = "Save Changes";
                        
                        //notes:    display delete button
                        DeleteButton.Visible = true;

                        //notes:    set hidding form values for PersonId and EmployeeId
                        PersonId.Value = employeeToUpdate.PersonId.ToString();
                        EmployeeId.Value = employeeToUpdate.EmployeeId.ToString();

                        //notes:    string fields
                        if (!string.IsNullOrEmpty(employeeToUpdate.FirstName))
                            FirstName.Text = employeeToUpdate.FirstName;

                        if (!string.IsNullOrEmpty(employeeToUpdate.MiddleName))
                            MiddleName.Text = employeeToUpdate.MiddleName;

                        if (!string.IsNullOrEmpty(employeeToUpdate.LastName))
                            LastName.Text = employeeToUpdate.LastName;

                        if (!string.IsNullOrEmpty(employeeToUpdate.SocialSecurityNumber))
                            SSN.Text = employeeToUpdate.SocialSecurityNumber;

                        if (!string.IsNullOrEmpty(employeeToUpdate.Background))
                            Background.Text = employeeToUpdate.Background;

                        //notes:    date fields
                        if (employeeToUpdate.BirthDate != DateTime.MinValue)
                            BirthDate.Text = employeeToUpdate.BirthDate.ToShortDateString();

                        if (employeeToUpdate.HireDate != DateTime.MinValue)
                            HireDate.Text = employeeToUpdate.HireDate.ToShortDateString();

                        if (employeeToUpdate.TermDate != DateTime.MinValue)
                            TermDate.Text = employeeToUpdate.TermDate.ToShortDateString();

                        //notes:    integer fields
                        if (employeeToUpdate.PayRate > 0)
                            PayRate.Text = employeeToUpdate.PayRate.ToString();

                        //notes:    drop-down fields
                        if (employeeToUpdate.Category != null && employeeToUpdate.Category.EntityTypeId > 0)
                            Category.SelectedValue = employeeToUpdate.Category.EntityTypeId.ToString();

                        if (employeeToUpdate.TierLevel != null && employeeToUpdate.Category.EntityTypeId > 0)
                            TierLevel.SelectedValue = employeeToUpdate.TierLevel.EntityTypeId.ToString();

                        if (employeeToUpdate.Laptop != null && employeeToUpdate.Laptop.EntityTypeId > 0)
                            Laptop.SelectedValue = employeeToUpdate.Laptop.EntityTypeId.ToString();
                    }
                    else
                    {
                        //notes:    the necessary Id's to UPDATE are missing
                        Response.Redirect("EmployeeBasic.aspx");
                    }
                }
                else
                {
                    //notes:    even though EmployeeId exists - a valid employee record couldn't be found
                    //          redirect back to itself without the EmployeeId in the querystring
                    Response.Redirect("EmployeeBasic.aspx");
                }
            }
        }
        private void DisplayPost()
        {
            StringBuilder formControlValues = new StringBuilder();

            string firstName = FirstName.Text;
            string middleName = MiddleName.Text;
            string lastName = LastName.Text;
            string birthDate = BirthDate.Text;
            string socialSecurityNumber = SSN.Text;
            string hireDate = HireDate.Text;
            string termDate = TermDate.Text;
            string categoryText = Category.SelectedItem.Text;
            string categoryValue = Category.SelectedValue;
            string tierLevelText = TierLevel.SelectedItem.Text;
            string tierLevelValue = TierLevel.SelectedValue;
            string payRate = PayRate.Text;
            string laptopText = Laptop.SelectedItem.Text;
            string laptopValue = Laptop.SelectedValue;
            string background = Background.Text;

            formControlValues.Append("First Name: " + firstName);
            formControlValues.Append("<br />");
            formControlValues.Append("Middle Name: " + middleName);
            formControlValues.Append("<br />");
            formControlValues.Append("Last Name: " + lastName);
            formControlValues.Append("<br />");
            formControlValues.Append("Birth Date: " + birthDate);
            formControlValues.Append("<br />");
            formControlValues.Append("Social Security Number: " + SSN.Text);
            formControlValues.Append("<br />");
            formControlValues.Append("Hire Date: " + hireDate);
            formControlValues.Append("<br />");
            formControlValues.Append("Term Date: " + termDate);
            formControlValues.Append("<br />");
            formControlValues.Append("Category: " + categoryText + " (" + categoryValue + ")");
            formControlValues.Append("<br />");
            formControlValues.Append("Tier Level: " + tierLevelText + " (" + tierLevelValue + ")");
            formControlValues.Append("<br />");
            formControlValues.Append("Pay Rate: " + payRate);
            formControlValues.Append("<br />");
            formControlValues.Append("Laptop Value: " + laptopText + " (" + laptopValue + ")");
            formControlValues.Append("<br />");
            formControlValues.Append("Background: " + background);

            //notes:    outputs string value to the label control
            PageMessage.Text = formControlValues.ToString();
        }

        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            int personId = PersonId.Value.ToInt();
            int employeeId = EmployeeId.Value.ToInt();

            if (personId > 0 && employeeId > 0)
            {
                //notes:    call middle tier to delete employee record
                if(EmployeeManager.Delete(personId,employeeId))
                {
                    //notes:    redirect to the basic page
                    Response.Redirect("EmployeeBasic.aspx");
                }
                else
                {
                    //notes:    display a friendly error message
                    base.DisplayPageMessage(PageMessage, "Delete failed.");
                }
            }
        }

        #endregion 
    }
}