using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace _04_Repository
{
    [SugarTable("User")]
    public class User : IEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(UniqueGroupNameList = new[] { "Names" })]
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public UserLevel Level { get; set; }
    }


    public enum UserLevel
    {
        Operator,
        Maintainer,
        Engineer,
        Admin,
    }
}
