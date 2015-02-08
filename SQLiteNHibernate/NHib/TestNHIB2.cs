using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SQLiteNHibernate.NHib.Entities;
using SQLiteNHibernate.NHib.Maps;


namespace SQLiteNHibernate.NHib
{
    public class TestNHIB2
    {

        private static string DbFile = "";

        public void GetDataTest()
        {
            string test = "";

            HttpContext CTX = HttpContext.Current;
            DbFile = CTX.Server.MapPath(@"App_Data\CustomerDB.sl3");

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {
                    var SiteCustomers = session.CreateCriteria(typeof(Customer)).List<Customer>();

                    foreach (var SiteCustomer in SiteCustomers)
                    {                        
                        test = test + SiteCustomer.Firstname + "<br />";
                    }
                }
            }

            //CTX.Response.Write(test);

        }
        private ISessionFactory CreateSessionFactory()
        {       
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DbFile))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                //.Mappings(m => m.FluentMappings.Add<CustomerMap>())                
                .BuildSessionFactory();

            //IPersistenceConfigurer persistenceConfigurer;
            //persistenceConfigurer = SQLiteConfiguration.Standard.UsingFile(DbFile).ShowSql();


            //return Fluently.Configure()
            //    .Database(persistenceConfigurer)
            //    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
            //     .Mappings(m => m.FluentMappings.Add<CustomerMap>())
            //    .BuildSessionFactory();

        }      
    }
}