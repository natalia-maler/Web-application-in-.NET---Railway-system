using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SystemKolejowy.Data;
using SystemKolejowy.Models;

namespace SystemKolejowy.Pages
{
    public class OpoznieniaModel : PageModel
    {
        private readonly SystemKolejowyContext systemKolejowyContext;
        public OpoznieniaModel(SystemKolejowyContext systemKolejowyContext)
        {
            this.systemKolejowyContext = systemKolejowyContext;
        }
        public List<Opoznienium> opoznienia = new List<Opoznienium>();
        
        public IList<Opoznienium> Opoznienia { get; set; }
        public void OnGet()
        {
            opoznienia = systemKolejowyContext.Opoznienia.ToList();
        }
       // 3)
        //anonimizacja
        public IActionResult OnPostAnonymize()
        {
            var records = systemKolejowyContext.Opoznienia.ToList();
            int counter = 1;

            foreach (var record in records)
            {
                record.Powod = $"Powód{counter++}";
            }

            systemKolejowyContext.SaveChanges();
            return RedirectToPage();
        }
        //kasowanie
        public IActionResult OnPostDeleteAll()
        {
            var allRecords = systemKolejowyContext.Opoznienia.ToList();
            systemKolejowyContext.Opoznienia.RemoveRange(allRecords);
            systemKolejowyContext.SaveChanges();
            return RedirectToPage();
        }
    }
}
