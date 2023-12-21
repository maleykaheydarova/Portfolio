using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<PortfolioDbContext>();

builder.Services.AddDbContext<PortfolioDbContext>();

var app = builder.Build();

//builder.Services.AddDbContext<PortfolioDbContext>(options =>
//options.UseSqlServer());

//builder.Services.AddDbContext<PortfolioDbContext>(builder.Configuration.GetConnectionString("PortfolioDbContext"));

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

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
          name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
