using Microsoft.Data.SqlClient;

namespace Radioncas2s.Models
{
    public class Igrac : OpstiDomenskiObjekat
    {
        public string Nadimak { get; set; }
        public string Lozinka { get; set; }

        public string ConnectionID { get; set; }

        public string NazivTabele => "Igrac";

        public string Vrednosti => $"'{Nadimak}', '{Lozinka}'";

        public string WhereUslov { get; set; }

        public string UpdateVrednosti { get; set; }

        public List<OpstiDomenskiObjekat> GetReaderList(SqlDataReader reader)
        {
            List<OpstiDomenskiObjekat> res = new List<OpstiDomenskiObjekat>();
            while (reader.Read())
            {
                Igrac i = new Igrac
                {
                    Nadimak = (string)reader["Nadimak"],
                    Lozinka = (string)reader["Lozinka"]
                };
                res.Add(i);
            }

            return res;
        }
    }
}
