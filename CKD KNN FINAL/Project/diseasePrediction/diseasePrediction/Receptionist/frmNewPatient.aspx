<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionist/Receptionist.Master" AutoEventWireup="true" CodeBehind="frmNewPatient.aspx.cs" Inherits="diseasePrediction.Receptionist.frmNewPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">
 <div class="article">
			<h2>Add New Patient!!!</h2>
            <table style="width: 70%; height: 124px;">
                <tr>
                    <td class="style2">
                        <strong>Name</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtPatientName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPatientName" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter PatientName" ValidationGroup="user">Enter PatientName</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Age</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtAge" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtAge" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter Age" ValidationGroup="user">Enter Age</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Mobile</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtMobile" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter BP" ValidationGroup="user">Enter BP</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Address</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtAddress" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtAddress" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter SpecificGravity" ValidationGroup="user">Enter SpecificGravity</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                            Text="Submit" ValidationGroup="user" />
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    <br />
           
   

        <br />

   
                        <h2 class="title"><span>View New Patients</span></h2>
                            <table style="width:100%;">

                                <tr>
                                    <td>
                                        <asp:Table ID="tablePatients" runat="server">
                                        </asp:Table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                                 <br />
   
        <br />
         
   
   </div>
 
   </asp:Panel>


</asp:Content>
