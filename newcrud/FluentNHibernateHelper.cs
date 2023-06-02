using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Tool.hbm2ddl;

namespace newcrud
{
    public static class FluentNHibernateHelper

    {

        public static ISession OpenSession()

        {

            string connectionString = "Data Source=DESKTOP-5P2I522\\MSSQLSERVER01;Initial Catalog=newentry;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            ISessionFactory sessionFactory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012

                  .ConnectionString(connectionString).ShowSql()

                )

                .Mappings(m =>

                          m.FluentMappings

                              .AddFromAssemblyOf<Modle>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(false, false))

                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }

    }
}