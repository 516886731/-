using System;

namespace 简单工厂模式2
{
    //题目：
    //现有两个数据库，一个SqlServer，一个MySql，并且两个数据库都有一张Users的表，现通过简单工厂模式来让用户选择使用哪个数据库的Users表
    class Program
    {
        //简单工厂模式的好处是方便，但是其违反了开放封闭原则，每次要加数据库就需要更改工厂类的分支语句
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            var db1 = factory.GetDatabase("SqlServer");
            db1.Insert();
            db1.Use();

            var db2 = factory.GetDatabase("MySql");
            db2.Insert();
            db2.Use();

            Console.Read();
        }
    }

    //定义抽象数据库类
    abstract class DatabaseUser
    {
        public abstract void Use();
        public abstract void Insert();
    }
    //实现抽象数据库类
    class SqlServerUser : DatabaseUser
    {
        public override void Insert()
        {
            Console.WriteLine("SqlServer为Users表插入数据");
        }

        public override void Use()
        {
            Console.WriteLine("SqlServer使用Users表");
        }
    }
    class MySqlUser : DatabaseUser
    {
        public override void Insert()
        {
            Console.WriteLine("MySql为Users表插入数据");
        }

        public override void Use()
        {
            Console.WriteLine("MySql使用Users表");
        }
    }

    //定义简单工厂类
    class Factory
    {
        public DatabaseUser GetDatabase(string databaseName)
        {
            DatabaseUser database = null;
            switch (databaseName)
            {
                case "SqlServer":
                    database = new SqlServerUser();
                    break;
                case "MySql":
                    database = new MySqlUser();
                    break;
            }
            return database;
        }
    }
}
