namespace AbpPoc.Ipbs
{
    public static class IpbConsts
    {
        private const string DefaultSorting = "{0}figureName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Ipb." : string.Empty);
        }

        public const int figureNameMaxLength = 256;
        public const int figureNumberMaxLength = 32;
        public const int toNumberMaxLength = 512;
        public const int indentureLevelMaxLength = 8;
    }
}