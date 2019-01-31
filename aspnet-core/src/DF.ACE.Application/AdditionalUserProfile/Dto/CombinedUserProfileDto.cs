using DF.ACE.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ACE.AdditionalUserProfile.Dto
{
    public class CombinedUserProfileDto
    {
        public UserDto UserDto { get; set; }
        public AdditionalUserProfileDto AdditionalUserProfileDto { get; set; }
    }
}
