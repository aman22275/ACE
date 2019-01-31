using Abp.Application.Services;
using DF.ACE.Common.Attachment.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DF.ACE.Common.Attachment
{
    public interface IAttachmentService : IApplicationService
    {

        Task<List<GetAttachmentByIdOutput>> GetAllData();
        GetAttachmentByIdOutput GetAttachmentById(GetAttachmentByIdInput input);

        void Update(UpdateAttachmentInput input);
        void Delete(DeleteAttachmentInput input);
    }
}
