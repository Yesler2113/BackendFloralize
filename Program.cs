var builder = WebApplication.CreateBuilder(args);

// Instancia de Startup
var startup = new Startup(builder.Configuration);

// Configuraci�n de servicios
startup.ConfigureServices(builder.Services);

// Construcci�n de la aplicaci�n
var app = builder.Build();

// Configuraci�n de middleware
startup.Configure(app);

// Ejecutar la aplicaci�n
app.Run();
