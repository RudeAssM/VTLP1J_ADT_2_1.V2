using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using VTLP1J_ADT_2022_23_1.V2.Models;


namespace VTLP1J_ADT_2022_23_1.V2.Data
{

    public class LensDatabaseContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers;
        public DbSet<ILens> Lens;
        public DbSet<LensMount> LensMounts;

        public LensDatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                                                AttachDbFilename=|DataDirectory|\Database1.mdf;
                                                                Integrated Security=True;
                                                                MultipleActiveResultSets=True");

            }
        }
    }
}
