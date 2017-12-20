using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using db_contacts.Model;

namespace db_contacts.Controller
{
    /// <summary>
    /// Сводное описание для RemoveContactHandler
    /// </summary>
    public class RemoveContactHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String id = context.Request.Params["id"];
            new Data().Delete(id);
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