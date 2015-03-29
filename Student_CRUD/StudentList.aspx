<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="Student_CRUD.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>學生基本資料</title>
    <meta charset="utf-8">
    <link rel="shortcut icon" href="http://www.veryicon.com/icon/png/System/Fruity%20Apples/Seablue%20512.png">
    <link rel="stylesheet" href="./css/basicStyle.css">

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                <td><asp:TextBox ID="textbox_name_box" runat="server" Class="queryBox box" placeholder="以姓名查詢"></asp:TextBox></td>
                <td><asp:Button ID="button_do_query" OnClick="btnQuery_Click" runat="server" Text="查詢" Class="queryButton button" /></td>
                </tr>
            </table>
            <br /><br />

            <asp:GridView ID="grid_view_student" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

            
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="label_name_insert" runat="server" Text="姓名" ></asp:Label>
                        <asp:TextBox ID="textbox_name_insert" runat="server" Class="insertBox box"></asp:TextBox>
                    </td>

                    <td>
                        <asp:Label ID="label_birthday_insert" runat="server" Text="生日"></asp:Label>
                        <asp:TextBox ID="textbox_birthday_insert" runat="server" Class="insertBox box" placeholder="格式：yyyy/mm/dd"></asp:TextBox>
                    </td>

                    <td>
                        <asp:Label ID="label_information_insert" runat="server" Text="備註"></asp:Label>
                        <asp:TextBox ID="textbox_information_insert" runat="server" Class="insertBox box" placeholder="可填可不填"></asp:TextBox>
                    </td>

                    <td colspan="2">
                        <asp:Button ID="button_do_insert" runat="server" Text="新增" OnClick="button_do_insert_Click" class="insertButton button"/>
                    </td>
                </tr>

                <tr>
                     <td>
                        <asp:Label ID="label_id_update" runat="server" Text="學號"></asp:Label>
                        <asp:TextBox ID="textbox_id_update" runat="server" Class="updateBox box" placeholder="輸入要修改的學號"></asp:TextBox>
                     </td>

                     <td>
                        <asp:Label ID="label_name_update" runat="server" Text="姓名"></asp:Label>
                        <asp:TextBox ID="textbox_name_update" runat="server" Class="updateBox box"></asp:TextBox>
                    </td>

                    <td>
                        <asp:Label ID="label_birthday_update" runat="server" Text="生日"></asp:Label>
                        <asp:TextBox ID="textbox_birthday_update" runat="server" Class="updateBox box" placeholder="格式：yyyy/mm/dd"></asp:TextBox>
                    </td>
                    
                    <td>
                        <asp:Label ID="label_information_update" runat="server" Text="備註"></asp:Label>
                        <asp:TextBox ID="textbox_information_update" runat="server" Class="updateBox box" placeholder="可填可不填"></asp:TextBox>
                    </td>

                    <td>
                        <asp:Button ID="button_do_update" runat="server" Text="修改" OnClick="button_do_update_Click" class="updateButton button"/>
                    </td>
            
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label_id_delete" runat="server" Text="編號"></asp:Label>
                        <asp:TextBox ID="textbox_id_delete" runat="server" Class="deleteBox box" placeholder="輸入要刪除的學號"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        <asp:Button ID="button_do_delete" runat="server" Text="刪除" OnClick="button_do_delete_Click" class="deleteButton button"/>
                    </td>
                </tr>
        </table>
        </div>
    </form>
</body>
</html>
