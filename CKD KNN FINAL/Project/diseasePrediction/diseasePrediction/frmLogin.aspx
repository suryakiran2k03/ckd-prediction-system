<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="diseasePrediction.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../ThemeBlue.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style2
        {
            width: 335px;
        }
        .style3
        {
            width: 171px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelLogin" runat="server">
  <div class="article">
			<h2>User Login Form!!!</h2>
    <br />
           
            <table style="width: 50%;">
            <tr>
                <td align="center" valign="top">
                    <table style="width: 80%; background-image: url('../images/login.gif'); height: 300px;" 
                        align="left">
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; color: #006699; width: 239px">
                                <strong>Select User Type</strong></td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:DropDownList ID="DropDownListType" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>
                                    <asp:ListItem>Receptionist</asp:ListItem>
                                    <asp:ListItem>Doctor</asp:ListItem>
                                    <asp:ListItem>Patient</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 154px">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="DropDownListType" CssClass="tag_nav" 
                                    ErrorMessage="Select User Type" ForeColor="#FF3300" Operator="NotEqual" 
                                    ToolTip="Select User Type" ValidationGroup="login" ValueToCompare="Select">*</asp:CompareValidator>
                            </td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px; color: #006699;">
                                <b>UserId</b></td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:TextBox ID="txtUserId" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 154px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtUserId" ErrorMessage="Enter UserId" ToolTip="Enter UserId" 
                                    ValidationGroup="login" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px; color: #006699;">
                                <b>Password</b></td>
                            <td style="text-align: left; width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 154px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Enter Password" ToolTip="Enter Password" 
                                    ValidationGroup="login" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/CAUVGTUR.jpg" 
                                    ValidationGroup="login" Height="34px" 
                                    Width="83px" onclick="btnLogin_Click" />
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
                <tr>
                    <td align="center" style="width: 510px;" valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                       <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" 
                        class="Error" align="center" style="width: 510px">
                        <tr>
                            <td style="text-align: left">
                                <div ID="dvIcon" class="Error">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        CssClass="failureNotification" ToolTip="Enter Fields" 
                                        ValidationGroup="login" />
                                </div>
                            </td>
                        </tr>
                    </table></td>
                </tr>
        </table>

        <br />
         
   
   </div>
 
   </asp:Panel>

</asp:Content>
