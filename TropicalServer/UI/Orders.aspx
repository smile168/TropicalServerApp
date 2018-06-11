<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="TropicalServer.UI.Orders" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" runat="server">
    <asp:DropDownList ID="ddlOrderDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrderDate_SelectedIndexChanged"  ></asp:DropDownList>
    <asp:DropDownList ID="ddlSalesManager" runat="server" DataSourceID="SalesManagerDataSource" DataTextField="CustOrderEntryContactName" DataValueField="CustOrderEntryContactName" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesManager_SelectedIndexChanged"></asp:DropDownList>

    <asp:TextBox ID="CustName" runat="server" AutoPostBack="True" OnTextChanged="CustName_TextChanged"></asp:TextBox>
    <asp:ScriptManager ID="scpt1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

    <ajax:AutoCompleteExtender ID="CustNameAuto" runat="server" 
        TargetControlID="CustName"
        EnableCaching="true"
        CompletionSetCount="1"
        MinimumPrefixLength="3"
        ServiceMethod="getCustName"
        CompletionInterval ="1000"
        ServicePath="~/TropicalServerWebService.asmx">
    </ajax:AutoCompleteExtender>


    <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>

    <asp:SqlDataSource ID="SalesManagerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TropicalServerConnectionString %>" SelectCommand="SELECT DISTINCT  [CustOrderEntryContactName]
	FROM tblOrder O
	INNER JOIN tblCustomer C
	ON O.OrderCustomerNumber = C.CustNumber 
order by  [CustOrderEntryContactName]"></asp:SqlDataSource>


    <asp:GridView ID="gvOrders" runat="server"
        DataKeyNames="orderID"
        OnRowDataBound="OnRowDataBound"
        OnRowDeleting="OnRowDeleting"
        EmptyDataText="No records has been added."

        OnSelectedIndexChanged="gvOrders_SelectedIndexChanged"
        OnRowEditing="OnRowEditing" 
        OnRowCancelingEdit="OnRowCancelingEdit" 
        OnRowUpdating="OnRowUpdating"        
 
        Width="198px"
        AutoGeneratecolumns="false">
        
        <Columns>
            <asp:TemplateField HeaderText="Tracking #">
                <ItemTemplate>
                    <asp:Label ID="lblTrackNum" runat="server" text='<%# Eval("Tracking #") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtTrackNum" runat="server" text='<%# Eval("Tracking #") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order Date">
                <ItemTemplate>
                    <asp:Label ID="lblOrderDate" runat="server" text='<%# Eval("Order Date") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtOrderDate" runat="server" text='<%# Eval("Order Date") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer ID">
                <ItemTemplate>
                    <asp:Label ID="lblCustId" runat="server" text='<%# Eval("Customer ID") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer Name">
                <ItemTemplate>
                    <asp:Label ID="lblCustName" runat="server" text='<%# Eval("Customer Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCustName" runat="server" text='<%# Eval("Customer Name") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="lblAddr" runat="server" text='<%# Eval("Address") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddr" runat="server" text='<%# Eval("Address") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Route #">
                <ItemTemplate>
                    <asp:Label ID="lblRoute" runat="server" text='<%# Eval("Route #") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtRoute" runat="server" text='<%# Eval("Route #") %>'>
                    </asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Available Actions">
                <ItemTemplate>
                 <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                 <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                 <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                 <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


    <br />
    </asp:Content>
