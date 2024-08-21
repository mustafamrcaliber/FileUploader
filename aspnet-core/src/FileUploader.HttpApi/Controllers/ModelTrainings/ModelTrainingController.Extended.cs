using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.ModelTrainings;

namespace FileUploader.Controllers.ModelTrainings
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ModelTraining")]
    [Route("api/app/model-trainings")]

    public class ModelTrainingController : ModelTrainingControllerBase, IModelTrainingsAppService
    {
        public ModelTrainingController(IModelTrainingsAppService modelTrainingsAppService) : base(modelTrainingsAppService)
        {
        }
    }
}