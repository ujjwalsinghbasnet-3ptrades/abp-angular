using AbpPoc.Ipbs;
using AbpPoc.Documents;
using AbpPoc.Parts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using AbpPoc.Books;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.CmsKit.EntityFrameworkCore;

namespace AbpPoc.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class AbpPocDbContext :
    AbpDbContext<AbpPocDbContext>,
    ISaasDbContext,
    IIdentityProDbContext
{
    public DbSet<Ipb> Ipbs { get; set; } = null!;
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<Part> Parts { get; set; } = null!;
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Book> Books { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public AbpPocDbContext(DbContextOptions<AbpPocDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureLanguageManagement();
        builder.ConfigureFileManagement();
        builder.ConfigureSaas();
        builder.ConfigureChat();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureGdpr();
        builder.ConfigureCmsKit();
        builder.ConfigureCmsKitPro();
        builder.ConfigureBlobStoring();

        builder.Entity<Book>(b =>
        {
            b.ToTable(AbpPocConsts.DbTablePrefix + "Books",
                AbpPocConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AbpPocConsts.DbTablePrefix + "YourEntities", AbpPocConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        if (builder.IsHostDatabase())
        {
            builder.Entity<Part>(b =>
            {
                b.ToTable(AbpPocConsts.DbTablePrefix + "Parts", AbpPocConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.name).HasColumnName(nameof(Part.name)).IsRequired();
                b.Property(x => x.description).HasColumnName(nameof(Part.description));
                b.Property(x => x.partNumber).HasColumnName(nameof(Part.partNumber)).IsRequired();
                b.Property(x => x.cageCode).HasColumnName(nameof(Part.cageCode)).IsRequired();
                b.Property(x => x.toNumber).HasColumnName(nameof(Part.toNumber)).IsRequired();
                b.Property(x => x.distributionStatement).HasColumnName(nameof(Part.distributionStatement));
                b.Property(x => x.smr).HasColumnName(nameof(Part.smr));
                b.Property(x => x.niin).HasColumnName(nameof(Part.niin));
                b.Property(x => x.fsc).HasColumnName(nameof(Part.fsc));
                b.Property(x => x.wuc).HasColumnName(nameof(Part.wuc));
                b.Property(x => x.uoc).HasColumnName(nameof(Part.uoc));
                b.Property(x => x.uniqueId).HasColumnName(nameof(Part.uniqueId));
                b.Property(x => x.nsn).HasColumnName(nameof(Part.nsn)).IsRequired();
                b.Property(x => x.imageUrl).HasColumnName(nameof(Part.imageUrl));
            });

        }

        if (builder.IsHostDatabase())
        {
            builder.Entity<Document>(b =>
            {
                b.ToTable(AbpPocConsts.DbTablePrefix + "Documents", AbpPocConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.name).HasColumnName(nameof(Document.name)).IsRequired();
                b.Property(x => x.size).HasColumnName(nameof(Document.size));
                b.Property(x => x.type).HasColumnName(nameof(Document.type));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<Ipb>(b =>
            {
                b.ToTable(AbpPocConsts.DbTablePrefix + "Ipbs", AbpPocConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.figureName).HasColumnName(nameof(Ipb.figureName)).IsRequired().HasMaxLength(IpbConsts.figureNameMaxLength);
                b.Property(x => x.figureNumber).HasColumnName(nameof(Ipb.figureNumber)).IsRequired().HasMaxLength(IpbConsts.figureNumberMaxLength);
                b.Property(x => x.toNumber).HasColumnName(nameof(Ipb.toNumber)).HasMaxLength(IpbConsts.toNumberMaxLength);
                b.Property(x => x.indentureLevel).HasColumnName(nameof(Ipb.indentureLevel)).HasMaxLength(IpbConsts.indentureLevelMaxLength);
                b.HasOne<Part>().WithMany().HasForeignKey(x => x.sourceId).OnDelete(DeleteBehavior.SetNull);
                b.HasOne<Part>().WithMany().HasForeignKey(x => x.relatedId).OnDelete(DeleteBehavior.SetNull);
            });

        }
    }
}