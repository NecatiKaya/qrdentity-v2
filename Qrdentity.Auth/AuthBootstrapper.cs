using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qrdentity.Auth.Data;

namespace Qrdentity.Auth;

public static class AuthBootstrapper
{
    public static void AddAuthContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString, op =>
            {
                op.MigrationsAssembly(nameof(ApplicationDbContext));
                op.MigrationsHistoryTable("__EFMigrationsHistory", "users");
            });
        });
    }

    public static void RunMigrations(this IServiceProvider provider)
    {
        using (IServiceScope scope = provider.CreateScope())
        {
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }

    public static void AddIdentity(IServiceCollection services, string connectionString)
    {
        services.AddIdentity<QrdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                options.EmitStaticAudienceClaim = true;
            }).AddConfigurationStore(options => options.ConfigureDbContext = b => b.UseSqlite(connectionString,
                opt => opt.MigrationsAssembly(migrationsAssembly)))
            .AddOperationalStore(options => options.ConfigureDbContext = b => b.UseSqlite(connectionString,
                opt => opt.MigrationsAssembly(migrationsAssembly)))
  
            .AddAspNetIdentity<IdentityUser>();

        services.AddAuthentication();
    }
}