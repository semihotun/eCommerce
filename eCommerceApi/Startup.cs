using Autofac;
using Business.Extension;
using Core.Extension;
using Core.Utilities.Caching;
using Core.Utilities.DependencyResolvers;
using Core.Utilities.Exceptions;
using Core.Utilities.Identity;
using Core.Utilities.IoC;
using Core.Utilities.Swagger;
using DataAccess.Extension;
using eCommerceApi.Extensions;
using Entities.Extensions.AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
namespace eCommerceApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration);
            DbContextExtension.MigrateDbContext(Configuration);
            services.AddCors(options =>
            options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddCustomSwaggerGen();
            services.AutoMapperSettings();
            services.AddHttpContextAccessor();
            services.AddRedis(Configuration);
            services.AddIdentitySettings(Configuration);
            services.AddRazorPages().AddNewtonsoftJson();
            services.AddMvc().AddFluentValidation().ConfigureApiBehaviorOptions(x => x.SuppressModelStateInvalidFilter = true);
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModule(AssembliesExtension.GetAllAssemblies()));
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerce v1"));
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseMiddleware<ExceptionMiddleware>();
            ServiceTool.ServiceProvider = app.ApplicationServices;
        }
    }
}
