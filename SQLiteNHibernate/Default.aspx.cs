using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLiteNHibernate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) LoadGrid();

            PnlAlertMsg.Visible = false;
        }
        /// <summary>
        /// This method calls the User Control LoadCustomerGrid() Method
        /// </summary>
        public void LoadGrid()
        {
            CustomerGridUC.LoadCustomerGrid();
        }
        public void SetMessage(string msg)
        {
            PnlAlertMsg.Visible = true;
            LblMsg.Text = msg;
        }

    }
}