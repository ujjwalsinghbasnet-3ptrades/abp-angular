using System;

namespace AbpPoc.Documents;

public abstract class DocumentDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}