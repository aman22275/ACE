using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ACE.Common.Attachment.Dto
{
    [AutoMapFrom(typeof(Attachment))]
    class TaskAttachmentDto : EntityDto, IHasCreationTime
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public String ImagePath { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
