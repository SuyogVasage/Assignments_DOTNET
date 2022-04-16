using Blazor_Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//Load the Component in html element with 'id' as 'app'
//wwwroot/index.html <div id='app'>
builder.RootComponents.Add<App>("#app");
//Head outlet is astandard component that will be added after HTML page header
builder.RootComponents.Add<HeadOutlet>("head::after");

//The HttpClient class is registered into the DI container
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//Run the application asynchronously
await builder.Build().RunAsync();
