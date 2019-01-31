using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DF.ACE.Common.Attachment
{
   
        [Table("Attachment")]
        public class Attachment : Entity, IHasCreationTime
        {
        
            public String Title { get; set; }         
            public String Description { get; set; }
            public String ImagePath { get; set; }
            public DateTime CreationTime { get; set; }

          
        }
    
}
