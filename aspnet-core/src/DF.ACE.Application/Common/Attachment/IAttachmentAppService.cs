using Abp.Application.Services;
using DF.ACE.Common.Attachment.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DF.ACE.Common.Attachment
{
    public interface IAttachmentAppService : IApplicationService
    {

        Task<List<GetAttachmentByIdOutput>> GetAllData();
        GetAttachmentByIdOutput GetAttachmentById(GetAttachmentByIdInput input);
        Task Create(AttachmentDto attachmentDto);
        void Update(UpdateAttachmentInput input);
        Task Delete(DeleteAttachmentInput input);
    }
}
