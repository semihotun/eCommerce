using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace Core.Utilities.Swagger
{
    public static class SwaggerServiceCollectionExtension
    {
        public static void AddCustomSwaggerGen(this IServiceCollection services )
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version ="v1",
                    Title = "eCommerce",
                    Description = "eCommerce",
                });
                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "Bearer Header",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
            });
        }
    }
}
