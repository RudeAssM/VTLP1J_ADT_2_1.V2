using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VTLP1J_ADT_2022_23_1.V2.Data;
using VTLP1J_ADT_2022_23_1.V2.Endpoint.Services;
using VTLP1J_ADT_2022_23_1.V2.Logic;
using VTLP1J_ADT_2022_23_1.V2.Repository;

namespace VTLP1J_ADT_2022_23_1.V2.Endpoint
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthorization();
            services.AddAuthentication();

            services.AddTransient<IManufacturerLogic, ManufacturerLogic>();
            services.AddTransient<ILensLogic, LensLogic>();
            services.AddTransient<ILensMountLogic, LensMountLogic>();

            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<ILensRepository, LensRepository>();
            services.AddTransient<ILensMountRepository, LensMountRepository>();

            services.AddTransient<LensDatabaseContext,LensDatabaseContext>();
            services.AddSignalR();

            
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(Cors => Cors
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:696969")
            );
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalR>("/hub");
            });
            
        }
    }
}