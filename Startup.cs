using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();
            services.AddOData().EnableApiVersioning();
            services.AddODataApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                    options.UseApiExplorerSettings = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            VersionedODataModelBuilder modelBuilder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapVersionedODataRoute("versioned-odata", "v{version:apiVersion}", modelBuilder);
            });
        }

        ////app.UseAuthorization();


        ////services.AddMvcCore(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
        ////.AddJsonOptions(options =>
        ////{
        ////    options.JsonSerializerOptions.IgnoreNullValues = true;
        ////    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        ////});

        ////app.UseMvc(routeBuilder =>
        ////{
        ////    ////routeBuilder.SetDefaultODataOptions(new ODataOptions { UrlKeyDelimiter = Microsoft.OData.ODataUrlKeyDelimiter.Slash });
        ////    ////var options = routeBuilder.ServiceProvider.GetRequiredService<ODataOptions>();
        ////    ////options.UrlKeyDelimiter = Microsoft.OData.ODataUrlKeyDelimiter.Slash;
        ////    ////routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
        ////    routeBuilder.MapVersionedODataRoute("versioned-odata", "v{version:apiVersion}", modelBuilder);
        ////});

        ////endpoints.MapODataRoute("versioned-odata", "v{version:apiVersion}", modelBuilder.GetEdmModels().First());
    }
}
