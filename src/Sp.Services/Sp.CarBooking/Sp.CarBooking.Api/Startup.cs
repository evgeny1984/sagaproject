using Camunda.Worker;
using Camunda.Worker.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sp.CarBooking.Api.TaskHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.CarBooking.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddExternalTaskClient()
                .ConfigureHttpClient((provider, client) =>
                {
                    if (CurrentEnvironment.IsDevelopment())
                        client.BaseAddress = new Uri("http://localhost:8080/engine-rest");
                    else
                        client.BaseAddress = new Uri("http://camunda:8080/engine-rest");
                });

            services.AddCamundaWorker(workerId: "car-worker", numberOfWorkers: 3)
                .AddHandler<BookCarHandler>()
                .AddHandler<CancelCarHandler>()
                .ConfigurePipeline(pipeline =>
                {
                    pipeline.Use(next => async context =>
                    {
                        var logger = context.ServiceProvider.GetRequiredService<ILogger<Program>>();
                        logger.LogInformation("Started processing of task {Id}", context.Task.Id);
                        await next(context);
                        logger.LogInformation("Finished processing of task {Id}", context.Task.Id);
                    });
                });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");
        }
    }
}
