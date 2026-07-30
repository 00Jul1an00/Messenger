using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Добавляем контроллеры (API)
builder.Services.AddControllers();

// 2. Регистрируем наш AppDbContext в системе внедрения зависимостей (DI)
// Важно: мы говорим приложению, как создать этот контекст
builder.Services.AddDbContext<MessagesService.AppDbContext>(options =>
    options.UseSqlite("Data Source=messages.db"));

// 3. Включаем CORS, чтобы клиент (который на другом порту) мог стучаться к нам
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// 4. Используем CORS
app.UseCors("AllowFrontend");

// 5. Включаем маршрутизацию для контроллеров
app.MapControllers();

// 6. Создаем БД при запуске (если ее нет)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MessagesService.AppDbContext>();
    db.Database.EnsureCreated();
}

// 7. Запускаем сервер!
app.Run();