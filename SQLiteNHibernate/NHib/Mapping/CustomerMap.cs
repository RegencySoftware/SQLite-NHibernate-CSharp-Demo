using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using SQLiteNHibernate.NHib.Entities;

namespace SQLiteNHibernate.NHib.Maps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Firstname).Column("FirstName ").Not.Nullable();
            Map(x => x.Lastname).Column("LastName ").Not.Nullable();
            Map(x => x.Address).Column("Address").Not.Nullable();
            Map(x => x.City).Column("City ").Not.Nullable();
            Map(x => x.State).Column("State").Not.Nullable();
            Map(x => x.Zipcode).Column("ZipCode").Not.Nullable();            
        }
    }
}
