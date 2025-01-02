namespace AbpPoc.Ipbs
{
    public static class IpbConsts
    {
        private const string DefaultSorting = "{0}ipbIndex asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Ipb." : string.Empty);
        }

        public const int ipbIndexMaxLength = 8;
        public const int figureNameMaxLength = 256;
        public const int figureNumberMaxLength = 256;
        public const int toNumberMaxLength = 32;
        public const int indentureLevelMaxLength = 8;
    }
}