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
    public class Singleton_LazyT
    {
        //1、隐藏构造函数
        private Singleton_LazyT() { }
        //2、建立instance变量,直接实例
        private static Lazy<Singleton_LazyT> _lazy = new Lazy<Singleton_LazyT>(() => new Singleton_LazyT());
        //3、构造获取实例的方法
        public static Singleton_LazyT Instance => _lazy.Value;
    }

}
