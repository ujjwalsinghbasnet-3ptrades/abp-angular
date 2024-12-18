namespace AbpPoc.PartTests
{
    public static class PartTestConsts
    {
        private const string DefaultSorting = "{0}partNumber asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PartTest." : string.Empty);
        }

    }
}