using DF.ACE.Common.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DF.ACE.Web.Models.Profile
{
    public class EditEntireProfileModel
    {
        public EditProfileModel EditProfileModel { get; set; }
        public EditAdditionalUserProfileModel EditAdditionalUserProfileModel { get; set; }

        public ProfilePictureModel ProfilePictureModel { get; set; }
    }
}
