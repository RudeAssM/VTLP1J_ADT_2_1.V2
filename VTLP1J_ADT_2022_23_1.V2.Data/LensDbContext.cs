using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace VTLP1J_ADT_2022_23_1.V2.Data
{
    public class LensDbContext : DbContext
    {
        

        public LensDbContext()
        {
            this.Database.EnsureCreated();
        }
        
        
    }
        
}

