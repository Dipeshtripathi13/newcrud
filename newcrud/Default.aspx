<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="newcrud._Default" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="System.Web.Optimization" TagPrefix="telerik" %>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default page</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1"></telerik:RadScriptManager>

        <div>
            <h1>Person Details</h1>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="true">
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default page</title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1"></telerik:RadScriptManager>

        <div>
            <h1>Person Details</h1>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

            <div>
                <label for="txtPid">Pid:</label>
                <asp:TextBox ID="txtPid" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPname">Pname:</label>
                <asp:TextBox ID="txtPname" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtCity">City:</label>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </div>

            <br />

            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="-1" GridLines="Both"
    OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand">
    <MasterTableView DataKeyNames="pid">
        <Columns>
            <telerik:GridBoundColumn DataField="pid" HeaderText="Pid" />
            <telerik:GridBoundColumn DataField="pname" HeaderText="Pname" />
            <telerik:GridBoundColumn DataField="city" HeaderText="City" />
            <telerik:GridButtonColumn UniqueName="DeleteColumn" CommandName="Delete" HeaderText="Delete" Text="Delete">
            </telerik:GridButtonColumn>
            <telerik:GridButtonColumn UniqueName="EditColumn" CommandName="Edit" HeaderText="Edit" Text="Edit">
            </telerik:GridButtonColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>


        </div>
    </form>
</body>
</html>