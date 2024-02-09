using Volo.Abp.Settings;

namespace FileUploader.Settings;

public class FileUploaderSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FileUploaderSettings.MySetting1));
    }
}
