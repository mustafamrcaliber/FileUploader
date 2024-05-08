using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FileUploader.UploadFiles;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Content;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Claims;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FileUploader.FileUploaderSaver
{
public class ExtraAppServices: FileUploaderAppService
{
    private readonly IConfiguration _iConfiguration;
    public ExtraAppServices(IConfiguration iConfiguration)
    {
        _iConfiguration = iConfiguration;
    }
    public string GetUrlForIFrame()
    {
        return _iConfiguration.GetSection("appSettings").GetSection("IFraneURL").Value;
    }
}
}