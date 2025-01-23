using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SystemKolejowy.Data;
using SystemKolejowy.Models;

namespace SystemKolejowy.Pages
{
    public class PociagiModel : PageModel
    {
        
		//kontekst bazy danych wstrzykiwany z zewn¹trz za pomoc¹ konstruktora, readonly jest na wszelki
		//wypadek ¿eby nikogo nie kusi³o wynulowaæ referencji.
		private readonly SystemKolejowyContext systemKolejowyContext;
		public PociagiModel(SystemKolejowyContext systemKolejowyContext)
		{
			this.systemKolejowyContext = systemKolejowyContext;
		}
        public List<Pociagi> pociagi = new List<Pociagi>();

        //nasz model który bêdzie zbindowany (po³¹czony) z polami tekstowymi w html
        //umo¿liwia powi¹zanie w³aœciwoœci pociagis z danymi przesy³anymi z formularza w widoku
        [BindProperty]
		public Pociagi pociagis { get; set; }


        //master - slave
        //master tabela nadrzêdna - w której ka¿dy poci¹g mo¿e mieæ wiele rozk³adów
        //ta w³aœciwoœæ reprezentuje kolekcjê rozk³adów zwi¹zanych z poci¹giem
        //jest to relacja master-slave, gdzie pociag jest tabel¹ nadrzêdn¹, a rozklady tabel¹ podrzêdn¹
        public ICollection<Rozklad> Rozklady { get; set; } //relacja z tabelk¹ Rozklad

        public List<Pociagi> Pociagi { get; set; } // lista poci¹gów (master)
        public List<Rozklad> rozklad { get; set; } // lista rozk³adów (slave)

        //W³aœciwoœæ, która przechowuje ID wybranego poci¹gu
        //Jest to parametr GET, co oznacza, ¿e jego wartoœæ mo¿e byæ przesy³ana przez url
        [BindProperty(SupportsGet = true)]
        public int? SelectedPociagId { get; set; } // wybrane ID poci¹gu

        //metoda, która jest wywo³ywana, gdy strona jest ³adowana lub podczas ¿¹dania GET
        public async Task OnGetAsync()
        {
            // pobranie wszystkich poci¹gów z bazy danych, która jest póŸniej u¿ywana w widoku
            Pociagi = await systemKolejowyContext.Pociagis.ToListAsync();

            // jeœli wybrano poci¹g, pobierane/wyswietlane s¹ rozklady
            if (SelectedPociagId.HasValue)
            {
                Rozklady = await systemKolejowyContext.Rozklads
                    .Where(r => r.IdPociagu == SelectedPociagId)
                    .ToListAsync();
            }
            else
            {
                Rozklady = new List<Rozklad>(); // pusta lista, gdy nie wybrano poci¹gu
            }
        }
    
    }
}
