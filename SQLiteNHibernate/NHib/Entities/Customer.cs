using System;
using System.Text;
using System.Collections.Generic;

namespace SQLiteNHibernate.NHib.Entities
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zipcode { get; set; }
    }
}
