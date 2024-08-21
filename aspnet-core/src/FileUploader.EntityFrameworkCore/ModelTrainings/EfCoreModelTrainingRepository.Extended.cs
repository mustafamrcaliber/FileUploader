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

namespace FileUploader.ModelTrainings
{
    public class EfCoreModelTrainingRepository : EfCoreModelTrainingRepositoryBase, IModelTrainingRepository
    {
        public EfCoreModelTrainingRepository(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}