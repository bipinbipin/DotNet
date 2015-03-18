<%@ Page Language="C#" AutoEventWireup="true" Theme="Main" MasterPageFile="~/MasterPages/Site2Column.Master" CodeBehind ="EmployeeBasic.aspx.cs" Inherits="AstonTech.AstonEngineer.Web.EmployeeSection.EmployeeBasic" EnableViewState="true" %>
<%@ Register TagPrefix="CustomAstonEngineer" TagName="EmployeeNavigation" Src="~/UserControls/EmployeeNavigationControl.ascx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <CustomAstonEngineer:EmployeeNavigation runat="server" ID="CustomEmployeeNavigation" />
        <div id="EmployeeContainer">
            <div class="PageMessage"><asp:Label runat="server" ID="PageMessage" /></div>
            <table>
                <tr>
                    <td><label>First Name:</label></td>
                    <td><asp:TextBox runat="server" ID="FirstName" MaxLength="50" /></td>
                </tr>
                <tr>
                    <td><label>Middle Name:</label></td>
                    <td><asp:TextBox runat="server" ID="MiddleName" MaxLength="50" /></td>
                </tr>
                <tr>
                    <td><label>Last Name:</label></td>
                    <td><asp:TextBox runat="server" ID="LastName" MaxLength="50" /></td>
                </tr>
                <tr>
                    <td><label>Date of Birth:</label></td>
                    <td><asp:TextBox runat="server" ID="BirthDate" MaxLength="10" />&nbsp;(mm/dd/yyyy)</td>
                </tr>
                <tr>
                    <td><label>Social Security Number:</label></td>
                    <td><asp:TextBox runat="server" ID="SSN" MaxLength="11" />&nbsp;(nnn-nn-nnnnn)</td>
                </tr>
                <tr>
                    <td><label>Date of Hire:</label></td>
                    <td><asp:TextBox runat="server" ID="HireDate" MaxLength="10" />&nbsp;(mm/dd/yyyy)</td>
                </tr>
                <tr>
                    <td><label>Date of Termination:</label></td>
                    <td><asp:TextBox runat="server" ID="TermDate" MaxLength="10" />&nbsp;(mm/dd/yyyy)</td>
                </tr>
                <tr>
                    <td><label>Category:</label></td>
                    <td>
                        <asp:DropDownList runat="server" ID="Category" DataTextField="EntityTypeValue" DataValueField="EntityTypeId" />
                    </td>
                </tr>
                <tr>
                    <td><label>Tier Level:</label></td>
                    <td>
                        <asp:DropDownList runat="server" ID="TierLevel" DataTextField="EntityTypeValue" DataValueField="EntityTypeId" />
                    </td>
                </tr>
                <tr>
                    <td><label>Pay Rate:</label></td>
                    <td><asp:TextBox runat="server" ID="PayRate" MaxLength="3" /></td>
                </tr>
                <tr>
                    <td><label>Laptop:</label></td>
                    <td>
                        <asp:DropDownList runat="server" ID="Laptop" DataTextField="EntityTypeValue" DataValueField="EntityTypeId" />
                    </td>
                </tr>
                <tr>
                    <td><label>Background Caveats:</label></td>
                    <td><asp:TextBox runat="server" ID="Background" TextMode="MultiLine" Rows="4" Columns="50" /></td>
                </tr>
            </table>
            <br />
            <div class="ContainerBar">
                <asp:Button runat="server" Text="Add Employee" ID="SaveButton" OnClick="Save_Click"/>
                <span class="FloatRight">
                    <asp:Button runat="server" 
                                id="DeleteButton"
                                Text="Delete"
                                OnClick="Delete_Click"
                                Visible="false" />
                </span>
                <asp:HiddenField runat="server" ID="PersonId" Value="0"/>
                <asp:HiddenField runat="server" ID="EmployeeId" Value="0"/>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


</asp:Content>