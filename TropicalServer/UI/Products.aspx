<%@ Page Title="Product Page" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TropicalServer.UI.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
         <link id="Link1" href="../AppThemes/TropicalStyles/Products.css" runat="server" rel="stylesheet" type="text/css" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="productCategories">
            <div>
            <asp:Repeater ID="rpProCat" runat="server"  >
                <HeaderTemplate>
                    <asp:Label runat="server" Cssclass="productCategoriesLabel" Text="PRODUCT CATEGORIES"></asp:Label>
               
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Button CssClass="productCategoriesLabelitem"  ID="btnProCat" runat="server" Text='<%#Eval("ItemTypeDescription")%>' CommandArgument='<%# Eval("ItemTypeDescription") %>' OnClick="btnProCat_Click"></asp:Button>
                            </td>
                        </tr>
                     </table>  
                </ItemTemplate>
            </asp:Repeater>
        </div>
            <div class="chartdisplay"  >
            <asp:GridView CssClass="dataGrid" ID="gvProductItem" runat="server" AllowPaging="True"  PageSize="5"  >

            </asp:GridView>
            </div>
        
            <br />
        
        </div>


</asp:Content>
