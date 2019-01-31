using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DF.ACE.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DF.ACE.AdditionalUserProfile.Dto
{
    [AutoMapFrom(typeof(UserProfile))]
    public class AdditionalUserProfileDto : EntityDto
    {
        [Key]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public DateTime Birthdate { get; set; }

        //Address Starts
        public String Line1 { get; set; }

        public String Line2 { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public String ZipCode { get; set; }
        
        //Address Ends

        public String FullAddress { get; set; }

    }
}
