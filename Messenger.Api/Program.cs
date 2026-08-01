using Messenger.Infrastructure;
using Messenger.Application;

var builder = WebApplication.CreateBuilder(args);

// 1. Добавляем контроллеры (API)
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddControllers();
builder.Services.AddRepository();
builder.Services.AddApplication();

// 2. Регистрируем наш AppDbContext в системе внедрения зависимостей (DI)
// Важно: мы говорим приложению, как создать этот контекст
builder.Services.AddData(builder.Configuration.GetConnectionString("Messages")!);

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

await app.RunAsync();