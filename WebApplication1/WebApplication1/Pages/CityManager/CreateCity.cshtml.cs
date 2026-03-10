using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CityManager;

public class CreateCity : PageModel
{
    public class InputModel
    {
        [Required(ErrorMessage = "Digite o nome da cidade")]
        [MinLength(3, ErrorMessage = "O nome da cidade precisa ter pelo menos 3 letras")]
        public string CityName { get; set; }
    }
    
    [BindProperty]
    public InputModel Cidade { get; set; }
    
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return Page();
    }
}