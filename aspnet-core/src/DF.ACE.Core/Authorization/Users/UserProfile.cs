
using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DF.ACE.Authorization.Users
{
    [Table("ACE_UserProfiles")]
    public class UserProfile : Entity
    {
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

    }
}
