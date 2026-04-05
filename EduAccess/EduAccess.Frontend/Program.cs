using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EduAccess.Frontend;
using EduAccess.Frontend.Services; // <--- 1. AGREGA ESTE USING

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 2. CONFIGURACIÓN DEL HTTPCLIENT (Asegúrate de que el puerto sea 7012)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7012/")
});

// 3. REGISTRAR EL SERVICIO DE ESTUDIANTES
builder.Services.AddScoped<StudentService>(); // <--- 2. AGREGA ESTA LÍNEA

await builder.Build().RunAsync();
