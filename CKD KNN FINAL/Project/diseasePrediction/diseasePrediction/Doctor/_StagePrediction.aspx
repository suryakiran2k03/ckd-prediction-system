<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="_StagePrediction.aspx.cs" Inherits="diseasePrediction.Doctor._StagePrediction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .style2
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelAdminAccount" runat="server">
   <div class="article">
			<h2>Stage Detection Using GFR!!!</h2>

            <asp:Panel ID="Panel2" runat="server">
                <table style="width:50%;">
                <tr>
                        <td>
                            <b>Name</b></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtName" CssClass="error" ErrorMessage="Enter Name" 
                                ToolTip="Enter Name" ValidationGroup="a">Enter Name</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Age</b></td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TextBox1" CssClass="error" ErrorMessage="*" 
                                ToolTip="Enter Age" ValidationGroup="a">Enter Age</asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" ControlToValidate="TextBox1" CssClass="error" ErrorMessage="*" 
                                ToolTip="Only Numbers" ValidationExpression="^(0|[1-9]\d*)(\.\d+)?$" 
                                ValidationGroup="a">Only Numbers</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Gender</b></td>
                        <td>
                            <asp:DropDownList ID="DropDownListGender" runat="server">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                           <b> SC</b></td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            mg/dl</td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox3" CssClass="error" ErrorMessage="*" 
                                ToolTip="Enter SC" ValidationGroup="a">Enter SC</asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                runat="server" ControlToValidate="TextBox3" CssClass="error" ErrorMessage="*" 
                                ToolTip="Only Numbers" ValidationExpression="^(0|[1-9]\d*)(\.\d+)?$" 
                                ValidationGroup="a">Only Numbers</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblGRF" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            </td>
                        <td class="style1">
                            <asp:Button ID="btnAlgorithm1" runat="server" onclick="btnAlgorithm1_Click" 
                                Text="Predict Stage" ValidationGroup="a" />
                        </td>
                        <td class="style1">
                            </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            </td>
                        <td class="style2">
                            </td>
                        <td class="style2">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblOutput" runat="server" Font-Bold="True" Font-Size="Medium" 
                                ForeColor="#006699"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <asp:LinkButton ID="lbtnDiet" runat="server" Font-Bold="True" 
                    Font-Size="Medium" onclick="lbtnDiet_Click">Diet Recc</asp:LinkButton>
                <br />
            </asp:Panel>
            
    <br />
           
         
   </div>
           
  
   </asp:Panel>

</asp:Content>
