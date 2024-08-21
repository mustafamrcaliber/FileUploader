namespace FileUploader.ModelConfigurations
{
    public static class ModelConfigurationConsts
    {
        private const string DefaultSorting = "{0}SystemPrompt asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ModelConfiguration." : string.Empty);
        }

    }
}