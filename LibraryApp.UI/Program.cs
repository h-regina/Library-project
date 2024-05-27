using LibraryApp.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LibraryApp.UI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:8080") });
        builder.Services.AddScoped<IBooksService, BooksService>();
        builder.Services.AddScoped<IReadersService, ReadersService>();

        await builder.Build().RunAsync();
    }
}
