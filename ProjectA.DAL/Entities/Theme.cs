using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.Entities
{
    public class Theme : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
