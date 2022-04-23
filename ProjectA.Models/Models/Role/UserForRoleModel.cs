using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.Models.Models.Role
{
    public class UserForRoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
