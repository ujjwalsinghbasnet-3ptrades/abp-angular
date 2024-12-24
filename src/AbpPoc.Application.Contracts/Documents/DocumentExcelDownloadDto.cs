using Volo.Abp.Application.Dtos;
using System;

namespace AbpPoc.Documents
{
    public abstract class DocumentExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? name { get; set; }
        public int? sizeMin { get; set; }
        public int? sizeMax { get; set; }
        public string? type { get; set; }

        public DocumentExcelDownloadDtoBase()
        {

        }
    }
}