using System.Collections.Generic;
using DF.ACE.Roles.Dto;
using DF.ACE.Users.Dto;

namespace DF.ACE.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
