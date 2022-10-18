using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.DBContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<InventoryMnagementDBContext>
    {
        //We simply providing the Database Context which must be used when performing a database migration.
        public InventoryMnagementDBContext CreateDbContext(string[] args)
        {
            // Get our connection string - VIA AppConfiguration Class
            AppConfiguration Settings = new AppConfiguration();
            // Init A new options builder so we can tell it what information it must use when connecting the the db
            DbContextOptionsBuilder<InventoryMnagementDBContext> OptionsBuilder = new DbContextOptionsBuilder<InventoryMnagementDBContext>();
            // Tell the options builder what type of database its connecting to and which connection string it must use
            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
            // We return a new instance of the database context with the all required db connection info
            // So it can then be used to do a db migrations.
            return new InventoryMnagementDBContext(OptionsBuilder.Options);
        }
    }
}
