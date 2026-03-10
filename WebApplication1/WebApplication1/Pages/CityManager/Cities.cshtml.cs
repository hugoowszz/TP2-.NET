using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CityManager;

public class Cities : PageModel
{
    public List<string> myCities = ["Rio de Janeiro", "São Paulo", "Brasília"];
    public void OnGet()
    {
        
    }
}