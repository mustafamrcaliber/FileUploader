using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFileBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? FileName { get; set; }

        [CanBeNull]
        public virtual string? FilePath { get; set; }

        [CanBeNull]
        public virtual string? FileType { get; set; }

        [CanBeNull]
        public virtual string? FileSize { get; set; }

        protected UploadFileBase()
        {

        }

        public UploadFileBase(Guid id, string? fileName = null, string? filePath = null, string? fileType = null, string? fileSize = null)
        {

            Id = id;
            FileName = fileName;
            FilePath = filePath;
            FileType = fileType;
            FileSize = fileSize;
        }

    }
}