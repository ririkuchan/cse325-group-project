using Microsoft.EntityFrameworkCore;
using PersonalGardenLog.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services; // 
using System;
using System.Net.Http;
using PersonalGardenLog;
using Microsoft.AspNetCore.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// ⭐ MudBlazor のサービスを登録
builder.Services.AddMudServices();

builder.Services.AddDbContext<GardenDbContext>(options =>
      options.UseInMemoryDatabase("GardenLog"));

await builder.Build().RunAsync();