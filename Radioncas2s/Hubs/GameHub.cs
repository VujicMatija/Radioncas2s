using Microsoft.AspNetCore.SignalR;
using Radioncas2s.Models;
using Radioncas2s.Servisi;
using System.Globalization;

namespace Radioncas2s.Hubs
{
    public class GameHub : Hub
    {
        private BazaServis _bazaServis;
        private SobaServis _sobaServis;

        public GameHub(BazaServis bazaServis, SobaServis sobaServis)
        {
            _bazaServis = bazaServis;
            _sobaServis = sobaServis;
        }


        public Igrac? RegistrujIgrac(Igrac igrac)
        {
            return _bazaServis.DodajIgraca(igrac);
        }

        public Igrac? PrijaviIgraca(Igrac igrac)
        {
            return _bazaServis.PrijaviIgraca(igrac);
        }

        public Soba KreirajSobu(Igrac igrac)
        {
            return _sobaServis.KreirajSobu(igrac);
        }

        public async Task<Soba?> PridruziSeSobi(string kod, Igrac igrac)
        {
            Soba soba =  _sobaServis.PridruziSeSobi(kod, igrac);
            if(soba == null)
            {
                return null;
            }
            soba.Spremna = true;
            await Clients.Client(soba.IgracA.ConnectionID).SendAsync("SobaSpremna", soba);
            return soba;
        }

        public async Task PokreniIgru(string kod)
        {
            await Clients.Client(_sobaServis.PronadjiSobu(kod).IgracB.ConnectionID).SendAsync("PokreniIgru");
        }
    }
}
