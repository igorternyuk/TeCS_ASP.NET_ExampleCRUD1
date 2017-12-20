<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="db_contacts.View.Default" %>
<%@ Import Namespace="db_contacts.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contacts</title>
</head>
<body>
<h1>Contacts</h1>
    <table border="1" cellpadding="1" cellspacing="1"  style="font-size: 16px">
        <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Sex</th>
            <th>Age</th>
            <th>Phone</th>
            <th>Actions</th>
        </tr>
        <%
            Data data = new Data();
            foreach(Contact c in data.ReadAll())
            {
                Response.Write("<tr>");
                Response.Write("<td>" + c.Id + "</td>");
                Response.Write("<td>" + c.Name + "</td>");
                Response.Write("<td>" + (c.Sex == "m" ? "Male" : "Female")+ "</td>");
                Response.Write("<td>" + c.Age + "</td>");
                Response.Write("<td>" + c.Phone + "</td>");
                Response.Write("<td> <a href='../Controller/UpdateFormHandler.ashx?id=" + c.Id + "'>Edit</a> | ");
                Response.Write("<a href='../Controller/RemoveContactHandler.ashx'>Remove</a> </td>");
                Response.Write("</tr>");
            }            
        %>
        <form action="../Controller/CreateContactHandler.ashx" method="post"  style="font-size: 16px">
            <tr>
                <td>ID</td>
                <td>
                    <input type="text" name="txtName"/>
                </td>
                <td>
                    <input type="radio" name="radioSex" value="m" />Male
                    <input type="radio" name="radioSex" value="f" checked="checked"/>Female
                </td>
                <td>
                    <input type="text" name="txtAge"/>
                </td>
                <td>
                    <input type="text" name="txtPhone"/>
                </td>
                <td>
                    <input type="submit" name="btnRegister" value = "Register..."/>
                </td>
            </tr>
        </form>                
    </table>
    <br />
    <form action="../Controller/SearchContactHandler.ashx" method="post">
        <input type="text" name="txtSearchFilter" style="font-size: 16px"/>
        <input type="submit" name="btnSearch" value="Search by name" style="font-size: 20px"/>
    </form>
</body>
</html>
