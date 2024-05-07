using FileUploader.ModelRegistrations;
using FileUploader.ModelConfigurations;
using System;
using FileUploader.Shared;
using Volo.Abp.AutoMapper;
using FileUploader.UploadFiles;
using AutoMapper;

namespace FileUploader;

public class FileUploaderApplicationAutoMapperProfile : Profile
{
    public FileUploaderApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<UploadFile, UploadFileDto>();
        CreateMap<UploadFile, UploadFileExcelDto>();

        CreateMap<ModelConfiguration, ModelConfigurationDto>();

        CreateMap<ModelRegistration, ModelRegistrationDto>();
    }
}