using DF.ACE.Common.Attachment.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DF.ACE.Web.Models.Common.Attachment
{
    public class AttachmentViewModel
    {

        public IReadOnlyList<GetAttachmentByIdOutput> Tasks { get; }
        public IFormFile ImagePath { get; set; }

        public AttachmentViewModel(IReadOnlyList<GetAttachmentByIdOutput> tasks)
        {
            Tasks = tasks;
        }
    }
}
