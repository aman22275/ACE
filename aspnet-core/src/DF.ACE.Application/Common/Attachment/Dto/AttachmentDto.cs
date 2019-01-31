using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ACE.Common.Attachment.Dto
{
  public  class AttachmentDto
    {
        // public CreateAttachmentInput input { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImagePath { get; set; }
        public  IList<IFormFile> F { get; set; }

   
    }
}
