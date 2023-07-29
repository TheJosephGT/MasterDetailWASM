using MasterDetailWASM.Client;
using MasterDetailWASM.Client.Services.ClienteServices;
using MasterDetailWASM.Client.Services.ProductServices;
using MasterDetailWASM.Client.Services.VentaServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVentaService, VentaService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
