using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recuriment_Platform.Data;
using Recuriment_Platform.Models;


var builder = WebApplication.CreateBuilder(args);

// --------------------

builder.Services.AddDbContext<AuthDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<AuthDBContext>();





// --------------------

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MyContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); //  Add this!
});





var app = builder.Build();

app.UseCors("AllowReactApp");

app.MapIdentityApi<ApplicationUser>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();
//app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



// Default route: show jobs list
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Custom route for ApplyController


app.MapControllerRoute(
    name: "apply",
    pattern: "{controller=Apply}/{action=Index}/{jobId?}/{candidateId?}");



app.Run();


