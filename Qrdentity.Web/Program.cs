using Qrdentity.Web;
using Qrdentity.Web.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<ICodeGeneratorService, CodeGeneratorService>();

string? connectionStringFromConfiguration = builder.Configuration.GetConnectionString("Qrdentity");
//The app will not run if the connection string does not have value. No need to check for nullability as of now
builder.Services.AddQrdentityContext(connectionStringFromConfiguration!);

builder.Services.AddMemoryCache();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

//app.Services.RunMigrations();
//await app.Services.SeedData();

app.Run();