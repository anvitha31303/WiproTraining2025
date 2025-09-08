using Microsoft.EntityFrameworkCore;
using ajax_demo.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the container BEFORE builder.Build()
builder.Services.AddControllersWithViews();

// ✅ Register DbContext here
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
