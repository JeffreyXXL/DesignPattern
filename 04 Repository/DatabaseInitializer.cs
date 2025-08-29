using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Repository
{
    public class DatabaseInitializer
    {
        private readonly DbContext _dbContext;

        public DatabaseInitializer(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Init()
        {
            _dbContext.Db.CodeFirst.InitTables(typeof(User));
            Console.WriteLine($"----成功创建{typeof(User).Name}表");
        }
    }
}
