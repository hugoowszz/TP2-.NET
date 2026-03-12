using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.CityManager;

public class CreateCountry : PageModel
{
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
    
    [BindProperty]
    public List<InputModel> CountryInput { get; set; } = new List<InputModel>();

    [BindProperty]
    public List<Country> CountryList { get; set; }
    
    public Country NovoPais { get; set; }
    public class  InputModel
    {
        [Required(ErrorMessage = "Digite o nome do país")]
        public string CountryName { get; set; }
        
        [Required(ErrorMessage = "Digite o código do país")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código precisa ter 2 letras")]
        public string CountryCode { get; set; }
    }
    
    
    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
        {
            CountryInput.Add(new InputModel());
        }
    }

    public IActionResult OnPost()
    {
        for (int i = 0; i < CountryInput.Count; i++)
        {
            var c = CountryInput[i];
            if (!string.IsNullOrWhiteSpace(c.CountryName) && !string.IsNullOrWhiteSpace(c.CountryCode))
            {
                if (char.ToUpperInvariant(c.CountryName[0]) != char.ToUpperInvariant(c.CountryCode[0]))
                {
                    ModelState.AddModelError($"CountryInput[{i}].CountryCode", "O código do país deve começar com a mesma letra do nome.");
                }
            }
        }

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Erro");
            return Page();
        }
        
        CountryList = CountryInput.Select(c => new Country
        {
            CountryName = c.CountryName,
            CountryCode = c.CountryCode
        }).ToList();
        Console.WriteLine(CountryList.Count);
        return Page();
    }
}