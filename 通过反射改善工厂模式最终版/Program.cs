using System;
using System.Configuration;
using System.Reflection;

namespace 通过反射改善工厂模式最终版
{
    //题目：
    //现有两个数据库，一个SqlServer，一个MySql，并且两个数据库都有一张Users以及一张Departments的表，现通过运用反射技术来改造工厂模式让用户选择使用哪个数据库的Users表或者Departments表
    class Program
    {
        //通过反射改造的工厂，获取实例时候已经取消了分支判断语句，而是以反射的形式动态的根据需要创建实例，将选择实例化的字段写在配置文件里，不在客户端内传值，最终完美版
        //此时如果需要切换数据库只需要更改配置文件中的键值对<key-value>的value即可
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            var db = factory.GetUsers();
            db.Insert();
            db.Use();


            var db1 = factory.GetDepartments();
            db1.Insert();
            db1.Use();

            Console.Read();
        }
    }

    //建立Users数据库表类的接口
    interface IUsers
    {
        public void Insert();
        public void Use();
    }

    //建立Departments数据库表类的接口
    interface IDepartments
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

    class SqlServerDepartment : IDepartments
    {
        public void Insert()
        {
            Console.WriteLine("SqlServer为Departments表插入数据");
        }

        public void Use()
        {
            Console.WriteLine("SqlServer使用Departments表");
        }
    }
    class MySqlDepartment : IDepartments
    {
        public void Insert()
        {
            Console.WriteLine("MySql为Departments表插入数据");
        }

        public void Use()
        {
            Console.WriteLine("MySql使用Departments表");
        }
    }

    class Factory
    {
        private string table = ConfigurationManager.AppSettings["db"];

        public IUsers GetUsers()
        {
            string t = table + "User";
            var w = (IUsers)Assembly.Load("通过反射改善工厂模式最终版").CreateInstance("通过反射改善工厂模式最终版." + t);
            return w;
        }

        public IDepartments GetDepartments()
        {
            string t = table + "Department";
            var w = (IDepartments)Assembly.Load("通过反射改善工厂模式最终版").CreateInstance("通过反射改善工厂模式最终版." + t);
            return w;
        }
    }
}
