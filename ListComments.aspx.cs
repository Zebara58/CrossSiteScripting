using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CrossSiteScripting
{
    public partial class ListComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strQs, strSQL = string.Empty;
            strSQL = "SELECT * FROM dbo.[MyComments] ORDER BY ID";

            //Persistent XSS attack (SQL Injection)
            if (Request.QueryString["cid"] != null)
            {
                strQs = Request.QueryString["cid"] as string;
                strSQL = "SELECT * FROM dbo.[MyComments] WHERE [id]=" + strQs + " ORDER BY [Name]";
            }
            if (Request.QueryString["show"] != null)
            {
                Response.Write(strSQL);
            }

            GetComments(strSQL);
        }

        void GetComments(string strTsql)
        {
            string strResult = string.Empty;
            SqlCommand command;
            SqlDataReader dataR;
            SqlConnection myConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {

                int cellCtr;
                int cellCnt = 4;
                myConnection.Open();
                command = new SqlCommand(strTsql, myConnection);
                dataR = command.ExecuteReader();
                while(dataR.Read())
                {
                    //MessageBox.Show(dataR.GetValue(0) + " - " + dataR.GetValue(1) + " - " + dataR.GetValue(2));
                    TableRow tRow = new TableRow();
                    table.Rows.Add(tRow);
                    for (cellCtr = 0; cellCtr <= cellCnt; cellCtr++)
                    {
                        TableCell tCell = new TableCell();
                        tCell.Text = dataR.GetValue(cellCtr).ToString();
                        tRow.Cells.Add(tCell);
                    }

                }
                dataR.Close();
                command.Dispose();
                myConnection.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }
        }
    }
}