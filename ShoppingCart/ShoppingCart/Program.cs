using ShoppingCartBAL;
using ShoppingCartDAL;
using ShoppingCartBALObject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductBl, ProductBL>();
builder.Services.AddScoped<IProductDataAccess, ProductDataAccess>();
builder.Services.AddScoped<IProductObject, ProductObject>();
builder.Services.AddScoped<IProcedureclass, Procedureclass>();
builder.Services.AddScoped<ILoginObject, LoginObject>();
builder.Services.AddScoped<ILoginBl, LoginBL>();
builder.Services.AddScoped<ICartObject, CartObject>();
//builder.Services.AddAuthentication("auth").AddCookie("auth",x => x.LoginPath = "/Home/Index");
//builder.Services.AddAuthentication("auth");
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


