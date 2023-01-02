using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public interface IlensMountRepository : IRepository<LensMount>
    {
        void UpdateManufacturer(int id, Manufacturer manufacturer);
    }
}