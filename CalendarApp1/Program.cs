using Microsoft.OpenApi.Models;
using CalendarApp1.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Налаштування підключення до бази даних MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 35))
    ));

// Додаємо контролери з представленнями
builder.Services.AddControllersWithViews();

// Додаємо авторизацію
builder.Services.AddAuthorization();

// Додаємо підтримку Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Calendar/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Додаємо Swagger (інтерфейс для документації API)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calendar API v1");
    c.RoutePrefix = "swagger"; // UI буде доступне за /swagger
});

// Маршрутизація контролерів
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calendar}/{action=Index}/{id?}");

app.Run();



