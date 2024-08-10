using ErrorsToFrasi;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Race_management.Areas.Admin.Data.AdminPlayerData;
using Race_management.Areas.Admin.Data.AdminShowData;
using Race_management.Areas.Admin.Data.AdminTeamData;
using Race_management.Areas.Admin.Data.IAdminCoachData;
using Race_management.Data;
using Race_management.Data.ICoachShowData;
using Race_management.Data.IPlayerCoachData;
using Race_management.Data.PlayerShowData;
using Race_management.Models;
using Race_management.Utility.Email_Sender;
using Race_management.Utility.ReCaptcha;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RmContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<RmUserIdentity, IdentityRole>(e =>
{
    e.Password.RequireNonAlphanumeric = true;
    e.Password.RequiredLength = 8;
    e.Password.RequireUppercase = true;
    e.Password.RequireDigit = true;
    e.Password.RequireLowercase = true;

    e.User.RequireUniqueEmail = true;
    e.SignIn.RequireConfirmedEmail = true;

    e.Lockout.MaxFailedAccessAttempts = 5;
    e.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

}).AddEntityFrameworkStores<RmContext>().AddDefaultTokenProviders().AddErrorDescriber<ErrorToFarsi>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.LoginPath = new PathString("/Admin/AdminAccouningt/Login");
    options.AccessDeniedPath = new PathString("/Error/AccessDenied");
    options.Events.OnRedirectToLogin = context =>
    {
        var requestPath = context.Request.Path;
        if (requestPath.StartsWithSegments("/Admin"))
        {
            context.Response.Redirect("/Admin/AdminAccounting/Login");
        }
        else
        {
            context.Response.Redirect("UserAccounting/Login");
        }
        return Task.CompletedTask;
    };
});
builder.Services.AddScoped<IAdminShowData, AdminShowData>();
builder.Services.AddScoped<IAdminPlayerData, AdminPlayerData>();
builder.Services.AddScoped<IAdminTeamData, AdminTeamData>();
builder.Services.AddScoped<IAdminCoachData, AdminCoachData>();

builder.Services.AddScoped<ICoachShowData,CoachShowData>();


builder.Services.AddScoped<IPlayerCoachData,PlayerCoachData>();
builder.Services.AddScoped<IPlayerShowData, PlayerShowData>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IGoogleRecatcha, GoogleRecatcha>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Error/Notfound");
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
