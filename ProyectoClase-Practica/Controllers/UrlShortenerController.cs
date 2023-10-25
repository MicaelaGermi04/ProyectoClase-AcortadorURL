using Microsoft.AspNetCore.Mvc;
using System.Text;
using ProyectoClase_Practica.Data.Implementations;
using ProyectoClase_Practica.Entities;
using ProyectoClase_Practica.Models;

namespace ProyectoClase_Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly UrlShorteningRepository _urlRepository;

        public UrlShortenerController(UrlShorteningRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetUrlById(int id)
        {
            var url = _urlRepository.GetUrlById(id);

            if (url == null)
            {
                return NotFound();
            }
            return Ok(url.LongUrl);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreateShortUrl([FromBody] UrlForCreations urlForCreations)
        {
            if (urlForCreations == null)
            {
                return BadRequest();
            }
            string shortUrl = GenerateShortUrl();

            // Crear una nueva entidad URL con la URL original y la URL corta
            UrlShortener urlEntity = new UrlShortener
            {
                ShortUrl = shortUrl,
                LongUrl = urlForCreations.LongUrl,
                CategoryId = urlForCreations.CategoryId,
            };
            _urlRepository.AddUrl(urlEntity);
            _urlRepository.SaveChanges();

            // Devolver una respuesta indicando que la URL corta se ha creado con éxito
            return Created($"api/url/{shortUrl}", urlEntity);
        }
        [HttpGet("redireUrl/{shortUrl}")]
        public IActionResult RedirectShortUrl(string shortUrl)
        {
            UrlShortener url = _urlRepository.GetUrlByShortUrl(shortUrl);

            if (url == null)
            { return NotFound(); }
            else
            {

                return Redirect(url.LongUrl);
            }

        }

        // Generador de URL corta
        private readonly string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string GenerateShortUrl()
        {
            Random random = new Random();
            StringBuilder ShortUrl = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int indice = random.Next(Alphabet.Length);
                ShortUrl.Append(Alphabet[indice]);
            }

            return ShortUrl.ToString();
        }
    }
}



