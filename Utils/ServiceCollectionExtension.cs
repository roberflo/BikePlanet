using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GFShop.DataAccessLayer;
using GFShop.DataAccessLayer.Repositories;
using GFShop.DataAccessLayer.Repositories.Interfaces;
using GFShop.Helpers;
using GFShop.Utils;
using GFStore.BusinessLogicLayer;
using GFStore.BusinessLogicLayer.Interfaces;
using GFStore.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace GFStore.Utils
{
    public static class ServiceCollectionExtensions
    {
        #region METHODS
        public static IServiceCollection AddCustomApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfiles());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper();
            services.AddOptions();
            services.Configure<AppSettings>(configuration);
            //Swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Talladita API", Version = "v1" });
            });
            // configure jwt authentication
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection); 
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {       
           // configure DI for application services
            // configure DI 
            services.AddScoped<IUserBol, UserBol>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();

            services.AddScoped<IProductBol, ProductBol>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();

            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var AzureConnection = services.BuildServiceProvider()
                .GetRequiredService<IOptions<AppSettings>>().Value
                .ConnectionStrings.DefaultConnection;
            services.AddDbContext<GFStoreContext>(options => options.UseSqlServer(AzureConnection));
            return services;
        } 
        #endregion
    }
}
