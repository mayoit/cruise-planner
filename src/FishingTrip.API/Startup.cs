using FishingTrip.Application.Interface;
using FishingTrip.Application.Interface.Config;
using FishingTrip.Infrastructure.DBContext;
using FishingTrip.Infrastructure.DI;

namespace FishingTrip.API
{
    public class Startup
    {
        private readonly IConfigProvider configProvider;
        public Startup(IConfigProvider configProvider)
        {
            this.configProvider = configProvider;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDatabase(configProvider);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }

    public static class RegisterServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, IConfigProvider configProvider)
        {

            serviceCollection.AddPostgresDatabaseContext<IFishingTripPlannerDbContext, FishingTripPlannerDbContext>(configProvider.FishingTripDbConnectionString);
            return serviceCollection;
        }
    }
}