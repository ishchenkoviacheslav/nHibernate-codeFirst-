using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole
{

    class Program
    {
        private static ISessionFactory _sessionFactory;

        static void Main(string[] args)
        {
            CreateDatabase();
            Console.WriteLine("Database Created sucessfully");

            //creating a object of customer
            Customer customer = new Customer
            {
                CustomerId = 2,
                Name = "xdvxcv",
                Adress = "dsfhsf 34"
            };

            //saving customer in database.
            using (ISession session = _sessionFactory.OpenSession())
                session.Save(customer);

            Console.WriteLine("Customer Saved");
        }
        static void CreateDatabase()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Server(@".\SQLEXPRESS").Database("NHiber").TrustedConnection()))
                //.Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=NHiber;Integrated Security=True").ShowSql)
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMAP>())
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }
    }
}
