using DF.ACE.Common.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attachments = DF.ACE.Common.Attachment;


namespace DF.ACE.Web.Models.Common.Attachment
{
    public class AttachmentGetModel
    {
        public Attachments.Attachment Tasks { get; }
        public AttachmentGetModel(Attachments.Attachment tasks)
        {
            Tasks = tasks;
        }

    }
}
