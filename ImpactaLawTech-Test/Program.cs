using ImpactaLawTech_Test.Filters;
using ImpactaLawTech_Test.Seeds;
using LawTech.Application.Models.Commands.Users;
using LawTech.Application.Models.Commands.Users.Login;
using LawTech.Context.Default.Entities;
using LawTech.Infra.Context.Persistence.Context.Default;
using LawTech.Infra.Ioc;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;
using Task = System.Threading.Tasks.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ResolveDependencyInjection.RegisterServices(builder.Services, builder.Configuration);

builder.Services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                });

builder.Services.AddControllers(config =>
{
    config.Filters.Add<TokenFilter>(order: 1);
});

builder.Services.AddDbContext<DefaultContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(UserCommandProfile));
builder.Services.AddMediatR(typeof(LoginUserCommand).Assembly);



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Impacta.TaskManagerAPI", Version = "v1" });
    OpenApiSecurityScheme jwtSecurityScheme = new()
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

    c.OperationFilter<TokenHeaderParameter>();

});

async Task<IApplicationBuilder> LoadSeeds(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var services = scope.ServiceProvider;
    var defaultContext = services.GetRequiredService<DefaultContext>();

    var defaultContextMigrations = await defaultContext.Database.GetPendingMigrationsAsync();

    if (defaultContextMigrations.Any())
        await defaultContext.Database.MigrateAsync();

    DbContextOptionsBuilder<DefaultContext> options = new();
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

    var context = ActivatorUtilities.CreateInstance<DefaultContext>(services, options.Options);
    var userStore = ActivatorUtilities.CreateInstance(services, typeof(UserStore<User, Role, DefaultContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>), context);
    var userManager = (UserManager<User>)ActivatorUtilities.CreateInstance(services, typeof(UserManager<User>), userStore);

    InitialSeed.SeedRoles(context);
    InitialSeed.SeedUsers(context, userManager);

    return app;
}

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("pt-BR") };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseCors("All");

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

 LoadSeeds(app).GetAwaiter().GetResult();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
