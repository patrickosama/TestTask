using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace TestTask
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillInvoicesGrid();
            }
        }
        private void FillInvoicesGrid()
        {
            List<Invoices> InvoiceList = new List<Invoices>();
            Invoices invoice = new Invoices();
            InvoiceList = invoice.GetInvoices(connectionString);
            gridInvoiceList.DataSource = InvoiceList;
            gridInvoiceList.DataBind();
        }
    }
}