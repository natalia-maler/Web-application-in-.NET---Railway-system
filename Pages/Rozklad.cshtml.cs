using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SystemKolejowy.Data;
using SystemKolejowy.Models;

namespace SystemKolejowy.Pages
{
    public class RozkladModel : PageModel
    {
        //kontekst bazy danych wstrzykiwany z zewn¹trz za pomoc¹ konstruktora, readonly jest na wszelki
        //wypadek ¿eby nikogo nie kusi³o wynulowaæ referencji.
        private readonly SystemKolejowyContext systemKolejowyContext;

        //systemKolejowyContext to kontekst bazy danych, który jest wstrzykiwany do klasy za pomoc¹ konstruktora.
        //Dziêki temu klasa ma dostêp do bazy danych, z której pobiera dane o rozk³adach poci¹gow.
        public RozkladModel(SystemKolejowyContext systemKolejowyContext)
        {
            this.systemKolejowyContext = systemKolejowyContext;
        }
        public List<Rozklad> rozklady = new List<Rozklad>();
        //w³aœciwoœæ, która jest po³¹czona z formularzem w HTML i pozwala na dodawanie nowych rekordów rozk³adów
        [BindProperty]
        public Rozklad rozklad { get; set; }

        //dodatkowe w³aœciwoœci do filtrowania i sortowania
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } // fraza filtrowania (stacja zród³owa)

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } // opcja sortowania (sortowanie po czasie)

        //metoda ta jest wywo³ywana, gdy u¿ytkownik otwiera stronê
        //rozpoczyna ona zapytanie do bazy danych, pobieraj¹c dane o rozk³adach
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
                //sortowanie rosn¹co i malej¹co
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
                    query = query.OrderBy(r => r.IdRozkladu); // domyœlne sortowanie
                    break;
            }

            // wykonanie zapytania i zapisanie wyników do listy
            rozklady = await query.ToListAsync();

        }


        // 1)
        // Dodawanie nowego rekordu
        public IActionResult OnPost()
        {
            //maksymalna wartoœæ ID z bazy danych
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
        //slave - dane powi¹zane z tabeli podrzêdnej (slave) s¹ dynamicznie wyœwietlane
        public Pociagi pociagi { get; set; } // Relacja z tabel¹ Pociagi

    }
}
