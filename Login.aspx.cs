using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ajaxPostDemo
{
    public partial class Account_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            if (Request.RequestType == "POST")
            {
                string strUsrNm = Request.Form["ctl00$MainContent$LoginUser$UserName"];
                string usrPass = Request.Form["ctl00$MainContent$LoginUser$Password"];
                if (!string.IsNullOrEmpty(strUsrNm))
                {
                    LoginUser.Visible = false;
                    lblStatus.Text = "Hello " + strUsrNm + ", Thanks very much for logging in.";
                }
            }

            if (Page.IsPostBack)
            {
                LoginUser.Visible = false;
                lblStatus.Text = "Thanks very much for logging in";
            }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            LoginUser.Visible = false;
            lblStatus.Text = "Thanks very much for logging in";
        }
    }
}