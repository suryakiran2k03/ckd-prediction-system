<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="KNNSinglePatient.aspx.cs" Inherits="diseasePrediction.Doctor.KNNSinglePatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">
 <div class="article">
			<h2>Single Patient CKD Prediction Using KNN Algorithm!!!</h2>
   
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <table style="width: 80%; ">
                    <tr>
                        <td class="style2">
                            <strong>Age</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtAge" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtAge" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Age" ValidationGroup="user">Enter Age</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                ControlToValidate="txtAge" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                                ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>BP</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtBP" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="txtBP" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter BP" ValidationGroup="user">Enter BP</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                ControlToValidate="txtBP" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                                ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>SpecificGravity</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtSpecificGravity" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="txtSpecificGravity" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter SpecificGravity" ValidationGroup="user">Enter SpecificGravity</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                                ControlToValidate="txtSpecificGravity" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Albumin</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtAlbumin" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAlbumin" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Albumin" ValidationGroup="user">Enter Albumin</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                                ControlToValidate="txtAlbumin" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                                ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Sugar</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtSugar" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtSugar" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Sugar" ValidationGroup="user">Enter Sugar</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                runat="server" ControlToValidate="txtSugar" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <strong>RedBloodCells</strong></td>
                        <td class="style1">
                            <asp:TextBox ID="txtRedBloodCells" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="txtRedBloodCells" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter RedBloodCells" ValidationGroup="user">Enter RedBloodCells</asp:RequiredFieldValidator>
                        </td>
                        <td class="style1">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                runat="server" ControlToValidate="txtRedBloodCells" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>PusCell</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtPusCell" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtPusCell" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter PusCell" ValidationGroup="user">Enter PusCell</asp:RequiredFieldValidator>
                            &nbsp;</td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                runat="server" ControlToValidate="txtPusCell" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>PusCellClumps</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtPusCellClumps" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPusCellClumps" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter PusCellClumps" ValidationGroup="user">Enter PusCellClumps</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                                runat="server" ControlToValidate="txtPusCellClumps" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Bacteria</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtBacteria" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txtBacteria" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Bacteria" ValidationGroup="user">Enter Bacteria</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                                runat="server" ControlToValidate="txtBacteria" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>BloodGlucoseRandom</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtBloodGlucoseRandom" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="txtBloodGlucoseRandom" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter BloodGlucoseRandom" ValidationGroup="user">Enter BloodGlucoseRandom</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" 
                                runat="server" ControlToValidate="txtBloodGlucoseRandom" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>BloodUrea</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtBloodUrea" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="txtBloodUrea" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter BloodUrea" ValidationGroup="user">Enter BloodUrea</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" 
                                runat="server" ControlToValidate="txtBloodUrea" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>SerumCreatinine</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtSerumCreatinine" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="txtSerumCreatinine" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter SerumCreatinine" ValidationGroup="user">Enter SerumCreatinine</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" 
                                runat="server" ControlToValidate="txtSerumCreatinine" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Sodium</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtSodium" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                ControlToValidate="txtSodium" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Sodium" ValidationGroup="user">Enter Sodium</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" 
                                runat="server" ControlToValidate="txtSodium" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Potassium</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtPotassium" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                ControlToValidate="txtPotassium" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Potassium" ValidationGroup="user">Enter Potassium</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" 
                                runat="server" ControlToValidate="txtPotassium" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Hemoglobin</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtHemoglobin" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                ControlToValidate="txtHemoglobin" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Hemoglobin" ValidationGroup="user">Enter Hemoglobin</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" 
                                runat="server" ControlToValidate="txtHemoglobin" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>PackedCellVolume</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtPackedCellVolume" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                ControlToValidate="txtPackedCellVolume" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter PackedCellVolume" ValidationGroup="user">Enter PackedCellVolume</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" 
                                runat="server" ControlToValidate="txtPackedCellVolume" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>WhiteBloodCellCount</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtWhiteBloodCellCount" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                ControlToValidate="txtWhiteBloodCellCount" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter WhiteBloodCellCount" ValidationGroup="user" 
                                ViewStateMode="Enabled">Enter WhiteBloodCellCount</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" 
                                runat="server" ControlToValidate="txtWhiteBloodCellCount" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>RedBloodCellCount</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtRedBloodCellCount" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                ControlToValidate="txtRedBloodCellCount" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter RedBloodCellCount" ValidationGroup="user">Enter RedBloodCellCount</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator23" 
                                runat="server" ControlToValidate="txtRedBloodCellCount" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Hypertension</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtHypertension" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                ControlToValidate="txtHypertension" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Hypertension" ValidationGroup="user">Enter Hypertension</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator24" 
                                runat="server" ControlToValidate="txtHypertension" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>DiabetesMellitus</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtDiabetesMellitus" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                ControlToValidate="txtDiabetesMellitus" EnableTheming="True" ErrorMessage="*" 
                                Font-Size="X-Small" ForeColor="#FF3300" ToolTip="Enter DiabetesMellitus" 
                                ValidationGroup="user">Enter DiabetesMellitus</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" 
                                runat="server" ControlToValidate="txtDiabetesMellitus" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>CoronaryArteryDisease</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtCoronaryArteryDisease" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                ControlToValidate="txtCoronaryArteryDisease" ErrorMessage="*" 
                                Font-Size="X-Small" ForeColor="#FF3300" ToolTip="Enter CoronaryArteryDisease" 
                                ValidationGroup="user">Enter CoronaryArteryDisease</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator26" 
                                runat="server" ControlToValidate="txtCoronaryArteryDisease" 
                                ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                                ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Appetite</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtAppetite" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                                ControlToValidate="txtAppetite" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Appetite" ValidationGroup="user">Enter Appetite</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" 
                                runat="server" ControlToValidate="txtAppetite" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>PedalEdema</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtPedalEdema" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                                ControlToValidate="txtPedalEdema" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter PedalEdema" ValidationGroup="user">Enter PedalEdema</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator28" 
                                runat="server" ControlToValidate="txtPedalEdema" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <strong>Anemia</strong></td>
                        <td class="style4">
                            <asp:TextBox ID="txtAnemia" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                                ControlToValidate="txtAnemia" ErrorMessage="*" Font-Size="X-Small" 
                                ForeColor="#FF3300" ToolTip="Enter Anemia" ValidationGroup="user">Enter Anemia</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" 
                                runat="server" ControlToValidate="txtAnemia" ErrorMessage="Only Numbers" 
                                Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                                ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                                ValidationGroup="user"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style4">
                            <asp:Button ID="btnSubmit" runat="server" Height="50px" 
                                onclick="btnSubmit_Click" Text="Predict CKD" ValidationGroup="user" 
                                Width="200px" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
   

        <br />

   
                        <h2 class="title">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
            </h2>
                                 <br />
   
            <asp:Button ID="btnStage" runat="server" Height="50px" 
                onclick="btnStage_Click" Text="Stage Prediction" ValidationGroup="user" 
                Width="200px" Visible="False" />
   
        <br />
          <br />
            <br />
         
   
   </div>
 
   </asp:Panel>
</asp:Content>
