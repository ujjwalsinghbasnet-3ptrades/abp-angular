using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using AbpPoc.EntityFrameworkCore;

namespace AbpPoc.Ipbs
{
    public class EfCoreIpbRepository : EfCoreIpbRepositoryBase, IIpbRepository
    {
        public EfCoreIpbRepository(IDbContextProvider<AbpPocDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}