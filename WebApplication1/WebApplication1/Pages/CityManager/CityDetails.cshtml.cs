using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CityManager;

public class CityDetails : PageModel
{
    public string CityName { get; set; }
    public void OnGet(string cityName)
    {
        CityName = cityName;
    }
}