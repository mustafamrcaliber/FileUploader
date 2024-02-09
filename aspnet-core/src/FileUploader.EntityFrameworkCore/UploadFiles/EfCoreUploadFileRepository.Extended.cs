using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using FileUploader.EntityFrameworkCore;

namespace FileUploader.UploadFiles
{
    public class EfCoreUploadFileRepository : EfCoreUploadFileRepositoryBase, IUploadFileRepository
    {
        public EfCoreUploadFileRepository(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}