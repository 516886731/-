using System;
using System.Reflection;

namespace 通过反射继续改善工厂模式
{
    //题目：
    //现有两个数据库，一个SqlServer，一个MySql，并且两个数据库都有一张Users以及一张Departments的表，现通过运用反射技术来改造工厂模式让用户选择使用哪个数据库的Users表或者Departments表
    class Program
    {
        //通过反射改造的工厂，获取实例时候已经取消了分支判断语句，而是以反射的形式动态的根据需要创建实例，但是目前有个缺陷是，需要在客户端指定类名，当我们添加了新的产品类时候，还是需要更改客户端，我们可以更完美些；考虑写在配置文件里，不在客户端内传值
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            factory.table = "SqlServerUser";
            var db=factory.GetUsers();
            db.Insert();
            db.Use();

            factory.table = "MySqlDepartment";
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
        public string table;
        public IUsers GetUsers()
        {
            var t =(IUsers) Assembly.Load("通过反射继续改善工厂模式").CreateInstance("通过反射继续改善工厂模式." + table);
            return t;
        }

        public IDepartments GetDepartments()
        {
            var t = (IDepartments)Assembly.Load("通过反射继续改善工厂模式").CreateInstance("通过反射继续改善工厂模式." + table);
            return t;
        }
    }
}
