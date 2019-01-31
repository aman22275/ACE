using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ACE.Common.Attachment
{
    public class AttachmentManager : DomainService, IAttachmentManager
    {
        private readonly IRepository<Attachment> _repository;
        public AttachmentManager(IRepository<Attachment> repository)
        {
            _repository = repository;
        }

        public Attachment GetAttachmentById(int id)
        {
            return _repository.Get(id);
        }
    }
}

