using MyMvcProjectFolder.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("even", typeof(EvenNumberConstraint));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session support
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Required for GDPR compliance
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
app.UseSession();

app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// conventional routing demo 
  app.MapControllerRoute(
      name: "evenRoute",
      pattern: "number/{id:even}",
      defaults: new { controller = "Home", action = "EvenCheck" });
app.Run();
