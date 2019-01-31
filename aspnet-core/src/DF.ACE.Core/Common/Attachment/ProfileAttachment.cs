using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using DF.ACE.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DF.ACE.Common.Attachment
{
    [Table("ProfileAttachment")]
    public class ProfileAttachment : Entity, IHasCreationTime
    {
        
        public int Id { get; set; }
       
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public long ProfileId { get; set; }
        public String ImagePath { get; set; } 
        public DateTime CreationTime { get; set; }

    }
}
