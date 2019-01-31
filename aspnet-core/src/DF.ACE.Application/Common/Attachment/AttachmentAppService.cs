using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using Castle.Core.Logging;
using DF.ACE.Common.Attachment.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DF.ACE.Common.Attachment
{
    public class AttachmentAppService : ApplicationService, IAttachmentAppService, ITransientDependency
    {
        private readonly IRepository<Attachment> _attachment;
        private readonly IAttachmentManager _iattachmentService;
        private readonly IRepository<Demo> _demo;
        private IHostingEnvironment hostingEnv;
        private readonly IAbpSession _session;
       
        public AttachmentAppService(IRepository<Attachment> attachment,
                                 IAttachmentManager iattachmentService,
                                 IHostingEnvironment env,
                                 IRepository<Demo> demo,
                                 IAbpSession session)
        {
            _attachment = attachment;
            _iattachmentService = iattachmentService;
            hostingEnv = env;
            _demo = demo;
           
            _session = session;
        }


        public async Task<List<GetAttachmentByIdOutput>> GetAllData()
        {
            var userId = _session.UserId;
            var tasks = await _attachment
                    .GetAll()
                    .OrderByDescending(t => t.CreationTime)
                    .ToListAsync();
            return new List<GetAttachmentByIdOutput>(ObjectMapper.Map<List<GetAttachmentByIdOutput>>(tasks));
        }



        public GetAttachmentByIdOutput GetAttachmentById(GetAttachmentByIdInput input)
        {
            Logger.Info("We use method to get by id - " + input.Id);
            var getAttachment = _iattachmentService.GetAttachmentById(input.Id);
            GetAttachmentByIdOutput output = Mapper.Map<Attachment, GetAttachmentByIdOutput>(getAttachment);
            return output;
        }

        public async Task Create(AttachmentDto attachmentDto)
        {
            // IFormFile up = attachmentDto.files.FirstOrDefault();
            long size = 0;
            foreach (var file in attachmentDto.F)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                var c = "/images/" + filename;
                filename = hostingEnv.WebRootPath + $@"\images\{filename}";
                size += file.Length;

                var db = new CreateAttachmentInput();
                db.ImagePath = c;
                db.Title = attachmentDto.Title;
                db.Description = attachmentDto.Description;

                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    await _attachment.InsertOrUpdateAsync(ObjectMapper.Map<Attachment>(db));
                }
            }
           
            //  var task = ObjectMapper.Map<Attachment>(db);         
            // await _attachment.InsertAsync(task);
        }


        public void Update(UpdateAttachmentInput input)
        {
            long size = 0;
           //var id = _attachment.FirstOrDefault(x => x.Id == input.Id);
            var id = 1;
            if (id == null)
            {
                throw new UserFriendlyException("no id");
            }
            else
            {
                foreach (var file in input.F)
                {
                    var filename = ContentDispositionHeaderValue
                                    .Parse(file.ContentDisposition)
                                    .FileName
                                    .Trim('"');
                    var c = "/images/" + filename;
                    filename = hostingEnv.WebRootPath + $@"\images\{filename}";
                    size += file.Length;
                    var cc = id;
                  
                   Attachment update = _attachment.FirstOrDefault(x => x.Id == input.Id);
                    update.ImagePath = c;
                    update.Title = input.Title;
                    update.Description = input.Description;
                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        file.CopyToAsync(stream);                   
                        _attachment.UpdateAsync(update);
                    }
                    //  _attachment.Update(ObjectMapper.Map<Attachment>(input));
                }

            }




        }

        public async Task Delete(DeleteAttachmentInput input)
        {
            await _attachment.DeleteAsync(input.Id);
        }

    }
}
