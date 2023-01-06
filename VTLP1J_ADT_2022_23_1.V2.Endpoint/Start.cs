using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VTLP1J_ADT_2022_23_1.V2.Data;
using VTLP1J_ADT_2022_23_1.V2.Endpoint.Services;
using VTLP1J_ADT_2022_23_1.V2.Logic;
using VTLP1J_ADT_2022_23_1.V2.Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace VTLP1J_ADT_2022_23_1.V2.Endpoint
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddAuthentication();

            services.AddTransient<IManufacturerLogic, ManufacturerLogic>();
            services.AddTransient<ILensLogic, LensLogic>();
            services.AddTransient<ILensMountLogic, LensMountLogic>();

            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<ILensRepository, LensRepository>();
            services.AddTransient<ILensMountRepository, LensMountRepository>();

            services.AddScoped<LensDatabaseContext,LensDatabaseContext>();
            services.AddSignalR();
            services.AddControllers();

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllers();
                endpoints.MapHub<SignalHub>("/hub");
            });
            
        }

    }
}