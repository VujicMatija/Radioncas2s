using Microsoft.Data.SqlClient;

namespace Radioncas2s.Models
{
    public interface OpstiDomenskiObjekat
    {
        string NazivTabele { get; }
        string Vrednosti { get; }
        string WhereUslov { get; }
        string UpdateVrednosti { get; }
        List<OpstiDomenskiObjekat> GetReaderList(SqlDataReader reader);
    }
}
