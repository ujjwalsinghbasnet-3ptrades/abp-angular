./build-image.ps1 -ProjectPath "../../src/AbpPoc.DbMigrator/AbpPoc.DbMigrator.csproj" -ImageName abppoc/dbmigrator
./build-image.ps1 -ProjectPath "../../src/AbpPoc.Web.Public/AbpPoc.Web.Public.csproj" -ImageName abppoc/webpublic
./build-image.ps1 -ProjectPath "../../src/AbpPoc.HttpApi.Host/AbpPoc.HttpApi.Host.csproj" -ImageName abppoc/httpapihost
./build-image.ps1 -ProjectPath "../../angular" -ImageName abppoc/angular -ProjectType "angular"
