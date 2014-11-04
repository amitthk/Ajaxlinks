using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ajaxPostDemo
{
    public partial class posted : System.Web.UI.Page
    {


        private const string _dataFileName = "Posts.config";

        private List<Posts> _posts;


        protected void Page_Load(object sender, EventArgs e)
        {
            Persister<Posts> currentPosts = new Persister<Posts>(_dataFileName);

            currentPosts.load();
            _posts = currentPosts.objList;

            if (Request.RequestType == "POST")
            {
                string strName = Request.Form["txtName"];
                string strEmail = Request.Form["txtEmail"];
                string strInquiry = Request.Form["txtInquiry"];
                Posts post = new Posts();
                post.Id = _posts.Count;
                post.Name = strName;
                post.Email = strEmail;
                post.Timestamp = DateTime.Now;
                post.Inquiry = strInquiry;
                _posts.Add(post);
                currentPosts.save();
            }
            rptrPosts.DataSource = _posts;
            rptrPosts.DataBind();
        }

        protected bool IsJsonRequest()
        {
            string requestedWith = Request.ServerVariables["HTTP_X_REQUESTED_WITH"] ?? string.Empty;
            return string.Compare(requestedWith, "XMLHttpRequest", true) == 0
                && Request.ContentType.ToLower().Contains("application/json");
        }
    }
}