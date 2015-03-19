<%@ Page Title="" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="AstonTech.AstonEngineer.Web.EmployeeSection.Email" %>
<%@ Register TagPrefix="CustomAstonEngineer" TagName="EmployeeNavigation" Src="~/UserControls/EmployeeNavigationControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="EmailId" Value="0" />
    <CustomAstonEngineer:EmployeeNavigation runat="server" ID="CustomEmployeeNavigation" />
    <div id="EmployeeContainer">
        <table>
            <tr>
                <td><label>Eamil Address:</label></td>
                <td><asp:TextBox runat="server" ID="EmailAddressField" MaxLength="50" /></td>
            </tr>
            <tr>
                <td><label>Email Type:</label></td>
                <td><asp:DropDownList runat="server" ID="EmailTypeList" DataTextField="EntityTypeValue" DataValueField="EntityTypeId"/></td>
            </tr>
        </table>
        <div class="ContainerBar">
            <asp:Button runat="server" Text="Add Email" ID="SaveButton" OnClick="Save_Click" />
        </div>

    </div>
</asp:Content>
