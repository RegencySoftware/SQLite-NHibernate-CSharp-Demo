using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLiteNHibernate.UserControls
{
    public partial class CustomerGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Load Customer Grid
        /// </summary>
        public void  LoadCustomerGrid()
        {
            SQLiteNHibernate.NHib.DataAccess DAL = new NHib.DataAccess();
            GridCustomers.DataSource = DAL.GetCustomers();
            GridCustomers.DataBind();
        }
        /// <summary>
        /// Delete customer and reload the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {            
            //Call DAL to delete
            SQLiteNHibernate.NHib.DataAccess DAL = new NHib.DataAccess();
            DAL.DeleteCustomer(Convert.ToInt32(HFCustomerID.Value));

            //Set the message on the parent page
            ((_Default)this.Page).SetMessage("Deleted - Customer ID: " + HFCustomerID.Value + " " + HFName.Value);

            HFCustomerID.Value = string.Empty;
            HFName.Value = string.Empty;

            //Reload the grid
            LoadCustomerGrid();
        }
    }
}