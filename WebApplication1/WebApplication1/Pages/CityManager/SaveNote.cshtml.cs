using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CityManager;

public class SaveNote : PageModel
{
    
    public class InputModel
    {
        public string Content { get; set; }
    }
    
    [BindProperty]
    public InputModel NoteContent { get; set; }
    
    public string ArquivoSalvo { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var fileName = $"note-{DateTime.Now:yyyyMMddHHmmss}.txt";
        var path = Path.Combine("wwwroot/files/", fileName);

        using (var writer = new StreamWriter(path, true))
        {
            writer.Write(NoteContent.Content);
            ArquivoSalvo = fileName;
            return Page();
        }
    }
}