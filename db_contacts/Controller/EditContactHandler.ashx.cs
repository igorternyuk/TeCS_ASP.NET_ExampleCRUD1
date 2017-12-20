using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db_contacts.Model;

namespace db_contacts.Controller
{
    /// <summary>
    /// Сводное описание для EditContactHandler
    /// </summary>
    public class EditContactHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Data data = new Data();
            Contact c = new Contact();
            int id = Convert.ToInt32(context.Request.Params["txtId"]);
            String name = context.Request.Params["txtName"];
            int age = Convert.ToInt32(context.Request.Params["txtAge"]);
            String phone = context.Request.Params["txtPhone"];
            c.Id = id;
            c.Name = name;
            c.Age = age;
            c.Phone = phone;
            data.Update(c);
            context.Response.Redirect("../View/Default.aspx");            
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