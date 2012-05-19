using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;

namespace MyGeneratetionWin.DB
{
    public class DatabaseAccess
    {
        private static SimpleRepository repository = null;

        public static SimpleRepository Repository
        {
            get { return repository; }
        }

        static DatabaseAccess()
        {
            repository = new SimpleRepository("NorthwindSQLite", SimpleRepositoryOptions.RunMigrations);
        }

        
    }
}
