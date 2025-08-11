using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Singleton
{
    /// <summary>
    /// 饿汉式
    /// </summary>
    public class Singleton_Eager
    {
        //1、隐藏构造函数
        private Singleton_Eager() { }

        //2、建立instance变量，同时直接赋值
        private static readonly Singleton_Eager _instance = new Singleton_Eager();

        //3、静态属性给出实例
        public static Singleton_Eager Instance => _instance;
    }
}