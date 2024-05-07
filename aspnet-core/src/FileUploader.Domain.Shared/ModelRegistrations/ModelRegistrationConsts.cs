namespace FileUploader.ModelRegistrations
{
    public static class ModelRegistrationConsts
    {
        private const string DefaultSorting = "{0}Model asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ModelRegistration." : string.Empty);
        }

    }
}