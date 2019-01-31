using DF.ACE.Web.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DF.ACE.Web.Models.Profile
{
    public class EntireUserModel
    {
        public UserListViewModel UserListViewModel { get; set; }
        public EditAdditionalUserProfileModel EditAdditionalUserProfileModel { get; set; }
    }
}
