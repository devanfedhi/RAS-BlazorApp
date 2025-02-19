using BlazorApp.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection(); So that app does not attempt to redirect to HTTPS

app.UseStaticFiles(); // HTML files, CSS, images, images, etc.
app.UseAntiforgery(); // Protects your app from CSRF attacks

app.MapRazorComponents<App>(); // App is the root component

app.Run(); // Start the app
