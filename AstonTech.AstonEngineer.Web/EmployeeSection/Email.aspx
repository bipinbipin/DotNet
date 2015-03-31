<%@ Page Title="" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="AstonTech.AstonEngineer.Web.EmployeeSection.Email" %>
<%@ Register TagPrefix="CustomAstonEngineer" TagName="EmployeeNavigation" Src="~/UserControls/EmployeeNavigationControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/Email.js"></script>
    <asp:HiddenField runat="server" ID="EmailId" Value="0" />
    <CustomAstonEngineer:EmployeeNavigation runat="server" ID="CustomEmployeeNavigation" />
    <div id="EmployeeContainer">
        <div class="PageMessage"><asp:Label runat="server" ID="PageMessage" /></div>
        <table>
            <tr>
                <td><label>Eamil Address:</label></td>
                <td><asp:TextBox runat="server" ID="EmailAddressField" MaxLength="50" CssClass="EmailAddressField"/></td>
            </tr>
            <tr>
                <td><label>Email Type:</label></td>
                <td><asp:DropDownList runat="server" ID="EmailTypeList" DataTextField="EntityTypeValue" DataValueField="EntityTypeId" CssClass="EmailTypeField"/></td>
            </tr>
        </table>
        <div class="ContainerBar">
            <asp:Button runat="server" Text="Add Email" ID="SaveButton" OnClick="Save_Click" OnClientClick="return ValidateClientForm()" />
        </div>
        <br />
        <asp:Repeater runat="server" ID="EmailList" OnItemDataBound="EmailList_OnItemDataBound">
            <HeaderTemplate>
                <table class="ListStyle BorderRadiusAll" width="100%">
                    <tr>
                        <th>&nbsp;</th>
                        <th>Email Address</th>
                        <th>Email Type</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="CenterText">
                        <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="EmailButton_Command" CommandName="Edit">
                        </asp:LinkButton><asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="EmailButton_Command" CommandName="Delete" />
                    </td>
                    <td class="CenterText"><%#Eval("EmailValue") %></td>
                    <td class="CenterText"><%#Eval("EmailType.EntityTypeValue") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td class="ListStyleAlternate CenterText">
                        <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="EmailButton_Command" CommandName="Edit">
                        </asp:LinkButton><asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="EmailButton_Command" CommandName="Delete" />
                    </td>
                    <td class="ListStyleAlternate CenterText"><%#Eval("EmailValue") %></td>
                    <td class="ListStyleAlternate CenterText"><%#Eval("EmailType.EntityTypeValue") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
