using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLiteNHibernate.UserControls
{
    public partial class CustomerEntry : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtZip.Attributes.Add("onblur", "extractNumber(this,0,false);");
            TxtZip.Attributes.Add("onkeyup", "extractNumber(this,0,false);");
            TxtZip.Attributes.Add("onkeypress", "return blockNonNumbers(this,event,true,false);");
            TxtZip.MaxLength = 5;
        }        
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            //Call DAL to delete
            SQLiteNHibernate.NHib.DataAccess DAL = new NHib.DataAccess();
            DAL.SaveCustomer(null, TxtFirst.Text, TxtLast.Text, TxtAddress.Text, TxtCity.Text, TxtState.Text, TxtZip.Text);

            //Display success
            ((_Default)this.Page).SetMessage("Customer Saves: " + TxtFirst.Text + " " + TxtLast.Text);

            //Call the load method on the parent page
            ((_Default)this.Page).LoadGrid();

            TxtFirst.Text = string.Empty;
            TxtLast.Text = string.Empty; 
            TxtAddress.Text = string.Empty; 
            TxtCity.Text = string.Empty; 
            TxtState.Text = string.Empty;
            TxtZip.Text = string.Empty;
        }     
    }
}