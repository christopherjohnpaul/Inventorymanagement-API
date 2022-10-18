using Microsoft.EntityFrameworkCore;

namespace DataLayer.DBContext
{
    public class OptionsBuild
    {
        //CONSTRUCTOR
        public OptionsBuild()
        {
            //AppConfiguration class with our connection string.
            Settings = new AppConfiguration();
            //Inits a class which allows us to configure the database connection for a db context.
            //In our case allocate the connection string that our DatabaseContext(Db Sessions) will use.
            OptionsBuilder = new DbContextOptionsBuilder<InventoryMnagementDBContext>();
            //Allocates the connection string to be used when connecting to a Microsoft Sql Database
            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
            //Allocates the set options to be used by the DbContext [Eg our connection string it must use when DatabaseContext it is initiated]
            DatabaseOptions = OptionsBuilder.Options;//used for options class for our database context as we specify that online 26 - ref to 32
        }
        public DbContextOptionsBuilder<InventoryMnagementDBContext> OptionsBuilder { get; set; }
        public DbContextOptions<InventoryMnagementDBContext> DatabaseOptions { get; set; }
        private AppConfiguration Settings { get; set; }
    }

}
