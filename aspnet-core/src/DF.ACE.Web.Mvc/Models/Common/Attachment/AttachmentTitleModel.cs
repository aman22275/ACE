using DF.ACE.Common.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attachments = DF.ACE.Common.Attachment;
namespace DF.ACE.Web.Models.Common.Attachment
{
    public class AttachmentTitleModel
    {
        

        public String Title { get; set; }
        public String Description { get; set; }
        public String ImagePath { get; set; }
        public DateTime CreationTime { get; set; }


        //public string Title { get; set; }
    }
}
