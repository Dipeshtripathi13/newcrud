using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace newcrud
{
    public class ProductMap : ClassMap<Modle>
    {
        public ProductMap()
        {
            Id(x => x.pid);

            Map(x => x.pname);

            Map(x => x.city);

            Table("detail");

        }
    }
}