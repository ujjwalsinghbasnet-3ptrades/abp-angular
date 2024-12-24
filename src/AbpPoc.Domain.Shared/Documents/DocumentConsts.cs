namespace AbpPoc.Documents
{
    public static class DocumentConsts
    {
        private const string DefaultSorting = "{0}name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Document." : string.Empty);
        }

    }
}