using ShoppingCartBAL;
using ShoppingCartDAL;
using ShoppingCartBALObject;
using NewShoppingCart.Controllers;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IProductBl, ProductBL>();
builder.Services.AddTransient<IProductDataAccess, ProductDataAccess>();
builder.Services.AddTransient<IProductObject, ProductObject>();
builder.Services.AddTransient<IProcedureclass, Procedureclass>();
builder.Services.AddTransient<ILoginObject, LoginObject>();
builder.Services.AddTransient<ILoginBl, LoginBL>();
builder.Services.AddTransient<ICartObject, CartObject>();
builder.Services.AddTransient<IAccountController, AccountController>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Account/GoogleLogin";
}).AddGoogle(options =>
{
    options.ClientId = "310525572974-13krih0n7icue768gktug6dmsmso1vhl.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "newRoute",
    pattern: "{controller=Home}/{action=User}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=User}/{id?}");

app.Run();
