using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CityManager;

public class ReadNotes : PageModel
{
    private readonly IWebHostEnvironment _env;

    public ReadNotes(IWebHostEnvironment env)
    {
        _env = env;
    }

    public List<string> ListaArquivos { get; set; } = new List<string>();
    public string? ConteudoArquivo { get; set; }
    public string? nomeArquivo { get; set; }

    public void OnGet(string? fileName)
    {
        var caminho = Path.Combine(_env.ContentRootPath, "wwwroot", "files");

        ListaArquivos = Directory.GetFiles(caminho, "*.txt").Select(Path.GetFileName).ToList()!;

        if (!string.IsNullOrEmpty(fileName))
        {
            var caminhoArquivo = Path.Combine(caminho, fileName);
            if (System.IO.File.Exists(caminhoArquivo))
            {
                nomeArquivo = fileName;
                ConteudoArquivo = System.IO.File.ReadAllText(caminhoArquivo);
            }
        }
    }
}