using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole
{
    public class CustomerMAP : ClassMap<Customer>
    {
        public CustomerMAP()
        {
            Id(c => c.CustomerId);
            Map(c => c.Name);
            Map(c => c.Adress);
        }
    }
}
