using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectA.DAL.Entities
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Theme> Themes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Ad> Ads { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
