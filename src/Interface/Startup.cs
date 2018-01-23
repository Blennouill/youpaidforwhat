using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShareFlow.Core.Services;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Services;
using ShareFlow.Domain.Shared.Interfaces;
using ShareFlow.Infrastructure.Comunication;
using ShareFlow.Infrastructure.Data.Repositories;
using ShareFlow.Infrastructure.Shared.Interfaces;
using ShareFlow.Interface.Middlewares;
using ShareFlow.Interface.Process;
using ShareFlow.Interface.Process.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace Interface
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
            services.AddScoped<DbContext, ShareFlowContext>();

            services.AddDbContext<ShareFlowContext>(c =>
                c.UseInMemoryDatabase("ShareFlow"));

            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));

            services.AddScoped<IEventProcess, EventProcess>();
            services.AddScoped<IParticipantProcess, ParticipantProcess>();
            services.AddScoped<IExpenseProcess, ExpenseProcess>();

            services.AddScoped<INotificationService, NotificationService>();

            //services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

            services.AddTransient<IEmailService, EmailService>();

            services.AddAutoMapper();

            services.AddMemoryCache();

            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ShareFlow",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Equinox Project API v1.1");
            });

            app.UseResponseDecorating();

            app.UseMvc();
        }

        public void ConfigureDevelopmentService(IServiceCollection services)
        {
            services.AddDbContext<ShareFlowContext>(c =>
                c.UseInMemoryDatabase("ShareFlow"));
        }

        public void ConfigureTestingService(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<ShareFlowContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ShareFlowDev")));

            ConfigureServices(services);
        }

        public void ConfigureProductionService(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<ShareFlowContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ShareFlowProd")));

            ConfigureServices(services);
        }
    }
}