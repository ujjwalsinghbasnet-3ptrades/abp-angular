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

namespace AbpPoc.PartTests
{
    public class EfCorePartTestRepository : EfCorePartTestRepositoryBase, IPartTestRepository
    {
        public EfCorePartTestRepository(IDbContextProvider<AbpPocDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}