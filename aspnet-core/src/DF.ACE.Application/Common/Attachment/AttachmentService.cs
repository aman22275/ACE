using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using DF.ACE.Common.Attachment.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.ACE.Common.Attachment
{
    public class AttachmentService : ApplicationService, IAttachmentService
    {
        private readonly IRepository<Attachment> _attachment;
        private readonly IAttachmentManager _iattachmentService;
        public AttachmentService(IRepository<Attachment> attachment, IAttachmentManager iattachmentService)
        {
            _attachment = attachment;
            _iattachmentService = iattachmentService;
        }


        public async Task<List<GetAttachmentByIdOutput>> GetAllData()
        {
            var tasks = await _attachment
                    .GetAll()
                    .OrderByDescending(t => t.CreationTime)
                    .ToListAsync();
            return new List<GetAttachmentByIdOutput>(ObjectMapper.Map<List<GetAttachmentByIdOutput>>(tasks));
        }

        public GetAttachmentByIdOutput GetAttachmentById(GetAttachmentByIdInput input)
        {
            var getAttachment = _iattachmentService.GetAttachmentById(input.Id);
            GetAttachmentByIdOutput output = Mapper.Map<Attachment, GetAttachmentByIdOutput>(getAttachment);
            return output;
        }

        public void Update(UpdateAttachmentInput input)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteAttachmentInput input)
        {
            throw new NotImplementedException();
        }
    }
}
