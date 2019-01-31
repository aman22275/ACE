using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DF.ACE.Common.Attachment;
using Attachments = DF.ACE.Common.Attachment;

namespace DF.ACE.Web.Models.Common.Attachment
{
    public class AttachmentUpdateModel
    {
        public Attachments.Attachment Tasks { get; }
        public AttachmentUpdateModel(Attachments.Attachment tasks)
        {
            Tasks = tasks;
        }


    }
}
