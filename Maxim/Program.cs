using Maxim.DAL;
using Maxim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
	opt.User.RequireUniqueEmail = true;
	opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();	
app.UseAuthorization();

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
