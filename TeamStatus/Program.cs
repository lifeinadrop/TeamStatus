using Microsoft.EntityFrameworkCore;
using TeamStatus;
using TeamStatus.Hubs;
using TeamStatus.Services;
using TeamStatusData.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Deserializes the AppConfig section and injects the resulting object - making it available to the rest of our application.
builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));

// Initialize the Entity Framework context
builder.Services
    .AddDbContext<DataContext>(options => 
        options.UseNpgsql(builder.Configuration
            .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DataService>();

// Initialize SignlaR 
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapHub<UserStatusHub>("/UserStatusHub");
app.MapStaticAssets();


app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();