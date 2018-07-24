using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Mime;

namespace BlazorTest.Server
{
    public class Startup
    {

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			//SignalR対応
			services.AddSignalR();

			services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });
//test code エラー対策に行ったが効かなかった
#if false
			//HttpClientからのアクセスがエラーになる。
			//services.AddHttpClient<>();
			services.AddHttpClient();

			//HttpClientからのアクセスがエラーになる。
			//https://github.com/aspnet/JavaScriptServices/issues/1514
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
#endif
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			else
			{

				
			}

			//グローバルのエラー処理を追加
			app.UseMiddleware(typeof(ErrorHandlingMiddleware));

			//UseMvcの後で良いかは不明
			app.UseSignalR(routes =>
			{
				//使用するClassを登録する
				routes.MapHub<ChatHub>("/chathub");
			});

			app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });

            //app.UseBlazor<Pages.Program>();

            app.UseBlazor<Client.Program>();

        }

	
    }
}
