<%@ Page Title="SQLite / NHibernate Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SQLiteNHibernate._Default" %>
<%@ Register src="UserControls/CustomerEntry.ascx" tagname="CustomerEntry" tagprefix="uc1" %>
<%@ Register src="UserControls/CustomerGrid.ascx" tagname="CustomerGrid" tagprefix="uc2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script>
    $(function () {
        //var chevState = $("collapseTwo".target).siblings("i.indicator").toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
        //$("i.indicator").not(chevState).removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-up");

    });    
</script>

<div style="max-width:900px;min-width:860px; margin-left:auto;margin-right:auto;margin-top:20px;">

        <!-- Message Area -->
        <asp:Panel ID="PnlAlertMsg" CssClass="alert alert-success" runat="server" Visible="false">
              <a href="#" class="close" data-dismiss="alert">&times;</a>
              <strong>Success!:</strong>&nbsp;<asp:Label ID="LblMsg" runat="server"></asp:Label>
        </asp:Panel>

        <div class="panel-group" id="accordion">
              <div class="panel panel-default">
                <div class="panel-heading">
                  <h4 class="panel-title">
                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" style="text-decoration:none" href="#collapseOne">
                      &nbsp;Add New Customer
                    </a><i class="indicator glyphicon glyphicon-chevron-up  pull-left"></i>
                  </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse">
                  <div class="panel-body">
                       <uc1:CustomerEntry ID="CustomerEntry1" runat="server" />
                  </div>
                </div>
              </div>
        </div>

        <div class="panel panel-default" style="margin-top:-10px;">
                <div class="panel-heading">
                  <h4 class="panel-title">&nbsp;Customer List 
                  </h4>
                </div>
                <div id="collapseTwo" class="panel-collapse">
                  <div class="panel-body">
                      <uc2:CustomerGrid ID="CustomerGridUC" runat="server" />                     
                  </div>
                </div>
         </div>    
</div>

</asp:Content>
