<%@ Page Title="Log In" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TropicalServer.UI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
           <link id="Link1" href="../AppThemes/TropicalStyles/Login.css" runat="server" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <%--<asp:Login ID="Login3" runat="server" Height="177px" Width="372px">
    </asp:Login>--%>
       <div id="container">
        <div id="BodyDetail">
                <label id="Loginlbl">MOBILE CUSTOMERORDER TRACKING</label>
               <div id="loginBox">
<%--                  <label id="useridlbl">User ID:  <input id="useridtextbox" type="text"></label>--%>
                   <asp:Label ID="useridlbl" runat="server" Text="User ID: "></asp:Label>
                   <asp:TextBox ID="useridtextbox" runat="server"></asp:TextBox>
<%--                  <label id="passwordlbl">Password<input id="passwordtextbox" type="text"></label>--%>
                   <asp:Label ID="passwordlbl" runat="server" Text="Password: "></asp:Label>
                   <asp:TextBox ID="passwordtextbox" runat="server" />
                      <div id="login">
                         

                            <asp:CheckBox ID="rmbcheck" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Remember my ID" />
                         

                            <asp:Button id="loginButton" runat="server" BackColor="Black" ForeColor="White" text="Log-In" OnClick="loginButton_Click" Font-Bold="True" Width="65px"/>
                      </div>
                      <div id="errorBox">
                            <asp:Label ID="errlbl" runat="server" Text="Incorrect User Credentials" ForeColor="Red" ></asp:Label>
                      </div>
               </div>
                <div id="forgot">
                    <asp:Label ID="fgid" runat="server"  Text="<a href = '#' target=_blank>Forget Username</a> " />
                    <asp:Label ID="fgpw" runat="server"  Text="<a href = 'ForgetPassword.aspx' target=_blank>Forget Password</a> " />
                </div>
        </div>
    </div>


</asp:Content>
