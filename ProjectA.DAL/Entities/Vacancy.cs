using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.Entities
{
    public class Vacancy : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
