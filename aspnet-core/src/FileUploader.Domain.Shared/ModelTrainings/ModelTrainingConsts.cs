namespace FileUploader.ModelTrainings
{
    public static class ModelTrainingConsts
    {
        private const string DefaultSorting = "{0}Type asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ModelTraining." : string.Empty);
        }

    }
}