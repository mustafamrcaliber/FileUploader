namespace FileUploader.UploadFiles
{
    public static class UploadFileConsts
    {
        private const string DefaultSorting = "{0}FileName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UploadFile." : string.Empty);
        }

    }
}