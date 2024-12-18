using System.Threading.Tasks;

namespace AbpPoc.Data;

public interface IAbpPocDbSchemaMigrator
{
    Task MigrateAsync();
}
