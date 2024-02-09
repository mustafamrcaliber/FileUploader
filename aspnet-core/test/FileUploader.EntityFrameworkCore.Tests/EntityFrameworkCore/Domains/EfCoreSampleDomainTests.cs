using FileUploader.Samples;
using Xunit;

namespace FileUploader.EntityFrameworkCore.Domains;

[Collection(FileUploaderTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<FileUploaderEntityFrameworkCoreTestModule>
{

}
