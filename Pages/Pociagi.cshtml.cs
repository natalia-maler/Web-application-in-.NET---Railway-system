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
        
		//kontekst bazy danych wstrzykiwany z zewn�trz za pomoc� konstruktora, readonly jest na wszelki
		//wypadek �eby nikogo nie kusi�o wynulowa� referencji.
		private readonly SystemKolejowyContext systemKolejowyContext;
		public PociagiModel(SystemKolejowyContext systemKolejowyContext)
		{
			this.systemKolejowyContext = systemKolejowyContext;
		}
        public List<Pociagi> pociagi = new List<Pociagi>();

        //nasz model kt�ry b�dzie zbindowany (po��czony) z polami tekstowymi w html
        //umo�liwia powi�zanie w�a�ciwo�ci pociagis z danymi przesy�anymi z formularza w widoku
        [BindProperty]
		public Pociagi pociagis { get; set; }


        //master - slave
        //master tabela nadrz�dna - w kt�rej ka�dy poci�g mo�e mie� wiele rozk�ad�w
        //ta w�a�ciwo�� reprezentuje kolekcj� rozk�ad�w zwi�zanych z poci�giem
        //jest to relacja master-slave, gdzie pociag jest tabel� nadrz�dn�, a rozklady tabel� podrz�dn�
        public ICollection<Rozklad> Rozklady { get; set; } //relacja z tabelk� Rozklad

        public List<Pociagi> Pociagi { get; set; } // lista poci�g�w (master)
        public List<Rozklad> rozklad { get; set; } // lista rozk�ad�w (slave)

        //W�a�ciwo��, kt�ra przechowuje ID wybranego poci�gu
        //Jest to parametr GET, co oznacza, �e jego warto�� mo�e by� przesy�ana przez url
        [BindProperty(SupportsGet = true)]
        public int? SelectedPociagId { get; set; } // wybrane ID poci�gu

        //metoda, kt�ra jest wywo�ywana, gdy strona jest �adowana lub podczas ��dania GET
        public async Task OnGetAsync()
        {
            // pobranie wszystkich poci�g�w z bazy danych, kt�ra jest p�niej u�ywana w widoku
            Pociagi = await systemKolejowyContext.Pociagis.ToListAsync();

            // je�li wybrano poci�g, pobierane/wyswietlane s� rozklady
            if (SelectedPociagId.HasValue)
            {
                Rozklady = await systemKolejowyContext.Rozklads
                    .Where(r => r.IdPociagu == SelectedPociagId)
                    .ToListAsync();
            }
            else
            {
                Rozklady = new List<Rozklad>(); // pusta lista, gdy nie wybrano poci�gu
            }
        }
    
    }
}
