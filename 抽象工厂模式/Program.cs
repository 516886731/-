using System;

namespace 抽象工厂模式
{
    //题目：
    //现有两个数据库，一个SqlServer，一个MySql，并且两个数据库都有一张Users以及一张Departments的表，现通过抽象工厂模式来让用户选择使用哪个数据库的Users表或者Departments表
    class Program
    {
        //抽象工厂模式其实就是工厂方法模式的升级版，工厂方法模式只有某个单独的产品类，一个产品接口；而抽象工厂模式包含了多个产品接口，有多个产品类，一定程度上符合了开放封闭原则；但是要添加会显得麻烦，比方添加一个新的产品类，要增加其产品接口以及继承者，还要修改工厂接口以及具体的工厂，太过于麻烦
        static void Main(string[] args)
        {
            IFactory factory = new SqlServerFactory();
            var db1 = factory.GetDepartments();
            db1.Insert();
            db1.Use();

            var db2 = factory.GetUsers();
            db2.Insert();
            db2.Use();

            IFactory factory1 = new MySqlFactory();
            var db3 = factory1.GetDepartments();
            db3.Insert();
            db3.Use();

            var db4 = factory1.GetUsers();
            db4.Insert();
            db4.Use();

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
    //建立工厂接口
    interface IFactory
    {
        public IUsers GetUsers();
        public IDepartments GetDepartments();
    }
    //继承工厂接口的具体工厂，生产具体的工厂
    class SqlServerFactory : IFactory
    {
        public IUsers GetUsers()
        {
            return new SqlServerUser();
        }
        public IDepartments GetDepartments()
        {
            return new SqlServerDepartment();
        }
    }
    class MySqlFactory : IFactory
    {
        public IUsers GetUsers()
        {
            return new MySqlUser();
        }
        public IDepartments GetDepartments()
        {
            return new MySqlDepartment();
        }
    }
}
