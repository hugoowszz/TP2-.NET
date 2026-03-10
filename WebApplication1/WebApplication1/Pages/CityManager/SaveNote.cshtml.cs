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
    public InputModel Content { get; set; }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var fileName = $"note-{DateTime.Now:yyyyMMddHHmmss}";
        using (var writer = new StreamWriter("Content.txt", true))
        {
            writer.Write(Content.Content);
            return Page();
        }
    }
}