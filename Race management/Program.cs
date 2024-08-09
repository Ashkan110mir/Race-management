using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Race_management.Areas.Admin.Data.AdminPlayerData;
using Race_management.Areas.Admin.Data.AdminShowData;
using Race_management.Areas.Admin.Data.AdminTeamData;
using Race_management.Areas.Admin.Data.IAdminCoachData;
using Race_management.Data;
using Race_management.Models;
using Race_management.Utility.ReCaptcha;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RmContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<RmUserIdentity,IdentityRole>(e=>
{
    
}).AddEntityFrameworkStores<RmContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Admin/AdminAccouningt/Login");
    //options.AccessDeniedPath = new PathString("/Account/AccessDenied");
    options.Events.OnRedirectToLogin = context =>
    {
        var requestPath = context.Request.Path;
        if (requestPath.StartsWithSegments("/Admin"))
        {
            context.Response.Redirect("/Admin/AdminAccounting/Login");
        }
        else
        {
            context.Response.Redirect("");
        }
        return Task.CompletedTask;
    };
});
builder.Services.AddScoped<IAdminShowData, AdminShowData>();
builder.Services.AddScoped<IAdminPlayerData, AdminPlayerData>();
builder.Services.AddScoped<IAdminTeamData, AdminTeamData>();
builder.Services.AddScoped<IAdminCoachData, AdminCoachData>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IGoogleRecatcha, GoogleRecatcha>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
            name: "Admin",
            pattern: "{area:exists}/{controller=AdminDashboard}/{action=Dashboarrd}/{id?}"
          );
app.Run();
