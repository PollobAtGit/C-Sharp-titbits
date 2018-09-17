using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trips.UI.Filter;
using Trips.UI.Operation;

namespace Trips.UI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
                .AddMvc(o => o.Filters.Add(new LogPageFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // if anti forgery token validation is not enabled then Pages will
            // not be able to validate the form on it's own

            //mvcBuilder.AddRazorPagesOptions(o =>
            //o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()));

            services.AddTransient<TripRepository>();
            services.AddTransient<TripContextRepository>();
            services.AddDbContext<TripContext>(x => x.UseSqlite("Data Source=./../trips-db.db"));

            IOCBehaviorTestDependencies(services);
        }

        private void IOCBehaviorTestDependencies(IServiceCollection services)
        {
            //services.AddTransient<IOperation, Operation.Operation>();
            //services.AddScoped<IScopedOperation, Operation.Operation>();
            //services.AddSingleton<ISingletonOperation, Operation.Operation>();
            //services.AddTransient<DummyOperationService>();

            services.AddTransient<OperationService>();

            // new instance each resolution
            //services.AddTransient<Operation.Operation>();

            // new instance each HTTP request
            services.AddScoped<Operation.Operation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
