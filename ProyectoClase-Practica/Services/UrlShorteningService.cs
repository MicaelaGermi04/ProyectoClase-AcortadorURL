using Microsoft.EntityFrameworkCore;
using ProyectoClase_Practica.Data;
using System.Globalization;

namespace ProyectoClase_Practica.Services
{
    public class UrlShorteningService
    {
        public const int NumberOfCharsInShortUrl = 6;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private readonly Random _random = new Random();

        private readonly UrlShortenerContext _context;
        public UrlShorteningService (UrlShortenerContext context)
        {
            _context = context;
        }
        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[NumberOfCharsInShortUrl];

            while (true)
            {
                for (var i = 0; i < NumberOfCharsInShortUrl; i++)
                {
                    var randomIndex = _random.Next(Alphabet.Length - 1);
                    codeChars[i] = Alphabet[randomIndex];
                }

                var code = new string(codeChars);

                if (! await _context.Urls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }

            }
        }
    }
}
