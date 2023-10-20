using ProyectoClase_Practica.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProyectoClase_Practica.Models;
using ProyectoClase_Practica.Services;
using ProyectoClase_Practica.Entities;
using ProyectoClase_Practica.Controllers;

namespace ProyectoClase_Practica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<UrlShortenerContext>(dbContextOption => dbContextOption.UseSqlServer(
            builder.Configuration["ConnectionStrings:UrlShortenerDBConnectionString"]));

            builder.Services.AddScoped<UrlShorteningService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Aca se pasara una URL larga y devolvera una corta
            app.MapPost("api/shorten", async (
                UrlForCreations request, 
                UrlShorteningService urlShorteningService, 
                UrlShortenerContext _context,
                HttpContext httpContext) => //HttpContext encapsula toda la información sobre una solicitud y una respuesta HTTP individual. Se inicializa cuando se recibe una solicitud HTTP
            {
                if(!Uri.TryCreate(request.OriginalUrl,UriKind.Absolute, out _))
                {
                    return Results.BadRequest("La URL es invalida.");
                }

                var code = await urlShorteningService.GenerateUniqueCode();

                var shortenedUrl = new UrlShortener
                {
                    Id = Guid.NewGuid(),
                    LongUrl = request.OriginalUrl,
                    Code = code,
                    ShortUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/api/{code}",
                };
                _context.Urls.Add(shortenedUrl);

                await _context.SaveChangesAsync();

                return Results.Ok(shortenedUrl.ShortUrl);
            });

            app.MapGet("api/{code}", async (string code, UrlShortenerContext _context) =>
            {
                var shortenedUrl = await _context.Urls
                 .FirstOrDefaultAsync(x => x.Code == code);
                if (shortenedUrl is null)
                {
                    return Results.NotFound();
                }

                return Results.Redirect(shortenedUrl.LongUrl);
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}