using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_CRUD
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);// indentifier need to be changed
        }



        // using is required
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["GSS_HWConnectionString"].ConnectionString))// this would be change too
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where student_name like @name";// SQL Need to be modified
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + textbox_name_box.Text + "%"));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        grid_view_student.DataSource = ds;
                        grid_view_student.DataMember = "Table";
                        grid_view_student.DataBind();
                        da.Fill(ds);

                    }
                }
            }
        }

        // using requery to do the ajax
        protected void button_do_insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["GSS_HWConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from student";
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + textbox_name_box.Text + "%"));// SQL Need to be modified

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables["Table"];
                        DataRow dr = dt.NewRow();
                        // field to add

                        dr["student_name"] = textbox_name_insert.Text;
                        dr["studnet_birthday"] = textbox_birthday_insert.Text;
                        dr["student_information"] = textbox_information_insert.Text;
                        dt.Rows.Add(dr);
                        da.Update(dt);

                        // clear field
                        textbox_name_insert.Text = "";
                        textbox_birthday_insert.Text = "";
                        textbox_information_insert.Text = "";

                        btnQuery_Click(null, null);// why?


                    }
                }
            }
        }

        protected void button_do_update_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["GSS_HWConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from student";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Select(string.Format("student_id = {0}", textbox_id_update.Text)).First();
                        dr["student_name"] = textbox_name_update.Text;
                        dr["studnet_birthday"] = textbox_birthday_update.Text;
                        dr["student_information"] = textbox_information_update.Text;
                        da.Update(dt);

                        // clear field
                        textbox_name_update.Text = "";
                        textbox_birthday_update.Text = "";
                        textbox_information_update.Text = "";

                        btnQuery_Click(null, null);// why?
                    }
                }
            }
        }

        protected void button_do_delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["GSS_HWConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from student";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Select(string.Format("student_id = {0}", textbox_id_delete.Text)).First();
                        dr.Delete();
                        da.Update(dt);

                        // clear field
                        textbox_id_delete.Text = "";

                        btnQuery_Click(null, null);// why?
                    }
                }
            }
        }



    }
}