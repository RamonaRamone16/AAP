using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.Models.Models.Role
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
