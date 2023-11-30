using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using TP3.DAL.IRepositories;
using TP3.DAL.IServices;
using TP3.DAL.Repositories;
using TP3.DAL.Services;
using TP3.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TP3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TP3Context") ?? throw new InvalidOperationException("Connection string 'TP3Context' not found.")));
// Add services to the container.
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService,MovieService >();
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "nom",
        pattern: "movie/AfficheSelonGenreNom/{name?}",
        defaults: new { controller = "Movie", action = "AfficheSelonGenreNom" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});
app.Run();
