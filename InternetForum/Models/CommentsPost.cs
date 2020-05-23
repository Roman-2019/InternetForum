using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetForum.Models
{
    public class CommentsPost
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public SelectList Posts { get; set; }

        public PostViewModel PostViewModel { get; set; }
    }
}