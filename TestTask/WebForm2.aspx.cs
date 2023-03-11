using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestTask
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveBtn_Click1(object sender, EventArgs e)
        {
            {
                myConnection.Open();
                string query = "Insert into [dbo].[Invoices] (Description,Number,Client_ID,Date, item, image) Values (@Des,@Number,@Client,@Date, @image)";
                string query2 = "Insert into [dbo].[invoiceItems] (ItemName,Quantity,Price) Values (@ItemName,@Quantity,@Price)";
                SqlCommand insertCommand = new SqlCommand(query, myConnection);
                insertCommand.Parameters.AddWithValue("@Des", TextBox1.Text);
                insertCommand.Parameters.AddWithValue("@Number", TextBox2.Text);
                insertCommand.Parameters.AddWithValue("@Client", DropDownList1.DataValueField);
                insertCommand.Parameters.AddWithValue("@Date", Calendar1.NextMonthText);
                insertCommand.Parameters.AddWithValue("@image", attachpdf.);


                SqlCommand insertCommand2 = new SqlCommand(query2, myConnection);
                insertCommand.Parameters.AddWithValue("@ItemName", TextBox5.Text);
                insertCommand.Parameters.AddWithValue("@Quantity", TextBox6.Text);
                insertCommand.Parameters.AddWithValue("@Price", TextBox7.Text);




                insertCommand.ExecuteNonQuery();
                myConnection.Close();
            }

        }
        
      
    }
}