
using api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace tests {
    public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>{
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
        }

//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
////            builder.UseUrls("http://*:1509");
//            base.ConfigureWebHost(builder);
//        }
    }
}