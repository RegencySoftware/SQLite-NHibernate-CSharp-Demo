using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//NHibernate
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;

//Fluent for Mappings
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

//Application Entities and Mapping
using SQLiteNHibernate.NHib.Entities;
using SQLiteNHibernate.NHib.Maps;

namespace SQLiteNHibernate.NHib
{
    public class DataAccess
    {
        private static string _DBFile = "";
        ISessionFactory _SessionFactory;
        ISession _SessionCurrent;

        /// <summary>
        /// On instantiate setup DB Connection
        /// </summary>
        public DataAccess()
        {           
            HttpContext CTX = HttpContext.Current;
            _DBFile = CTX.Server.MapPath(@"App_Data\CustomerDB.sl3");

            _SessionFactory = CreateSessionFactory();
            _SessionCurrent = _SessionFactory.OpenSession();
        }
        /// <summary>
        /// Get the customer list
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            //Create new customer entitiy
            List<Customer> CustList = new List<Customer>();

            using (var session = _SessionCurrent)
            {
                // retreive all stores and display them
                using (session.BeginTransaction())
                {

                    var query = from m in session.Query<Customer>() 
                                orderby m.Lastname, m.Firstname
                                select m;
                    CustList = query.ToList();                                      
                }
            }

            return CustList;
        }
        /// <summary>
        /// Delete Customer Row
        /// </summary>
        /// <param name="customerID"></param>
        public void DeleteCustomer(int customerID)
        {
            using (var session = _SessionCurrent)
            {
                // retreive all stores and display them
                using (var tx = session.BeginTransaction())
                {

                    var queryString = string.Format("delete {0} where id = :id", typeof(Customer));

                    session.CreateQuery(queryString)
                           .SetParameter("id", customerID)
                           .ExecuteUpdate();  

                    tx.Commit();      

                    session.Flush();
                }
            }
        }
        /// <summary>
        /// Save Customer
        /// </summary>
        public void SaveCustomer(int? customerID, string first, string last, string address, string city, string state, string zip)
        {
            using (var session = _SessionCurrent)
            {
                // retreive all stores and display them
                using (var tx = session.BeginTransaction())
                {
                    Customer CustRow = new Customer();
                    //CustRow.Id = GetNextID(); // Use Auto Increment
                    CustRow.Firstname = first;
                    CustRow.Lastname = last;
                    CustRow.Address = address;
                    CustRow.City = city;
                    CustRow.State = state;
                    CustRow.Zipcode = zip;
                    session.Save(CustRow);

                    tx.Commit();
                }
            }
        }
        /// <summary>
        /// Get Next ID..... Not required AutoIncrement Fixed.
        /// </summary>
        /// <returns></returns>
        private int GetNextID()
        {
            int NextID = 0;
      
            using (var tx = _SessionCurrent.BeginTransaction())
            {
                var query = from m in _SessionCurrent.Query<Customer>()
                            orderby m.Id descending
                            select m;

                var Cust = query.ToList();
                var MaxCustID = Cust.FirstOrDefault();
                NextID = MaxCustID.Id + 1;
            }

            return NextID;
        }        
        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(_DBFile))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .BuildSessionFactory();
        }        
    }
}