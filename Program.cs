using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace SimpleDownloadServer
{
    public class Program
    {
        class Startup
        {
            class SimpleContentTypeProvider : IContentTypeProvider
            {
                public bool TryGetContentType(string subpath, out string contentType)
                {
                    contentType = "application/x-msdownload";
                    return true;
                }
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseHsts();

                app.UseHttpsRedirection();

                var opts = new FileServerOptions { EnableDirectoryBrowsing = true };
                opts.StaticFileOptions.ContentTypeProvider = new SimpleContentTypeProvider();

                app.UseFileServer(opts);
            }
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build())
                   .UseStartup<Startup>();
    }
}
