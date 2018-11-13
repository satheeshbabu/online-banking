using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Extensions.Configuration.ConfigServer;
using WayneEnterprises.Authentication;
using WayneEnterprises.Authorisation;
using WayneEnterprises.OnlineBanking.WebApi.Models;

namespace WayneEnterprises.OnlineBanking.WebApi
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
            services.AddOptions();
            services.ConfigureConfigServerClientOptions(Configuration);
            services.AddConfiguration(Configuration);
            services.AddMvcCore().AddAuthorization().AddJsonFormatters();
            services.Configure<ApplicationConfigurationModel>(Configuration);
            services.AddCors();

            services.AddResourceOwnerPasswordCredentialsFlow(x =>
            {
                x.Authority = Configuration["Keycloak:Authority"];
                x.Audience = Configuration["Keycloak:Audience"];
                x.RequireHttpsMetadata = false;
            });

            //services.AddImplicitFlowAuthentication(x =>
            //{
            //    x.Authority = Configuration["Keycloak:Authority"];
            //    x.ClientId = Configuration["Keycloak:ClientId"];
            //    x.SignedOutRedirectUri = Configuration["Keycloak:SignedOutRedirectUri"];
            //    x.Scopes = Configuration.GetSection("Keycloak:Scopes").Get<List<string>>();
            //});

            services.AddClientScopeAuthorisation(options => { options.ScopeClaimIdentifier = "scope"; });
            services.AddIdentityClaimAuthorisation(options => { options.RoleClaimIdentifier = "role"; });
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) spa.UseAngularCliServer("start");
            });
        }
    }
}