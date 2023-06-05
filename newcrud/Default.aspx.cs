using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace newcrud
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = " This is the details page.";
                BindRadGrid();
            }

        }
        //protected void insert_db()
        //{
        //    using (var session = FluentNHibernateHelper.OpenSession())

        //    {

        //        var product = new Modle { pid = 3, pname = "lenovo laptop", city = "sample product" };

        //        session.SaveOrUpdate(product);

        //    }
        //}

        //private void BindRadGrid()
        //{
        //    using (ISession session = FluentNHibernateHelper.OpenSession())
        //    {
        //        var models = session.QueryOver<Modle>().List();
        //        RadGrid1.DataSource = models;
        //        RadGrid1.DataBind();
        //    }
        //}

        private void BindRadGrid()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                IQuery query = session.CreateQuery("FROM Modle");
                var results = query.List<Modle>();

                RadGrid1.DataSource = results;
               // RadGrid1.DataBind();
            }
        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtPid.Text) && int.TryParse(txtPid.Text, out int pid))
        //    {
        //        string pname = txtPname.Text;
        //        string city = txtCity.Text;

        //        Modle newEntry = new Modle { pname = pname, city = city };
        //        //{ pid = pid, pname = pname, city = city };

        //        using (ISession session = FluentNHibernateHelper.OpenSession())
        //        {
        //            using (ITransaction transaction = session.BeginTransaction())
        //            {
        //                session.Save(newEntry);
        //                transaction.Commit();
        //            }
        //        }

        //        BindRadGrid();
        //        ClearInputFields();
        //    }
        //    else
        //    {
        //        // Handle the case where the pid value is invalid or empty
        //        lblMessage.Text = "Invalid pid value";
        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string pname = txtPname.Text;
            string city = txtCity.Text;

            Modle newEntry = new Modle { pname = pname, city = city };

            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newEntry);
                    transaction.Commit();
                }
            }

            BindRadGrid();
            ClearInputFields();
            RadGrid1.Rebind();
        }



        private void ClearInputFields()
        {
            txtPid.Text = string.Empty;
            txtPname.Text = string.Empty;
            txtCity.Text = string.Empty;
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            BindRadGrid();
        }

      

        private void DeleteRow(int pid)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                Modle model = session.Get<Modle>(pid);
                if (model != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(model);
                        transaction.Commit();
                    }
                }
            }
        }

       

        

        protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            UpdateRows(e.Item as GridEditableItem);
        }

        public static void UpdateRows(GridEditableItem item)
        {
            var employeeId = (int)item.GetDataKeyValue("pid");
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var employee = session.Get<Modle>(employeeId);
                    if (employee != null)
                    {
                        employee.pname = (item["pname"].Controls[0] as TextBox).Text;
                        employee.city = (item["city"].Controls[0] as TextBox).Text;
                        session.Update(employee);
                        transaction.Commit();
                    }
                }
            }
        }







    }
}