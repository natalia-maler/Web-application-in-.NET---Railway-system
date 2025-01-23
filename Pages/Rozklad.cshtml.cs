using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SystemKolejowy.Data;
using SystemKolejowy.Models;

namespace SystemKolejowy.Pages
{
    public class RozkladModel : PageModel
    {
        //kontekst bazy danych wstrzykiwany z zewn�trz za pomoc� konstruktora, readonly jest na wszelki
        //wypadek �eby nikogo nie kusi�o wynulowa� referencji.
        private readonly SystemKolejowyContext systemKolejowyContext;

        //systemKolejowyContext to kontekst bazy danych, kt�ry jest wstrzykiwany do klasy za pomoc� konstruktora.
        //Dzi�ki temu klasa ma dost�p do bazy danych, z kt�rej pobiera dane o rozk�adach poci�gow.
        public RozkladModel(SystemKolejowyContext systemKolejowyContext)
        {
            this.systemKolejowyContext = systemKolejowyContext;
        }
        public List<Rozklad> rozklady = new List<Rozklad>();
        //w�a�ciwo��, kt�ra jest po��czona z formularzem w HTML i pozwala na dodawanie nowych rekord�w rozk�ad�w
        [BindProperty]
        public Rozklad rozklad { get; set; }

        //dodatkowe w�a�ciwo�ci do filtrowania i sortowania
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } // fraza filtrowania (stacja zr�d�owa)

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } // opcja sortowania (sortowanie po czasie)

        //metoda ta jest wywo�ywana, gdy u�ytkownik otwiera stron�
        //rozpoczyna ona zapytanie do bazy danych, pobieraj�c dane o rozk�adach
        public async Task OnGetAsync()
        {
            //pobieranie danych z bazy
            IQueryable<Rozklad> query = systemKolejowyContext.Rozklads;

            //4)
            //filtrowanie
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                query = query.Where(r =>
                    r.StacjaZrodlowa.Contains(SearchQuery) || //lub
                    r.StacjaDocelowa.Contains(SearchQuery));
            }

            //sortowanie
            switch (SortOrder)
            {
                //sortowanie rosn�co i malej�co
                case "czas_odjazdu_asc":
                    query = query.OrderBy(r => r.CzasOdjazdu);
                    break;
                case "czas_odjazdu_desc":
                    query = query.OrderByDescending(r => r.CzasOdjazdu);
                    break;
                case "stacja_zrodlowa_asc":
                    query = query.OrderBy(r => r.StacjaZrodlowa);
                    break;
                case "stacja_zrodlowa_desc":
                    query = query.OrderByDescending(r => r.StacjaZrodlowa);
                    break;
                default:
                    query = query.OrderBy(r => r.IdRozkladu); // domy�lne sortowanie
                    break;
            }

            // wykonanie zapytania i zapisanie wynik�w do listy
            rozklady = await query.ToListAsync();

        }


        // 1)
        // Dodawanie nowego rekordu
        public IActionResult OnPost()
        {
            //maksymalna warto�� ID z bazy danych
            int maxId = systemKolejowyContext.Rozklads.Max(r => r.IdRozkladu);

            // ustawienie nowego ID jako maxId + 1
            rozklad.IdRozkladu = maxId + 1;
            systemKolejowyContext.Rozklads.Add(rozklad);
            systemKolejowyContext.SaveChanges();
            return RedirectToPage();
        }
        [BindProperty(SupportsGet = true)]
        public int? DeleteId { get; set; }
        // Usuwanie rekordu
        public IActionResult OnPostDelete()
        {
            if (DeleteId.HasValue)
            {
                var record = systemKolejowyContext.Rozklads.FirstOrDefault(r => r.IdRozkladu == DeleteId.Value);
                if (record != null)
                {
                    systemKolejowyContext.Rozklads.Remove(record);
                    systemKolejowyContext.SaveChanges();
                }
            }
            return RedirectToPage();
        }

        //5)master-slave
        //slave - dane powi�zane z tabeli podrz�dnej (slave) s� dynamicznie wy�wietlane
        public Pociagi pociagi { get; set; } // Relacja z tabel� Pociagi

    }
}
