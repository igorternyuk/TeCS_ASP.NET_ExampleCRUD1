using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db_contacts.Model;

namespace db_contacts.Controller
{
    /// <summary>
    /// Сводное описание для SearchContactHandler
    /// </summary>
    public class SearchContactHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String searchFilter = context.Request.Params["txtSearchFilter"];
            Data data = new Data();
            List<Contact> list = data.Search(searchFilter);
            context.Response.ContentType = "text/html";
            context.Response.Write("<body>");
            int count = list.Count;
            if (count == 0)
            {
                context.Response.Write("<h1>Search results: No contacts found</h>");
                context.Response.Write("<br />");
            }
            else
            {
                if (count == 1)
                {
                    context.Response.Write("<h1>Search results: 1 contact was found</h>");
                }
                else
                {
                    context.Response.Write(String.Format("<h1>Search results: {0} contacts were found</h>", count));
                }
                context.Response.Write("<br /><br />");
                context.Response.Write("<table border='1' cellpadding='1' cellspacing='1'>");
                context.Response.Write("<tr>");
                context.Response.Write("<th>ID</th>");
                context.Response.Write("<th>Name</th>");
                context.Response.Write("<th>Sex</th>");
                context.Response.Write("<th>Age</th>");
                context.Response.Write("<th>Phone</th>");
                context.Response.Write("<tr>");
                foreach (var c in list)
                {
                    context.Response.Write("<tr>");
                    context.Response.Write("<td>" + c.Id + "</td>");
                    context.Response.Write("<td>" + c.Name + "</td>");
                    context.Response.Write("<td>" + (c.Sex == "m" ? "Male" : "Female") + "</td>");
                    context.Response.Write("<td>" + c.Age + "</td>");
                    context.Response.Write("<td>" + c.Phone + "</td>");
                    context.Response.Write("</tr>");
                }
                context.Response.Write("</table>");
            }            
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