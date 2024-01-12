using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Core.Converters;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Data.Products;
using Qrdentity.Web.Data.Utility;

namespace Qrdentity.Web.Data;

public class QrdentityContext : DbContext
{
    public DbSet<Organization> Organizations { get; set; }

    public DbSet<OrganizationAddress> OrganizationAddresses { get; set; }

    public DbSet<ContactInformation> OrganizationContacts { get; set; }

    public DbSet<TaxOffice> TaxOffices { get; set; }

    public DbSet<OrganizationAgreement> OrganizationAgreements { get; set; }

    public DbSet<BusinessSubType> BusinessSubTypes { get; set; }

    public DbSet<BusinessType> BusinessTypes { get; set; }

    public DbSet<OrganizationBusiness> OrganizationBusinesses { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<District> Districts { get; set; }

    public DbSet<QrProduct> QrProducts { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public DbSet<MultiFactorRegistrationGroup> MultiFactorRegistrationGroups { get; set; }

    public DbSet<MultiFactorRegistrationSettingHistory> MultiFactorRegistrationSettingsHistory { get; set; }

    public DbSet<MultiFactorSetting> MultiFactorSettings { get; set; }

    public DbSet<MultiFactorRegistrationSetting> MultiFactorRegistrationSettings { get; set; }

    [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
    public QrdentityContext(DbContextOptions<QrdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        DateTime now = DateTime.UtcNow;

        List<ITrackableEntity> modifiedEntries = ChangeTracker.Entries()
            .Where(eachEntity => eachEntity.State == EntityState.Modified)
            .Select(eachEntity => eachEntity.Entity).OfType<ITrackableEntity>().ToList();

        foreach (ITrackableEntity changedEntity in modifiedEntries)
        {
            changedEntity.ModifiedDate = now;
            changedEntity.UpdatedBy = DataConstants.AdminUserId;
            Entry(changedEntity).Property(x => x.ModifiedDate).IsModified = true;
        }

        List<ITrackableEntity> addedEntries = ChangeTracker.Entries()
            .Where(eachEntity => eachEntity.State == EntityState.Added)
            .Select(eachEntity => eachEntity.Entity).OfType<ITrackableEntity>().ToList();

        foreach (ITrackableEntity changedEntity in addedEntries)
        {
            changedEntity.CreatedDate = now;
            changedEntity.CreatedBy = DataConstants.AdminUserId;
            Entry(changedEntity).Property(x => x.CreatedDate).IsModified = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
}