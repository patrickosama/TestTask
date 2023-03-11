using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace TestTask
{
    public class Invoices
    {
        public int invoiceId { get; set; }
        public string description { get; set; }

        public string Date { get; set; }
        public string clientName { get; set; }
        public float totalBeforeTax { get; set; }
        public float totalAfterTax { get; set; }

        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public double itemPrice { get; set; }

        public List<Invoices> GetInvoices(string connectionString)
        {
            List<Invoices> invoiceList = new List<Invoices>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "select Id, Date, Name, Total_a_tax from GetInvoiceData";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Invoices invoice = new Invoices();
                    invoice.invoiceId = Convert.ToInt32(dr["invoiceId"]);
                    invoice.description = dr["Description"].ToString();
                    invoice.clientName = dr["Name"].ToString();
                    invoice.itemName = dr["ItemName"].ToString();
                    invoice.itemQuantity = Convert.ToInt32(dr["Quantity"]);
                    invoice.itemPrice = Convert.ToDouble(dr["Price"]);
                    invoiceList.Add(invoice);
                }
            }
            return invoiceList;
        }
    }
}