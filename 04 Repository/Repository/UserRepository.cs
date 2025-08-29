using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<User> QueryByNameAsync(string name)
        {
            return QuerySingleAsync(x => x.UserName == name);
        }
    }
}
