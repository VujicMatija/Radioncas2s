using Radioncas2s.Models;

namespace Radioncas2s.BrokerBazePodataka
{
    public class SODodajIgraca : SOBase
    {
        private Igrac igrac;
        public Igrac? Result;

        public SODodajIgraca(Igrac i)
        {
            this.igrac = i;
        }

        public override void SOFunction()
        {
            igrac.WhereUslov = $"Nadimak = '{igrac.Nadimak}'";
            List<Igrac> lista = broker.GetByCondition(igrac).Cast<Igrac>().ToList();
            if(lista.FirstOrDefault() == null)
            {
                broker.Add(igrac);
                Result = igrac;
            }
            else
            {
                Result = null;
            }
        }
    }
}
