using greatnet8hack.Web;
using greatnet8hack.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddHttpClient<TechPortApiClient>(client => client.BaseAddress = new("http://apiservice"));

var app = builder.Build();

var techPortApiClient = app.Services.GetRequiredService<TechPortApiClient>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();

app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapDefaultEndpoints();
app.Run();






