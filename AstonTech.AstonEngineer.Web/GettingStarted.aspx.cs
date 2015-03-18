using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonTech.AstonEngineer.Web
{
    public partial class GettingStarted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HelloWorld.Text = "this is from code behind";
            HelloWorld.Text = DateTime.Now.ToShortTimeString();   
        }
    }
}