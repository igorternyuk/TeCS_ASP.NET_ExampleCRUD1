using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db_contacts.Model;

namespace db_contacts.Controller
{
    /// <summary>
    /// Сводное описание для CreateContactHandler
    /// </summary>
    public class CreateContactHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Data data = new Data();
            Contact newContact = new Contact();
            newContact.Name = context.Request.Params["txtName"];
            newContact.Sex = context.Request.Params["radioSex"];
            newContact.Age = Convert.ToInt32(context.Request.Params["txtAge"]);
            newContact.Phone = context.Request.Params["txtPhone"];
            data.Create(newContact);
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