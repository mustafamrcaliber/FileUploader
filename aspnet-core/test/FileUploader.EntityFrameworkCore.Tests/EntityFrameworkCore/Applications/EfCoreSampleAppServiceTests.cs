using FileUploader.Samples;
using Xunit;

namespace FileUploader.EntityFrameworkCore.Applications;

[Collection(FileUploaderTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<FileUploaderEntityFrameworkCoreTestModule>
{

}
