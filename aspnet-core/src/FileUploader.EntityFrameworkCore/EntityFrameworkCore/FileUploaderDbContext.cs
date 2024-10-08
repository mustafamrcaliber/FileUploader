using FileUploader.ModelTrainings;
using FileUploader.ModelRegistrations;
using FileUploader.ModelConfigurations;
using FileUploader.UploadFiles;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;

namespace FileUploader.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class FileUploaderDbContext :
    AbpDbContext<FileUploaderDbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    public DbSet<ModelTraining> ModelTrainings { get; set; } = null!;
    public DbSet<ModelRegistration> ModelRegistrations { get; set; } = null!;
    public DbSet<ModelConfiguration> ModelConfigurations { get; set; } = null!;
    public DbSet<UploadFile> UploadFiles { get; set; } = null!;
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

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

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public FileUploaderDbContext(DbContextOptions<FileUploaderDbContext> options)
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
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(FileUploaderConsts.DbTablePrefix + "YourEntities", FileUploaderConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        if (builder.IsHostDatabase())
        {
            builder.Entity<UploadFile>(b =>
            {
                b.ToTable(FileUploaderConsts.DbTablePrefix + "UploadFiles", FileUploaderConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.FileName).HasColumnName(nameof(UploadFile.FileName));
                b.Property(x => x.FilePath).HasColumnName(nameof(UploadFile.FilePath));
                b.Property(x => x.FileType).HasColumnName(nameof(UploadFile.FileType));
                b.Property(x => x.FileSize).HasColumnName(nameof(UploadFile.FileSize));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ModelConfiguration>(b =>
            {
                b.ToTable(FileUploaderConsts.DbTablePrefix + "ModelConfigurations", FileUploaderConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.SystemPrompt).HasColumnName(nameof(ModelConfiguration.SystemPrompt));
                b.Property(x => x.Temperature).HasColumnName(nameof(ModelConfiguration.Temperature));
                b.Property(x => x.TopK).HasColumnName(nameof(ModelConfiguration.TopK));
                b.Property(x => x.TopP).HasColumnName(nameof(ModelConfiguration.TopP));
                b.Property(x => x.RepeatPenalty).HasColumnName(nameof(ModelConfiguration.RepeatPenalty));
                b.Property(x => x.ContextLength).HasColumnName(nameof(ModelConfiguration.ContextLength));
                b.Property(x => x.MaxTokens).HasColumnName(nameof(ModelConfiguration.MaxTokens));
            });

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ModelRegistration>(b =>
            {
                b.ToTable(FileUploaderConsts.DbTablePrefix + "ModelRegistrations", FileUploaderConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Model).HasColumnName(nameof(ModelRegistration.Model));
                b.Property(x => x.ApiPath).HasColumnName(nameof(ModelRegistration.ApiPath));
                b.Property(x => x.LocalPath).HasColumnName(nameof(ModelRegistration.LocalPath));
                b.Property(x => x.Schedule).HasColumnName(nameof(ModelRegistration.Schedule));
                b.Property(x => x.Interval).HasColumnName(nameof(ModelRegistration.Interval));
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<ModelTraining>(b =>
            {
                b.ToTable(FileUploaderConsts.DbTablePrefix + "ModelTrainings", FileUploaderConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Type).HasColumnName(nameof(ModelTraining.Type));
                b.Property(x => x.Path).HasColumnName(nameof(ModelTraining.Path));
                b.Property(x => x.DataSource).HasColumnName(nameof(ModelTraining.DataSource));
                b.Property(x => x.DatabaseConnectionString).HasColumnName(nameof(ModelTraining.DatabaseConnectionString));
                b.Property(x => x.DocumentsDirectoryPath).HasColumnName(nameof(ModelTraining.DocumentsDirectoryPath));
                b.Property(x => x.Mode).HasColumnName(nameof(ModelTraining.Mode));
                b.Property(x => x.TrainingLog).HasColumnName(nameof(ModelTraining.TrainingLog));
            });

        }
    }
}