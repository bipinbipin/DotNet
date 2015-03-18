using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Astontech.Common.Extensions;

namespace AstonTech.AstonEngineer.Web.UserControls
{
    public partial class EmployeeNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindEmployeeDropDown();
                this.BindEmployeeNavigation();
            }

            
        }

        #region PROPERTIES  

        /// <summary>
        /// Set the current employee page. Link will be disabled for the current subheader link of current page
        /// </summary>
        public EmployeeNavigation CurrentNavigationLink { get; set; }

        /// <summary>
        /// If Id is greater than 0 will activate the subheader links otherwise
        /// all the subheader links will be inactive
        /// </summary>
        public int EmployeeId { get; set; }

        #endregion


        #region BIND CONTROLS

        private void BindEmployeeDropDown()
        {
            EmployeeCollection employeeCollection = EmployeeManager.GetCollection();

            EmployeeSelectList.DataSource = employeeCollection;
            EmployeeSelectList.DataBind();


            //notes:    default value at the top of the drop-down list
            EmployeeSelectList.Items.Insert(0, new ListItem { Text = "Select Employee to Update", Value = "0" });

            //notes:    set the dropdown to the value of the employeeId
            if (this.EmployeeId > 0)
                EmployeeSelectList.SelectedValue = this.EmployeeId.ToString();

        }
        private void BindEmployeeNavigation()
        {
            //notes:    set up collection of list items
            ListItemCollection navigationList = new ListItemCollection();

            //notes:    set local variables and set default values
            bool isBasicInfo = true;
            bool isEmail = true;
            bool isAddress = true;
            bool isVehicleInfo = true;
            bool isProjects = true;
            bool isLoyaltyPrograms = true;
            bool isReview = true;
            string employeeIdQueryString = "EmployeeId=" + this.EmployeeId.ToString();

            if (this.EmployeeId > 0)
            {
                //notes:    based on the user control property, determine what the current page link should be set to
                switch (this.CurrentNavigationLink)
                {
                    case EmployeeNavigation.Address:
                        isAddress = false;
                        break;

                    case EmployeeNavigation.EmployeeBasic:
                        isBasicInfo = false;
                        break;

                    case EmployeeNavigation.Email:
                        isEmail = false;
                        break;

                    case EmployeeNavigation.LoyaltyPrograms:
                        isLoyaltyPrograms = false;
                        break;

                    case EmployeeNavigation.Projects:
                        isProjects = false;
                        break;
                        
                    case EmployeeNavigation.Reviews:
                        isReview = false;
                        break;

                    case EmployeeNavigation.VehicleInfo:
                        isVehicleInfo = false;
                        break;
                }
            }
            else
            {
                //notes:    no EmployeeId exists - set all links to inactive
                isBasicInfo = false;
                isEmail = false;
                isAddress = false;
                isVehicleInfo = false;
                isProjects = false;
                isLoyaltyPrograms = false;
                isReview = false;
            }
            
            //notes:    add each item to the collection
            navigationList.Add(new ListItem { Text = "Basic Info", Value = "/EmployeeSection/EmployeeBasic.aspx?" + employeeIdQueryString, Enabled = isBasicInfo });
            navigationList.Add(new ListItem { Text = "Email", Value = "/EmployeeSection/Email.aspx?" + employeeIdQueryString, Enabled = isEmail });
            navigationList.Add(new ListItem { Text = "Address", Value = "/EmployeeSection/Address.aspx?" + employeeIdQueryString, Enabled = isAddress });
            navigationList.Add(new ListItem { Text = "Vehicle Info", Value = "/EmployeeSection/VehicleInfo.aspx?" + employeeIdQueryString, Enabled = isVehicleInfo });
            navigationList.Add(new ListItem { Text = "Projects", Value = "/EmployeeSection/Project.aspx?" + employeeIdQueryString, Enabled = isProjects });
            navigationList.Add(new ListItem { Text = "Loyalty Programs", Value = "/EmployeeSection/LoyaltyPrograms.aspx?" + employeeIdQueryString, Enabled = isLoyaltyPrograms });
            navigationList.Add(new ListItem { Text = "Review", Value = "/EmployeeSection/Review.aspx?" + employeeIdQueryString, Enabled = isReview });

            //notes:    bind list object to front-end control
            EmployeeNavigationList.DataSource = navigationList;
            EmployeeNavigationList.DataBind();
        }
        #endregion
        
        #region EVENT HANDLERS

        protected void EmployeeSelectList_Selected(object sender, EventArgs e)
        {
            if (EmployeeSelectList.SelectedValue.ToInt() > 0)
            {
                Response.Redirect(this.CurrentNavigationLink.ToString() + ".aspx?EmployeeId=" + EmployeeSelectList.SelectedValue);
            }
            else
            {
                //notes:    user selected the default list  item - didn't select an employee
                Response.Redirect("EmployeeBasic.aspx");
            }
        }

        #endregion


    }
}