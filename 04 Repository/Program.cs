using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Repository
{
    internal class Program
    {
        public static IRepository<User> userRepo;

        static async Task Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DbContext>().AsSelf();
            builder.RegisterType<DatabaseInitializer>().AsSelf();
            builder.RegisterType<UserRepository>().As<IRepository<User>>();
            var container = builder.Build();
            var initializer = container.Resolve<DatabaseInitializer>();
            initializer.Init();
            userRepo = container.Resolve<IRepository<User>>();

            //插入用户Jeffrey
            await Dosth(() =>
            {
                return userRepo.InsertAsync(new User()
                {
                    UserName = "Jeffrey",
                    UserPassword = "111111",
                    Level = UserLevel.Operator
                });
            });

            //插入用户Lynn
            await Dosth(() =>
            {
                return userRepo.InsertAsync(new User()
                {
                    UserName = "Lynn",
                    UserPassword = "222222",
                    Level = UserLevel.Engineer
                });
            });

            //插入用户Lynn-2 
            await Dosth(() =>
            {
                return userRepo.InsertAsync(new User()
                {
                    UserName = "Lynn",
                    UserPassword = "333333",
                    Level = UserLevel.Admin
                });
            });

            //获取所有用户
            List<User> users = new List<User>();
            await Dosth(async () =>
            {
                users = await userRepo.QueryAllAsync();
            });
            Console.WriteLine("----获取到所有用户:");
            foreach (var item in users)
            {
                Console.WriteLine($"       {item.Id},{item.UserName},{item.Level}");
            }

            //获取单个用户
            User user = new User();
            await Dosth(async() =>
            {
                user = await userRepo.QuerySingleAsync(x => x.UserName == "Jeffrey");
            });

            //修改用户名和密码
            await Dosth(async () =>
            {
                await userRepo.UpdateAsync(new User()
                {
                    Id = user.Id,
                    UserName = "Jeff",
                    UserPassword = "444444",
                    Level = UserLevel.Admin
                });
            });

            //获取所有用户
            users = new List<User>();
            await Dosth(async () =>
            {
                users = await userRepo.QueryAllAsync();
            });
            Console.WriteLine("----获取到所有用户:");
            foreach (var item in users)
            {
                Console.WriteLine($"       {item.Id},{item.UserName},{item.Level}");
            }

            //删除用户
            await Dosth(async () =>
            {
                await userRepo.DeleteByIdAsync(user.Id);
            });


            //获取所有用户
            users = new List<User>();
            await Dosth(async () =>
            {
                users = await userRepo.QueryAllAsync();
            });
            Console.WriteLine("----获取到所有用户:");
            foreach (var item in users)
            {
                Console.WriteLine($"       {item.Id},{item.UserName},{item.Level}");
            }
            Console.ReadLine();
        }


        public static async Task Dosth(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception e)
            {
                Console.WriteLine("--------------------数据库操作失败：" + Regex.Replace(e.Message, @"\s+", " "));
            }
        }
    }
}
