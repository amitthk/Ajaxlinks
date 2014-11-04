using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ajaxPostDemo
{
    public partial class getposts : System.Web.UI.Page
    {
        private const string dataFileName = "Posts.config";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear(); //optional: if we've sent anything before
            Response.ContentType = "text/html"; //must be 'text/xml'
            Response.ContentEncoding = System.Text.Encoding.UTF8; //we'd like UTF-8

            Response.Write(readPosts());
            Response.End(); //optional: will end processing

        }

        private string readPosts()
        {
            Persister<Posts> persister = new Persister<Posts>(dataFileName);
            persister.load();
            //Serialize of generic list inot Json using JavaScriptSerializer
            return (Newtonsoft.Json.JsonConvert.SerializeObject(persister.objList));
        }
    }
}