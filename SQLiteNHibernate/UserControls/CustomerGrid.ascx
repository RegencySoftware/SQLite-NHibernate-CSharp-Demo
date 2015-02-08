<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerGrid.ascx.cs" Inherits="SQLiteNHibernate.UserControls.CustomerGrid" %>

<style>
    table {max-width:900px}
    td, th {padding: 5px;}

    .hidden { visibility:hidden }
</style>

<script>
    var CustomerID;
    var FullName;

    //--------------------------------------
    // Show delete modal confirmation
    //--------------------------------------
    function ConfirmDelete(customerID, first, last)
    {   
        //Global var for delete
        CustomerID = customerID;
        FullName = first + "&nbsp;" + last;

        $("#CustomerInfoMsg").html("ID:&nbsp;" + customerID + "&nbsp;-&nbsp;" + FullName);
        $('#ConfirmDelModal').modal('show');       
        }
        //--------------------------------------
        // Use clicked ok for delete on Modal
        //--------------------------------------
        function DeleteCustomerRow()
        {
            $("#HFCustomerID").val(CustomerID);
            $("#HFName").val(FullName);           

            //Hidden Button to perform the delete
            BtnDelete.click();
        }
</script>

<div style="width:850px;">
     <asp:GridView ID="GridCustomers" EnableViewState="false" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>   
                    <a class="BtnDeleteCustRow" href="#" title="Delete Row" onclick='ConfirmDelete(<%# Eval("ID") %>,"<%# Eval("FirstName") %>","<%# Eval("LastName") %>")'> <span style="width:20px;" class="glyphicon glyphicon-trash"></span></a>            
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="Cust ID" />
            <asp:BoundField DataField="FirstName" HeaderText="First" />
            <asp:BoundField DataField="LastName" HeaderText="Last" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="City" HeaderText="City" />
            <asp:BoundField DataField="State" HeaderText="State" />
            <asp:BoundField DataField="ZipCode" HeaderText="Zip" />        
        </Columns>
        <HeaderStyle BackColor="Silver" Font-Bold="False" />
    </asp:GridView>
</div>

<div id="ConfirmDelModal" class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Confirm Delete?</h4>
      </div>
      <div class="modal-body" style="font-size:110%">
        <b>Delete This Customer?</b>&nbsp;&nbsp;<span id="CustomerInfoMsg"></span>?
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" onclick="DeleteCustomerRow()" class="btn btn-warning">Delete Customer</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridCustomers.ClientID %>').Scrollable({
            ScrollHeight: 350,
            IsInUpdatePanel: true
        });
    });
</script>

<!-- Instead of dealing with GridRow Commands call this hidden button after you populate the hidden field -->

<asp:HiddenField ID="HFCustomerID" ClientIDMode="Static" runat="server" />
<asp:HiddenField ID="HFName" ClientIDMode="Static" runat="server" />

<div style="visibility:hidden">
    <asp:Button ID="BtnDelete" runat="server" ClientIDMode="Static" OnClick="BtnDelete_Click" Text="Hidden Delete" />
</div>
