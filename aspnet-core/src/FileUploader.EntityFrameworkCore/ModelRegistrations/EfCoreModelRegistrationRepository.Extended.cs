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

namespace FileUploader.ModelRegistrations
{
    public class EfCoreModelRegistrationRepository : EfCoreModelRegistrationRepositoryBase, IModelRegistrationRepository
    {
        public EfCoreModelRegistrationRepository(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}