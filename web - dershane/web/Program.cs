using data.Concrate;
using entity.Concrate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();



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

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name: "Admin",
		areaName: "Admin",
		pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapAreaControllerRoute(
		name: "Student",
		areaName: "Student",
		pattern: "Student/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapAreaControllerRoute(
		name: "Teacher",
		areaName: "Teacher",
		pattern: "Teacher/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapAreaControllerRoute(
		name: "Parent",
		areaName: "Parent",
		pattern: "Parent/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapDefaultControllerRoute();
});


app.Run();
