using System;

namespace 简单工厂模式来改造抽象工厂模式
{
    //题目：
    //现有两个数据库，一个SqlServer，一个MySql，并且两个数据库都有一张Users以及一张Departments的表，现通过简单工厂模式来改造抽象工厂模式让用户选择使用哪个数据库的Users表或者Departments表
    class Program
    {
        //这个用简单工厂模式改造抽象工厂模式的好处是，增加起来不用那么麻烦，但是仍然违反了开放封闭原则，我们应该想办法让简单工厂类里的分支语句消失，只要增加类，工厂也能检测到，那么就是靠反射来实现了
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            var t = factory.GetDepartments("SqlServer");
            t.Insert();
            t.Use();

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

    //定义简单工厂类
    class Factory
    {
        public IUsers GetUsers(string db)
        {
            IUsers users = null;
            switch (db)
            {
                case "SqlServer":
                    users = new SqlServerUser();
                    break;
                case "MySql":
                    users = new MySqlUser();
                    break;
            }
            return users;
        }

        public IDepartments GetDepartments(string db)
        {
            IDepartments departments = null;
            switch (db)
            {
                case "SqlServer":
                    departments = new SqlServerDepartment();
                    break;
                case "MySql":
                    departments = new MySqlDepartment();
                    break;
            }
            return departments;
        }
    }
}
