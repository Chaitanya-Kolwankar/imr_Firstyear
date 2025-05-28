using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Forgot_Stud_Id : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        div_valid.Visible = false;
        div_stud.Visible = false;
    }
    protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            div_valid.Visible = false;
            if (txtFname.Text == "" || txtLname.Text == "" || txt_moName.Text == "" || ddl_branch.SelectedIndex <= 0 || ddl_day.SelectedIndex <= 0 || ddl_month.SelectedIndex <= 0 || ddl_year.SelectedIndex <= 0)
            {
                div_valid.InnerText = "Enter All Fields";
                div_valid.Visible = true;
            }
            else
            {
                string day = ddl_day.Text;
                string month = ddl_month.Text;
                string year = ddl_year.Text; ;
                string date = month + "-" + day + "-" + year;
                DataSet ds = cls.fill_dataset("select * from dbo.hsc_previous_detail where stud_F_Name = '" + txtFname.Text + "' and Stud_L_Name = '" + txtLname.Text + "' and stud_mo_name = '" + txt_moName.Text + "' and stud_DOB = '" + date + "'and branch = '" + ddl_branch.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_stud_id.Text = ds.Tables[0].Rows[0]["stud_id"].ToString();
                    div_stud.Visible = true;
                }
                else
                {
                    div_valid.InnerText = "STUDENT ID NOT FOUND, MAKE SURE YOU HAVE CLEARED H.S.C IN FIRST ATTEMPT. IF NOT THEN SELECT OUTSIDER AND DO FURTHER ADMISSION PROCESS";
                    div_valid.Visible = true;
                }
            }
        }
        catch
        {
            Response.Redirect("Basic_Detail.aspx");
        }
    }
}