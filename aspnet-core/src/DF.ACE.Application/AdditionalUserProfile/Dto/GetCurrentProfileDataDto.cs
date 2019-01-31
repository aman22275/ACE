using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ACE.AdditionalUserProfile.Dto
{
    public class GetCurrentProfileDataDto
    {
        [Required]
        public long UserId { get; set; }

    }
}
