using System.Collections.Generic;

namespace GuitarApi.Interfaces
{
    public interface IGetGuitarsByCompany
    {
        List<Guitar> Select(string searchText);
    }
}
