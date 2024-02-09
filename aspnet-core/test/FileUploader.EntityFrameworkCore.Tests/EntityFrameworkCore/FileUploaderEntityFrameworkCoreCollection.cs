using Xunit;

namespace FileUploader.EntityFrameworkCore;

[CollectionDefinition(FileUploaderTestConsts.CollectionDefinitionName)]
public class FileUploaderEntityFrameworkCoreCollection : ICollectionFixture<FileUploaderEntityFrameworkCoreFixture>
{

}
