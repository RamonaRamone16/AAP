using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.Entities
{
    public class Comment : BaseEntity<int>
    {
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
