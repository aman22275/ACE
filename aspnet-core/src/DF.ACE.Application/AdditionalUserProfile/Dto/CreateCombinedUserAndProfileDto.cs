using DF.ACE.Common.Attachment;
using DF.ACE.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ACE.AdditionalUserProfile.Dto
{
    public class CreateCombinedUserAndProfileDto
    {
        public CreateUserDto CreateUserDto { get; set; }
        public CreateAdditionalUserProfileDto CreateAdditionalUserProfileDto { get; set; }
        public ProfileAttachment ProfileAttachment { get; set; }
    }
}
