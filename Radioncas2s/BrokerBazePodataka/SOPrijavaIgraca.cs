using Radioncas2s.Models;

namespace Radioncas2s.BrokerBazePodataka
{
    public class SOPrijavaIgraca : SOBase
    {
        private Igrac igrac;
        public Igrac? Result;

        public SOPrijavaIgraca(Igrac i)
        {
            this.igrac = i;
        }
        public override void SOFunction()
        {
            igrac.WhereUslov = $"Nadimak = '{igrac.Nadimak}' and Lozinka = '{igrac.Lozinka}'";
            List<Igrac> lista = broker.GetByCondition(igrac).Cast<Igrac>().ToList();
            Result = lista.FirstOrDefault();
            if(Result == null)
            {
                throw new Exception("Ne postoji igrac sa ovim kredencijalima");
            }
        }
    }
}
