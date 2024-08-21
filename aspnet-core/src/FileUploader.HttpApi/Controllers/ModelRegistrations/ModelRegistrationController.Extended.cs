using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.ModelRegistrations;

namespace FileUploader.Controllers.ModelRegistrations
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ModelRegistration")]
    [Route("api/app/model-registrations")]

    public class ModelRegistrationController : ModelRegistrationControllerBase, IModelRegistrationsAppService
    {
        public ModelRegistrationController(IModelRegistrationsAppService modelRegistrationsAppService) : base(modelRegistrationsAppService)
        {
        }
    }
}