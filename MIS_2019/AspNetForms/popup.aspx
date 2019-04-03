<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="MIS_2019.AspNetForms.popup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>popup</title>
     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
</head>
<body id="pageBody" runat="server">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="WIDTH: 745px; HEIGHT: 320px; border:0">
            <tr>
                <td>

                    <asp:ImageButton ID="butFirst" runat="server" ImageUrl="../Images/first.gif" OnClick="butFirst_Click"></asp:ImageButton>
                    <asp:ImageButton ID="butPrev" runat="server" ImageUrl="../Images/Prev.gif" OnClick="butPrev_Click"></asp:ImageButton>
                    <asp:Label ID="lblPageCap" runat="server">Page</asp:Label>
                    <asp:Label ID="lblPage" runat="server"></asp:Label>
                    <asp:Label ID="lblPageOF" runat="server">OF</asp:Label>
                    <asp:Label ID="lblPageCount" runat="server"></asp:Label>
                    <asp:ImageButton ID="butNext" runat="server" ImageUrl="../Images/next.gif" OnClick="butNext_Click">

                    </asp:ImageButton><asp:ImageButton ID="butLast" runat="server" ImageUrl="../Images/last.gif" OnClick="butLast_Click"></asp:ImageButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" Width="100%"
                        EnableViewState="False" PageSize="15">
                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                        <SelectedItemStyle Font-Size="Smaller" Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                        <EditItemStyle Font-Size="Smaller"></EditItemStyle>
                        <AlternatingItemStyle Font-Size="Smaller"></AlternatingItemStyle>
                        <ItemStyle Font-Size="Smaller" ForeColor="#330099" BackColor="White"></ItemStyle>
                        <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
                        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"
                            Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                    <asp:Table ID="tblFind" runat="server" Width="720px" Height="8px"></asp:Table>
                </td>
            </tr>          
        </table>
    </form>
</body>
</html>
