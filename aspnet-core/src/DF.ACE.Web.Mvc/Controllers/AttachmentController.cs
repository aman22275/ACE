using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using DF.ACE.Common.Attachment;
using DF.ACE.Common.Attachment.Dto;
using DF.ACE.Web.Models.Common.Attachment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DF.ACE.Web.Mvc.Controllers
{
    public class AttachmentController : AbpController
    {
        private readonly IAttachmentManager _attachment;
        private readonly IAttachmentAppService _a;
        private readonly IRepository<Attachment> _repository;
        private IHostingEnvironment hostingEnv;
        public AttachmentController(IAttachmentAppService a,
                                    IAttachmentManager attachment,
                                    IRepository<Attachment> repository,
                                    IHostingEnvironment env)
        {
            _a = a;           
            _attachment = attachment;
            _repository = repository;
            this.hostingEnv = env;
        }
        public async Task<ActionResult> Index()
        {
            var output = await _a.GetAllData();
            var model = new AttachmentViewModel(output);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateWithForm");
        }

        //Method to Insert Image in Database, without Services
        [HttpPost]
        public IActionResult Create( AttachmentDto attachmentDto)
        {
                  
            _a.Create(attachmentDto);
            //return View(new AttachmentCreateModel());
            return RedirectToAction("Index", "Attachment");
        }

        public IActionResult Update(int id)
        {
            var output = _attachment.GetAttachmentById(id);
            var model = new AttachmentUpdateModel(output);
            return View(model);
            
        }

        [HttpPost]
        public IActionResult Update(UpdateAttachmentInput input)
        {
            _a.Update(input);
            return RedirectToAction("Index", "Attachment");
        }

        public IActionResult Get(int id)
        {
            var output = _attachment.GetAttachmentById(id);
            var model = new AttachmentGetModel(output);
            return View(model);

        }

       /* public IActionResult GetTitle(int id)
        {
            var output = _repository.Get(id);
            var model = new AttachmentTitleModel {
                Title = output.Title
            };
            return View(model);

        }*/

   
    }
}