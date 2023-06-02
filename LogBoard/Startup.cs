using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LogBoard.Models;
using Microsoft.OpenApi.Models;
using LogBoard.Repository;

namespace LogBoard
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
            // cors 정책 설정
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("*")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // 환경변수로 민감정보 받아오기
            string sshHostName = Configuration["sshHostName"];
            string sshUserName = Configuration["sshUserName"];
            string sshPassword = Configuration["sshPassword"];
            int sshPort = int.Parse(Configuration["sshPort"]);
            string databaseHost = Configuration["databaseHost"];
            int localPort = int.Parse(Configuration["localPort"]);

            string databaseUser = Configuration["databaseUser"];
            string databasePassword = Configuration["databasePassword"];
            string databaseName = Configuration["databaseName"];



            //SSH 연결 의존성 주입
            services.AddSingleton<SshTunnelService>(new SshTunnelService(
                sshHostName,
                sshUserName,
                sshPassword,
                sshPort,
                databaseHost,
                localPort));

            //DB연결 의존성 주입
            services.AddSingleton<DatabaseService>(new DatabaseService(
                databaseHost,
                localPort,
                databaseUser,
                databasePassword,
                databaseName));

            services.AddTransient<VisitorsRepository>();


            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API 문서", Version = "v1" });
            });




        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API 문서 V1");
            });

            app.UseCors("AllowOrigin"); // cors 미들웨어 추가




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
