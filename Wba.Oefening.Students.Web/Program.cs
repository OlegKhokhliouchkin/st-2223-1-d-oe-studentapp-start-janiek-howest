var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "studentDetails",
    pattern: "Students/{studentid}",
    defaults: new { controller = "Students", action = "ShowStudent" }
    );

app.MapControllerRoute(
    name: "courseDetails",
    pattern: "Courses/{courseid}/Students",
    defaults: new { controller = "Courses",action = "Details" }
    );

app.MapControllerRoute(
    name: "teacherDetails",
    pattern: "Teachers/{teacherid}",
    defaults: new { controller = "Teachers", action = "Details" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
