<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="Compare.aspx.cs" Inherits="diseasePrediction.Doctor.Compare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelAdminAccount" runat="server">
  <div class="article">
			<h2>Comparative Analysis!!!</h2>

            <table style="width:100%;">
                <tr>
                    <td>
                       <h3>Result Analysis</h3></td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="Table3" runat="server">
                        </asp:Table>
                    </td>
                </tr>
            </table>
            <br />
            
            <table style="width:100%;">
                <tr>
                    <td>
                        <h4>Naive Bayes Output</h4></td>
                    <td>
                        <h4>KNN Output</h4></td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
                    </td>
                    <td>
                        <asp:Table ID="Table2" runat="server">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                            Font-Size="Small" onclick="LinkButton1_Click">Confusion Matrix NB</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" 
                            Font-Size="Small" onclick="LinkButton2_Click">Confusion Matrix KNN</asp:LinkButton>
                    </td>
                </tr>
            </table>
            
    <br />
           
    

        <br />
         
   
   </div>
 
   </asp:Panel>

</asp:Content>
