using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.Models.Models.Theme
{
    public class ThemeModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedUtc { get; set; }
        public int CommentsCount { get; set; }
    }
}
