<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmParameters.aspx.cs" Inherits="diseasePrediction.Admin.frmParameters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelFeatureTypes" runat="server">
  <div class="article">
			<h2 class="title">
                <span>View Parameters</span></h2>
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Table ID="tableParameters" runat="server">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
           
   

        <br />

   
   </div>
 

        <br />
         
   
  
   </asp:Panel>
</asp:Content>
