using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Repository
{
    public class DbContext
    {
        public SqlSugarClient Db { get; set; }

        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.Sqlite,
                ConnectionString = "Data Source = ./Data.db;",
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });

            Db.Aop.OnLogExecuting = (s, p) =>
            {
                Console.WriteLine($"开始执行语句：    【{Regex.Replace(s, @"\s+", " ")}】");
            };
        }
    }
}