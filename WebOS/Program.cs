using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebOS;

namespace WebOS
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddSingleton<IWindowManager, WindowManager>();
            await builder.Build().RunAsync();
        }
    }
}
