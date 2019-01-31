using Abp.AutoMapper;
using DF.ACE.Common.Attachment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DF.ACE.AdditionalUserProfile.Dto
{
    [AutoMapFrom(typeof(ProfileAttachment))]
    public class ProfilePicture
    {
        public int Id { get; set; }
        public long ProfileId { get; set; }
     
        public String ImagePath { get; set; }
        public DateTime CreationTime { get; set; }
        public IList<IFormFile> F { get; set; }
    }
}
