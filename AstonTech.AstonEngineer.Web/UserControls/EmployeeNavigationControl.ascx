<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeNavigationControl.ascx.cs" Inherits="AstonTech.AstonEngineer.Web.UserControls.EmployeeNavigationControl" %>

<div class="EmployeeNavigationContainer BorderRadius BorderRadiusTop">
    <div class="FloatLeft">
        <asp:DropDownList   runat="server" 
                            ID="EmployeeSelectList" 
                            DataTextField="FullNameLastNameFirst" 
                            DataValueField="EmployeeId" 
                            CssClass="SmallText" 
                            AutoPostBack="true"
                            OnSelectedIndexChanged="EmployeeSelectList_Selected"
         />
    </div>
    <div class="FloatRight">
        <asp:ListView runat="server" ID="EmployeeNavigationList" ItemPlaceholderID="EmployeeNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="EmployeeNavigationPlaceholder" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" ID="EmployeeNavigationLink" NavigateUrl='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>'>
                        <%# Eval("Text") %>
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>