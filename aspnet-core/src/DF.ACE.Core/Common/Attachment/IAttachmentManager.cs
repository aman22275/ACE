using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ACE.Common.Attachment
{
    public interface IAttachmentManager : IDomainService
    {
        Attachment GetAttachmentById(int id);
    }
}
