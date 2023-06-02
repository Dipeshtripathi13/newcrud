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
                lblMessage.Text = "Hello, World! This is the default page.";
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

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                int pid = Convert.ToInt32(dataItem.GetDataKeyValue("pid"));

                // Perform delete operation using the pid
                DeleteRow(pid);

                RadGrid1.Rebind(); // Rebind the RadGrid after deletion
            }
            else if (e.CommandName == "Edit" && e.Item is GridEditableItem)
            {
                GridEditableItem editedItem = (GridEditableItem)e.Item;
                int pid = Convert.ToInt32(editedItem.GetDataKeyValue("pid"));

                // Get the edited values from the edited item
                TextBox txtPnameEdit = (TextBox)editedItem.FindControl("txtPnameEdit");
                TextBox txtCityEdit = (TextBox)editedItem.FindControl("txtCityEdit");

                string editedPname = txtPnameEdit.Text;
                string editedCity = txtCityEdit.Text;

                // Perform the update operation using the pid and the edited values
                UpdateRow(pid, editedPname, editedCity);

                RadGrid1.EditIndexes.Clear(); // Clear the edit indexes
                RadGrid1.Rebind(); // Rebind the RadGrid after updating

                // Optionally, you can show a success message or perform any additional actions
                lblMessage.Text = "Row updated successfully!";
            }
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

       

        private void UpdateRow(int pid, string editedPname, string editedCity)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                Modle model = session.Get<Modle>(pid);
                if (model != null)
                {
                    model.pname = editedPname;
                    model.city = editedCity;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(model);
                        transaction.Commit();
                    }
                }
            }
        }




    }
}