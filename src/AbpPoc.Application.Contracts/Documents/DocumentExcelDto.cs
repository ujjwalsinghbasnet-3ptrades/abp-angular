using System;

namespace AbpPoc.Documents
{
    public abstract class DocumentExcelDtoBase
    {
        public string name { get; set; } = null!;
        public int size { get; set; }
        public string? type { get; set; }
    }
}