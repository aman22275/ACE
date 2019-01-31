using DF.ACE.Common.Attachment.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DF.ACE.Web.Models.Common.Attachment
{
    public class AttachmentCreateModel
    {
       // public CreateAttachmentInput input { get; set; }
        //public IList<IFormFile> F { get; set; }
        /* public List<AttachmentDto> Create { get; set; }

         public AttachmentCreateModel(List<AttachmentDto> create)
         {
             Create = create;
         }

         public AttachmentCreateModel()
         {
         }*/
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImagePath { get; set; }
    }
}
