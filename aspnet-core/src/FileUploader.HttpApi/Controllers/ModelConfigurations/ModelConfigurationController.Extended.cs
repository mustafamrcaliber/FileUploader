using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.ModelConfigurations;

namespace FileUploader.Controllers.ModelConfigurations
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ModelConfiguration")]
    [Route("api/app/model-configurations")]

    public class ModelConfigurationController : ModelConfigurationControllerBase, IModelConfigurationsAppService
    {
        public ModelConfigurationController(IModelConfigurationsAppService modelConfigurationsAppService) : base(modelConfigurationsAppService)
        {
        }
    }
}