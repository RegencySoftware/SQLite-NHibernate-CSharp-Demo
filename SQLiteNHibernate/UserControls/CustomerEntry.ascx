<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerEntry.ascx.cs" Inherits="SQLiteNHibernate.UserControls.CustomerEntry" %>

<script>
    function EditCheck()
    {
        var Error = false;
        if ($("#TxtFirst").val() == '') Error = true; 
        if ($("#TxtLast").val() == '') Error = true;
        if ($("#TxtAddress").val() == '') Error = true;
        if ($("#TxtCity").val() == '') Error = true;
        if ($("#TxtState").val() == '') Error = true;
        if ($("#TxtZip").val() == '') Error = true;

        //Error get out
        if (Error == true) {
            $("#EditMsg").html("&nbsp;All Fields Are Required");
            return;
        }

        //Save
        BtnSave.click();
    }
</script>

<style>
  .lg-group
  {
      margin-top:5px;
      margin-left:10px;
      float:left;
      width:300px;
  }
  .misc-group
  {
      margin-top:5px;
      margin-left:10px;
      float:left;
  }
</style>

<div style="float:left;width:100%">
 
    <div class="input-group lg-group">
      <span class="input-group-addon" id="basic-addon1">First Name</span>
      <asp:TextBox ID="TxtFirst" ClientIDMode="Static"  MaxLength="50"  class="form-control" placeholder="First Name"  aria-describedby="basic-addon1" runat="server"></asp:TextBox>
    </div>

    <div class="input-group lg-group">
      <span class="input-group-addon" id="basic-addon2">Last Name</span>
      <asp:TextBox ID="TxtLast" ClientIDMode="Static" MaxLength="50"   class="form-control" placeholder="Last Name"  aria-describedby="basic-addon1" runat="server"></asp:TextBox>
    </div>

     <div class="input-group lg-group" style="float:left;">
      <span class="input-group-addon" id="basic-addon3" style="width:95px;">Address</span>
      <asp:TextBox ID="TxtAddress" ClientIDMode="Static" MaxLength="50"  class="form-control" placeholder="Address"  aria-describedby="basic-addon1" runat="server"></asp:TextBox>
    </div>

    <div style="float:left;width:100%">
        <div class="input-group lg-group">
          <span class="input-group-addon" id="basic-addon4" style="width:95px;">City</span>
          <asp:TextBox ID="TxtCity"  ClientIDMode="Static" MaxLength="50" class="form-control" placeholder="City"  aria-describedby="basic-addon1" runat="server"></asp:TextBox>
        </div>

        <div class="input-group misc-group" style="width:150px;">
          <span class="input-group-addon" id="basic-addon5">State</span>
          <asp:TextBox ID="TxtState" ClientIDMode="Static" MaxLength="2" class="form-control" style="text-transform: uppercase;" placeholder="State"  aria-describedby="basic-addon1" runat="server"></asp:TextBox>
        </div>

        <div class="input-group misc-group" style="width:150px;">
          <span class="input-group-addon" id="basic-addon6">Zip</span>
          <asp:TextBox ID="TxtZip" ClientIDMode="Static" MaxLength="5" class="form-control" placeholder="Zip"  aria-describedby="basic-addon1" runat="server"></asp:TextBox>
        </div>
    </div>
</div>

<div style="float:left;margin-top:20px;">
    <input id="BtnDeleteCustRow" class="btn btn-primary" type="button" onclick='EditCheck()' value="Save Customer" />
    <span id="EditMsg" style="color:red;"></span>
    
    <!-- Hidden Save Button called after edits passed -->
    <asp:Button ID="BtnSave" ClientIDMode="Static" style="visibility:hidden" CssClass="btn btn-primary" runat="server" Text="Save Customer" OnClick="BtnSave_Click" />
</div>