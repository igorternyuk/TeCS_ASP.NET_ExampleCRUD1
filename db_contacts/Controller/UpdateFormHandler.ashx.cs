using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db_contacts.Model;

namespace db_contacts.Controller
{
    /// <summary>
    /// Сводное описание для UpdateFormHandler
    /// </summary>
    public class UpdateFormHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";            
            int id = Convert.ToInt32(context.Request.Params["id"]);
            Data data = new Data();
            Contact contact = data.ReadById(id);
            List<Contact> allContacts = data.ReadAll();
            context.Response.Write("<head runat='server'>");
            context.Response.Write("<title>Edit page</title>");
            context.Response.Write("</head>");
            context.Response.Write("<body>");
            context.Response.Write("<h1>Contacts</h1>");
            context.Response.Write("<table border='1' cellpadding='1' cellspacing='1'  style='font-size: 16px'>");
            context.Response.Write("<tr>");
            context.Response.Write("<th>ID</th>");
            context.Response.Write("<th>Name</th>");
            context.Response.Write("<th>Sex</th>");
            context.Response.Write("<th>Age</th>");
            context.Response.Write("<th>Phone</th>");
            context.Response.Write("<th>Actions</th>");
            context.Response.Write("<tr>");

            foreach (Contact c in data.ReadAll())
            {
                if (c.Id == id)
                {
                    context.Response.Write("<form action='EditContactHandler.ashx' method='post' style='font-size: 16px'>");
                    context.Response.Write("<tr>");
                    context.Response.Write("<td>");
                    context.Response.Write("<input type='text' name='txtId' readonly='readonly' value ='" + c.Id + "'/>");
                    context.Response.Write("</td>");
                    context.Response.Write("<td>");
                    context.Response.Write("<input type='text' name='txtName' value ='" + c.Name + "'/>");
                    context.Response.Write("</td>");
                    context.Response.Write("<td>");
                    if (c.Sex == "m")
                    {
                        context.Response.Write("<input type='radio' name='radioSex' value='m'  checked='checked'/>Male");
                        context.Response.Write("<input type='radio' name='radioSex' value='f'/>Female");
                    }
                    else
                    {
                        context.Response.Write("<input type='radio' name='radioSex' value='m' />Male");
                        context.Response.Write("<input type='radio' name='radioSex' value='f' checked='checked'/>Female");
                    }
                    context.Response.Write("</td>");
                    context.Response.Write("<td>");
                    context.Response.Write("<input type='text' name='txtAge' value='" + c.Age + "'/>");
                    context.Response.Write("</td>");
                    context.Response.Write("<td>");
                    context.Response.Write("<input type='text' name='txtPhone' value='" + c.Phone + "'/>");
                    context.Response.Write("</td>");
                    context.Response.Write("<td>");
                    context.Response.Write("<input type='submit' name='btnUpdate' value = 'Update...'/>");
                    context.Response.Write("</td>");
                    context.Response.Write("</tr>");
                    context.Response.Write("</form>");           
                }
                else 
                {
                    context.Response.Write("<tr>");
                    context.Response.Write("<td>" + c.Id + "</td>");
                    context.Response.Write("<td>" + c.Name + "</td>");
                    context.Response.Write("<td>" + (c.Sex == "m" ? "Male" : "Female") + "</td>");
                    context.Response.Write("<td>" + c.Age + "</td>");
                    context.Response.Write("<td>" + c.Phone + "</td>");
                    context.Response.Write("<td> <a href='../Controller/UpdateFormHandler.ashx?id=" + c.Id + "'>Edit</a> </td>");
                    context.Response.Write("<td> <a href='../Controller/RemoveContactHandler.ashx'>Remove</a> </td>");
                    context.Response.Write("</tr>");
                }
            }

            context.Response.Write("</table>");
            context.Response.Write("<br />");
            context.Response.Write("<a href='../View/Default.aspx'  style='font-size: 16px'>Go back</a>");
            context.Response.Write("</body>");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}