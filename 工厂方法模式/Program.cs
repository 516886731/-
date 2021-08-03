using System;

namespace 工厂方法模式
{
    //题目：
    //现有两个数据库，一个SqlServer，一个MySql，并且两个数据库都有一张Users的表，现通过工厂方法模式来让用户选择使用哪个数据库的Users表
    class Program
    {
        //工厂方法模式是简单工厂模式的升级版，它实现了开放封闭原则，每次需要添加具体时候，比如添加Oracle数据库，先增加一个具体的OracleUsers产品类，然后增加一个生产该类的具体工厂
        static void Main(string[] args)
        {
            //SqlServer的User表的使用
            IFactory factory = new SqlServerUserFactory();
            var db1 = factory.GetUsers();
            db1.Insert();
            db1.Use();

            //MySql的User表的使用
            IFactory factory1 = new MySqlUserFactory();
            var db2 = factory1.GetUsers();
            db2.Insert();
            db2.Use();

            Console.Read();
        }
    }

    //建立数据库表类的接口
    interface IUsers
    {
        public void Insert();
        public void Use();
    }
    //继承其接口的具体类
    class SqlServerUser : IUsers
    {
        public void Insert()
        {
            Console.WriteLine("SqlServer为Users表插入数据");
        }

        public void Use()
        {
            Console.WriteLine("SqlServer使用Users表");
        }
    }
    class MySqlUser : IUsers
    {
        public void Insert()
        {
            Console.WriteLine("MySql为Users表插入数据");
        }

        public void Use()
        {
            Console.WriteLine("MySql使用Users表");
        }
    }

    //建立工厂接口
    interface IFactory
    {
        public IUsers GetUsers();
    }
    //继承工厂接口的具体工厂，生产具体的工厂
    class SqlServerUserFactory : IFactory
    {
        public IUsers GetUsers()
        {
            return new SqlServerUser();
        }
    }
    class MySqlUserFactory : IFactory
    {
        public IUsers GetUsers()
        {
            return new MySqlUser();
        }
    }
}
