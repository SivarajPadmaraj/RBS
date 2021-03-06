    using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CR.RoomBooking.Data;
using CR.RoomBooking.Services;
using CR.RoomBooking.Data.Interfaces;
using CR.RoomBooking.Data.Repositories;
using CR.RoomBooking.Services.Services;

namespace CR.RoomBooking.Web
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
            services.AddScoped<IPersonService, PersonServices>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddControllers();

            services.AddDbContext<RoomBookingsContext>(op => op.UseInMemoryDatabase("RoomBookings"));
            
            services.AddSwaggerGen();
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assembles = new List<Assembly>()
            {
                typeof(RoomBookingsContext).Assembly,
                typeof(IPersonService).Assembly
            };

            foreach (var assembly in assembles)
            {
                builder.RegisterAssemblyTypes(assembly)
                    .AsImplementedInterfaces();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
