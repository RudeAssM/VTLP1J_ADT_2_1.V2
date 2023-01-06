using System;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        void UpdateName(int id, String name);
    }
}