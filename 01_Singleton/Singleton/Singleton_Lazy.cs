using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Singleton
{
    /// <summary>
    /// 懒汉式单线程
    /// </summary>
    public class Singleton_Lazy_SingleThread
    {
        //1、隐藏构造函数
        private Singleton_Lazy_SingleThread() { }
        //2、建立instance变量
        private static Singleton_Lazy_SingleThread _instance;
        //3、构造获取实例的方法
        public static Singleton_Lazy_SingleThread GetInstance()
        {
            //4、创建实例
            if (_instance == null)
            {
                _instance = new Singleton_Lazy_SingleThread();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 懒汉式加锁
    /// </summary>
    public class Singleton_Lazy_Lock
    {
        //1、隐藏构造函数
        private Singleton_Lazy_Lock() { }
        //2、建立instance变量
        private static Singleton_Lazy_Lock _instance;
        //5、定义对象用于锁
        private static readonly object _lock = new object();
        //3、构造获取实例的方法
        public static Singleton_Lazy_Lock GetInstance()
        {
            //4、创建实例
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton_Lazy_Lock();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// 懒汉式双重检查
    /// </summary>
    public class Singleton_Lazy_DoubleCheck
    {
        //1、隐藏构造函数
        private Singleton_Lazy_DoubleCheck() { }

        //2、建立instance变量
        private static Singleton_Lazy_DoubleCheck _instance;

        //5、定义对象用于锁
        private static readonly object _lock = new object();

        //3、构造获取实例的方法
        public static Singleton_Lazy_DoubleCheck GetInstance()
        {
            //4、创建实例
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton_Lazy_DoubleCheck();
                    }
                }
            }
            return _instance;
        }
    }
}
