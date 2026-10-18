using Microsoft.AspNetCore.SignalR;
using Radioncas2s.Models;
using Radioncas2s.Servisi;

namespace Radioncas2s.Hubs
{
    public class GameHub : Hub
    {
        private BazaServis _bazaServis;

        public GameHub(BazaServis bazaServis)
        {
            _bazaServis = bazaServis;
        }


        public Igrac? RegistrujIgrac(Igrac igrac)
        {
            return _bazaServis.DodajIgraca(igrac);
        }

        public Igrac? PrijaviIgraca(Igrac igrac)
        {
            return _bazaServis.PrijaviIgraca(igrac);
        }
    }
}
