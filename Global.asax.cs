using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Routing;
using System.Windows.Forms;

namespace CrossSiteScripting
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string strTsql = "DELETE FROM dbo.MyComments";
            updateDB(strTsql);
            strTsql = "INSERT INTO dbo.MyComments SELECT 'test1', 'test1@test.com', 'http://www.google.com', 'test1 comment', getdate(), null";
            updateDB(strTsql);
            strTsql = "INSERT INTO dbo.MyComments SELECT 'test2', 'test2@test.com', 'http://www.google.com', 'test2 comment', getdate(), null";
            updateDB(strTsql);
            strTsql = "INSERT INTO dbo.MyComments SELECT 'test3', 'test3@test.com', 'http://www.google.com', 'test3 comment', getdate(), null";
            updateDB(strTsql);
            strTsql = "INSERT INTO dbo.MyComments SELECT 'test4', 'test4@test.com', 'http://www.google.com', 'test4 comment', getdate(), null";
            updateDB(strTsql);

        }

        private void updateDB(string strTsql)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SqlCommand command;
            using (SqlConnection myConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    command = new SqlCommand(strTsql, myConnection);
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("You failed!" + ex.Message);
                }
            }
        }
    }

}
