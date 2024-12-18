using System;

namespace AbpPoc.Parts;

public abstract class PartDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}