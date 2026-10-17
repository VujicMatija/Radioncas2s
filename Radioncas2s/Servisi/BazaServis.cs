using Radioncas2s.BrokerBazePodataka;
using Radioncas2s.Models;

namespace Radioncas2s.Servisi
{
    public class BazaServis
    {
        public Igrac? DodajIgraca(Igrac igrac)
        {
            SODodajIgraca so = new SODodajIgraca(igrac);
            so.ExecuteSystemOperation();
            return so.Result;
        }

        public Igrac? PrijaviIgraca(Igrac igrac)
        {
            SOPrijavaIgraca so = new SOPrijavaIgraca(igrac);
            so.ExecuteSystemOperation();
            return so.Result;
        } 
    }
}
