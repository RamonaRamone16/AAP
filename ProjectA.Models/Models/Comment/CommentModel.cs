using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.Models.Models.Comment
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedUtc { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
