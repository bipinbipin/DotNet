using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AstonTech.AstonEngineer.Web
{
    public class BasePage : System.Web.UI.Page
    {

        #region PROPERTIES
        /// <summary>
        /// Gets Id from EmployeeId QueryString. If not found, returns 0
        /// </summary>
        public int EmployeeId
        {
            get
            {
                return this.GetQueryStringNumber("EmployeeId");
            }
        }
        #endregion
        /// <summary>
        /// Attempt to retrieve a numeric value from the querystring.
        /// if invalid querystring name or value is not an integer, return 0.
        /// </summary>
        /// <param name="queryStringName">Name of the QueryString name/value pair.</param>
        /// <returns>Integer value</returns>
        public int GetQueryStringNumber(string queryStringName)
        {
            if (Request.QueryString[queryStringName] == null)
            {
                //notes:    return 0 if invalid querystring
                return 0;
            }
            else
            {
                string tempValue = Request.QueryString[queryStringName];
                int intOutValue;

                //notes:    attempt to parse into an integer value
                if (int.TryParse(tempValue, out intOutValue))
                    return intOutValue;
                else
                    return 0;
            }
        }

        public void DisplayPageMessage(Label labelControl, string messageToDisplay)
        {
            this.DisplayPageMessage(labelControl, messageToDisplay, false);
        }
        public void DisplayPageMessage(Label labelControl, string messageToDisplay, bool isAppend)
        {
            if (isAppend)
                labelControl.Text += messageToDisplay;
            else
                labelControl.Text = messageToDisplay;
        }
    }
}