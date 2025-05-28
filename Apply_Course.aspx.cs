using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Drawing;


public partial class FY_Apply_Course : System.Web.UI.Page
{
    Class1 cls = new Class1();
    applyCrs_model apply_model = new applyCrs_model();
    string str = "";
    DataSet ds, dt_n, dt_n_o, dt1;
    string marks = "", oth_fees = ""; int oth_amt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["Formno"].ToString() == "")
                {
                    Response.Redirect("Login.aspx",false);
                }
                else
                {
                    DataSet ds = cls.fill_dataset("  select distinct adm.formno+replace(adm.group_id,'GRP','') as formno_grp,pre_faculty,s.subcourse_name,c.course_name,g.Group_title ,adm.group_id from  dbo.d_adm_applicant app,  dbo.OLA_FY_adm_CourseSelection adm,dbo.m_crs_subcourse_tbl s,dbo.m_crs_course_tbl c,dbo.m_crs_subjectgroup_tbl g,m_FeeMaster as fm where app.Form_no=adm.formno and fm.group_id=(select group_id from m_crs_subjectgroup_tbl where group_id= adm.Group_id )  and app.ACDID=fm.Ayid and fm.del_flag='0' and adm.group_id=g.group_id   and c.course_id=s.course_id and g.Subcourse_id=s.subcourse_id and adm.group_id=g.group_id  and app.form_no='" + Session["Formno"].ToString() + "' and app.acdid='" + Session["AYID"].ToString() + "' and app.del_flag=0");
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        chkIAgree.Checked = true;
                        chkIAgree.Enabled = false;
                        dgvData.DataSource = ds.Tables[0];
                        dgvData.DataBind();
                    }
                    castdata();
                    fillCourse();
                   // scholarfile();
                    deletebutton();
                    if (ddl_course.Items.Count > 2)
                    {
                        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "FY")
                        {
                            ddl_course.SelectedIndex = 1;
                            ddl_course.Enabled = false;
                        }
                        else if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SY")
                        {
                            ddl_course.SelectedIndex = 2;
                            ddl_course.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
        
    }

    //public void scholarfile()
    //{
    //    string str = "";
    //    str = "select category from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'";
    //    DataTable dt = cls.fill_datatable(str);
    //    if (dt.Rows.Count > 0)
    //    {
    //        if (!string.IsNullOrEmpty(dt.Rows[0]["category"].ToString()))
    //        {
    //            if (dt.Rows[0]["category"].ToString() != "OPEN")
    //            {
    //                scholardiv.Visible = true;
    //            }
    //            else
    //            {
    //                scholardiv.Visible = false;
    //            }
    //        }
    //    }
    //}


    public void check_flag_withimage()
    {
        DataSet dss = check_flag();
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["step1_flag"].ToString() == "True")
            {
                Control img1 = this.Master.FindControl("step1img") as Control;
                img1.Visible = true;
                //step1img.Visible = true;
            }
            if (dss.Tables[0].Rows[0]["step2_flag"].ToString() == "True")
            {
                Control img2 = this.Master.FindControl("step2img") as Control;
                img2.Visible = true;
                //step2img.Visible = true;
            }
            if (dss.Tables[0].Rows[0]["step3_flag"].ToString() == "True")
            {
                Control img2 = this.Master.FindControl("step3img") as Control;
                img2.Visible = true;
                //step3img.Visible = true;
            }
            if (dss.Tables[0].Rows[0]["step4_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step4img") as Control;
                img.Visible = true;
                //step4img.Visible = true;

            }
            if (dss.Tables[0].Rows[0]["step5_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step5img") as Control;
                img.Visible = true;
                //step5img.Visible = true;

            }
            if (dss.Tables[0].Rows[0]["step6_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step6img") as Control;
                img.Visible = true;
                //step6img.Visible = true;

            }
            if (dss.Tables[0].Rows[0]["step7_flag"].ToString() == "True")
            {
                Control img = this.Master.FindControl("step7img") as Control;
                img.Visible = true;
                //step7img.Visible = true;

            }
        }
    }

    public void fillcertificate()
    {
        string str = "";
        str = "select category from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'";
        DataTable dt = cls.fill_datatable(str);
        if (dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["category"].ToString()))
            {
                if (dt.Rows[0]["category"].ToString() != "OPEN")
                {

                }
            }
        }
    }

    public DataSet check_flag()
    {
        try
        {
            if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
            {
                DataSet ds_flag = cls.fill_dataset("select step1_flag,step2_flag,step3_flag,step4_flag,step5_flag,step6_flag,step7_flag from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'");
                if (ds_flag.Tables[0].Rows.Count > 0)
                {
                    Session["step1_flag"] = ds_flag.Tables[0].Rows[0]["step1_flag"].ToString();
                    Session["step2_flag"] = ds_flag.Tables[0].Rows[0]["step2_flag"].ToString();
                    Session["step3_flag"] = ds_flag.Tables[0].Rows[0]["step3_flag"].ToString();
                    Session["step4_flag"] = ds_flag.Tables[0].Rows[0]["step4_flag"].ToString();
                    Session["step5_flag"] = ds_flag.Tables[0].Rows[0]["step5_flag"].ToString();
                    Session["step6_flag"] = ds_flag.Tables[0].Rows[0]["step6_flag"].ToString();
                    Session["step7_flag"] = ds_flag.Tables[0].Rows[0]["step7_flag"].ToString();
                    return ds_flag;
                }
                return ds_flag;
            }
            else
            {
                Response.Redirect("Login.aspx");
                return null;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
            return null;
        }
    }

    public void castdata()
    {
        str = "select category from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'";
        DataTable dt = cls.fill_datatable(str);
        if (dt.Rows.Count > 0)
        {
            Session["cast_new"] = dt.Rows[0]["category"].ToString();
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (chkIAgree.Checked == true)
        {
            Session["group_id"] = ddl_course.SelectedValue.ToString();

            DataTable dt = cls.fill_datatable("select * from OLA_FY_adm_CourseSelection where formno='" + Session["Formno"].ToString() + "'and del_flag=0 and group_id='" + ddl_course.SelectedValue.ToString() + "'");
            string str = "";

            if (dt.Rows.Count > 0)
            { 

            }
            else
            {
               str = "insert into OLA_FY_adm_CourseSelection values('" + Session["Formno"].ToString() + "','" + ddl_course.SelectedValue.ToString() + "',null,null,0,null,GETDATE(),null,null,null,null,null);";
            }
            str += "insert into OLA_Form_print values('" + Session["Formno"].ToString() + "',getdate()); update dbo.d_adm_applicant set step7_flag=1,step7_dt=getdate() where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str);
            cmd.Connection = cls.con;
            cls.Conn();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cls.con_close();
            deletebutton();
            Response.Redirect("WebReport.aspx");
        }
        else
        {
            div_valid.InnerText = "Please Check I Agree";
            div_valid.Visible = true;
        }
    }


    public void ErrorMessageDisplay(string ex)
    {
        string csError = "PopupError";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsStartupScriptRegistered(cstype, csError))
        {
            String cstext1 = "alert('" + ex + "'" + ");";
            cs.RegisterStartupScript(cstype, csError, cstext1, true);
        }
    }

    public void fillCourse()
    {
        DataSet ddcourse = cls.fill_dataset("select Group_id,Group_title from m_crs_subjectgroup_tbl where del_flag=0 order by Group_title");
        ddl_course.Items.Clear();
        ddl_course.DataSource = ddcourse;
        ddl_course.DataValueField = "Group_id";
        ddl_course.DataTextField = "Group_title";
        ddl_course.DataBind();
        ddl_course.Items.Insert(0, new ListItem("-- Select --"));
    }




    /////sukant
    public void clear_div_con()
    {
        //div_receipt.Visible = false;
        div_valid.Visible = false;
        div_com.Visible = false;
        //div_offline.Visible = false;
        stat.Text = "";
        group_id.Text = "";
        fees.Text = "";
       // msg.Text = "";
        btn_confirm.Text = "PAY";
    }

    public bool validate_amt(string payamt)
    {
        if (Convert.ToInt32(payamt) < Convert.ToInt32(Session["other_amount"]))
        {         
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Amount Should be greater than " + Convert.ToInt32(Session["other_amount"]) + "')", true);
            return false;
        }
        else
        {
            return true;
        }
      
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        clear_div_con();
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        string buttonText = ((Button)sender).Text;
        int amt_val = 0;
        amt_val = Convert.ToInt32(txt_amount_final.Text);
        int check_amount = 10000;

        if (buttonText == "PAY")
        {
            if (validate_amt(amt_val.ToString()))
            {


                //if ((amt_val > 0) == true)
                //{
                //    if ((amt_val >= check_amount))
                //    {

                        string customer_acc_no = Session["Formno"].ToString();

                        string str11 = "select Duration from m_academic  where iscurrent='1'";
                        //  Session["ayid"] = ds.Tables[3].Rows[0]["to_year"].ToString();
                        DataSet dt11 = cls.fill_dataset(str11);
                        string[] sum = dt11.Tables[0].Rows[0][0].ToString().Split('/');
                        sum = sum[2].Split('-');
                        string str1 = "select * from processing_fees where form_no='" + Session["Formno"] + "' and ayid=(select MAX(ayid) from dbo.m_academic where iscurrent='1')";
                        DataSet dt2 = cls.fill_dataset(str1);
                        string trans_id = "";
                        if (dt2.Tables[0].Rows.Count > 0)
                        {
                            trans_id = Session["Formno"] + Session["group_id"].ToString().Replace("GRP", "") + sum[0] + (Convert.ToInt32(dt2.Tables[0].Rows.Count) + 1);
                        }
                        else
                        {
                            trans_id = Session["Formno"] + Session["group_id"].ToString().Replace("GRP", "") + sum[0] + "1";
                        }
                        if (stat.Text == "canceltansfer")
                        {
                            trans_id = trans_id + "C";
                        }
                        if (Convert.ToString(amt_val) != "")
                        {

                            string str = "insert into processing_fees values('" + Session["Formno"] + "','','','','','','" + trans_id + "','','','','','','','','Admission-" + Session["group_id"].ToString() + "',(select max(ayid) from m_academic where iscurrent='1'),getdate())";
                            cls.insert_data_app(str);
                            Response.Redirect("payment.aspx/" + amt_val + "/" + trans_id + "/" + customer_acc_no + "/ABC/admission");

                        }
                //    }
                //    else
                //    {
                //        ErrorMessageDisplay("Amount Should be greater than " + check_amount + " or Less than" + fees.Text);
                //    }
                //}
                //else
                //{
                //    ErrorMessageDisplay("Amount Should be greater than " + check_amount);

                //}
            }
        }
        else
        {
            if ((buttonText == "CONFIRM" || buttonText == "Confirm Admission") && stat.Text == "canceltansfer")
            {

                SqlDataReader resultset;
                string studid = "";
                string str_check_pop = "Select  aca.stud_id,isnull(per.stud_F_name,'')  +'  '+ isnull(per.stud_M_name,'') +'  '+ isnull(per.stud_L_name,'') as  stud_name, aca.group_id,class.subcourse_name,class.subcourse_id, course.Course_id, course.course_name, per.Del_Flag, fac.faculty_name, grp.group_title,grp.Descritption, (select MAX(fyid)fyid  from m_std_pervrecord_tbl where Stud_id=aca.stud_id) fyid ,aca.ayid ,sum(fee_mas.Amount) as course_tot_fees,(select sum(amount) from m_feeentry as entry where entry.stud_id = aca.stud_id and entry.del_flag = 0 and ENTRY.TYPE='Fee' and entry.Chq_status = 'Clear' and entry.ayid = fee_mas.ayid ) as course_fee_paid,            (select top 1 convert(varchar,Curr_dt ,106 )  from m_std_studentacademic_tbl where Stud_id=aca.stud_id order by curr_dt desc) admission_date,case when (select sum(amount) from m_feeentry as entry where entry.stud_id = aca.stud_id and entry.del_flag = 0 and ENTRY.TYPE='Fee' and entry.Chq_status = 'Clear' and entry.ayid = fee_mas.ayid )< sum(fee_mas.Amount)             then 'BALANCE'              else case when (select sum(amount) from m_feeentry as entry where entry.stud_id = aca.stud_id and entry.del_flag = 0 and ENTRY.TYPE='Fee' and entry.Chq_status = 'Clear' and entry.ayid = fee_mas.ayid )= sum(fee_mas.Amount)  then 'PAID' else 'PAID MORE' end end 'FEES STATUS' from 	m_std_studentacademic_tbl as aca		inner join 	m_std_personaldetails_tbl as per on per.stud_id = aca.stud_id 		inner join  	m_crs_subcourse_tbl as class on class.subcourse_id = aca.subcourse_id 		inner join 	m_crs_course_tbl as course on course.course_id = class.course_id 		inner join 	m_crs_faculty  as fac on fac.faculty_id = course.faculty_id 		inner join  	m_crs_subjectgroup_tbl as grp on grp.Group_id = aca.group_id 		left outer join  	m_feemaster as fee_mas on fee_mas.group_id = grp.group_id and fee_mas.ayid = aca.AYID  where aca.stud_id = (select stud_id from d_adm_applicant where Form_no='" + Session["Formno"] + "') and  	aca.AYID = (select max(ayid) from m_std_studentacademic_tbl where stud_id=aca.stud_id) and aca.del_flag=0 group by aca.course_tot_fees, aca.course_fee_paid, aca.group_id, class.subcourse_name,  course.Course_id,   course.course_name, per.Del_Flag,  fac.faculty_name, grp.group_title ,aca.ayid, per.stud_F_name, per.stud_M_name, per.stud_L_name, aca.stud_id , fee_mas.ayid ,class.subcourse_id,grp.Descritption";
                DataTable dt = cls.fill_datatable(str_check_pop);
                string qry12 = "select MAX(FYID)as FYID from m_financial ";
                DataSet dsfyid = cls.fill_dataset(qry12);
                string fyid = dsfyid.Tables[0].Rows[0]["FYID"].ToString();
                if (dt.Rows.Count > 0)
                {
                    string str = " Exec [proc_autoid_LMS_FY_cancel_tansfer] '" + dt.Rows[0]["stud_id"].ToString() + "','Admin' ,'" + Session["Formno"] + "' ,'" + fyid + "','" + dt.Rows[0]["ayid"].ToString() + "','" + Session["group_id"].ToString() + "'";
                    resultset = cls.RetriveQuery(str);
                    if (resultset.HasRows == true)
                    {
                        while (resultset.Read())
                        {
                            studid = (resultset[0].ToString());
                        }
                    }
                    if (studid.ToString() != "")
                    {
                        div_com.Visible = false;
                        btn_confirm.Text = "Admission taken";
                        stat.Text = "Exist";
                        ErrorMessageDisplay("Admission is confirmed and student ID is " + studid);
                        deletebutton();
                        //txttotal();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Admission is confirmed and student ID is " + studid + "')", true);

                    }
                    else
                    {
                        ErrorMessageDisplay("Admission is not confirmed");
                    }
                }
            }
            else if (buttonText == "Admission taken")
            {
                ErrorMessageDisplay("Admission is already confirmed..");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Admission is already confirmed..')", true);
            }
        }
    }

    protected void dgvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "print")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            Session["group_id"] = dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString();

            SqlCommand cmd = new SqlCommand("insert into OLA_Form_print values('" + Session["Formno"].ToString() + "',getdate())");
            cmd.Connection = cls.con;
            cls.Conn();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cls.con_close();
            Response.Redirect("WebReport.aspx", false);
        }
        if (e.CommandName == "Confirm")
        {
            clear_div_con();
            div_com.Visible = true;
            Label lbldgv = (Label)dgvData.Rows[0].FindControl("lblGroupid");
            get_amt_pay(lbldgv.Text);
            //  txt_amount_final.Enabled = false;
          //  Fee_stat.Visible = false;
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            GridViewRow row1 = dgvData.Rows[row.RowIndex];
         
            string val = "";         
            Session["group_id"] = dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString();
            Session["subcourse_id_g_check"] = ((Label)row1.FindControl("lblSubcourse")).Text.ToString().Trim();           //lblSubcourse
            group_id.Text = dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString();
            subcourse.Text = ((Label)row1.FindControl("lblSubcourse")).Text.ToString().Trim();        
        }
        if (e.CommandName == "recipt_data")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            GridViewRow row1 = dgvData.Rows[row.RowIndex];
            string caping = "select *  from dbo.m_std_studentacademic_tbl where ayid=(select max(ayid) from m_academic where IScurrent=1) and group_id='" + dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString() + "' and del_flag=0";
            DataSet caping1 = cls.fill_dataset(caping);
            string count = Convert.ToString(caping1.Tables[0].Rows.Count);
            //btnsubmit.Enabled = false;
            string str_intake = "select * from m_intake where group_id like '%" + dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString() + "%' and ayid=(select max(ayid) from m_academic where IScurrent=1)";
            DataSet dt12_intake = cls.fill_dataset(str_intake);
            string val = "";
            if (caping1.Tables[0].Rows.Count >= 0 && dt12_intake.Tables[0].Rows.Count > 0)
            {
                //if (group_id == "GRP180")
                //{
                if (Convert.ToInt32(count) <= Convert.ToInt32(dt12_intake.Tables[0].Rows[0]["intake"].ToString()))
                {
                    //  val = confirm_admission(Session["Formno"].ToString(), ((Label)row1.FindControl("lblSubcourse")).Text.ToString().Trim(), dgvData.DataKeys[row.RowIndex].Values["group_id"].ToString());

                    //GridViewRow rowd = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    clear_div_con();
                    //div_offline.Visible = true;
                    //div_receipt.Visible = true;
                    // GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    // GridViewRow row1 = dgvData.Rows[row.RowIndex];
                    //subcourse.Text = ((TextBox)row1.FindControl("Amount")).ToString();
                    //int amt_val = 0;
                    // amt_val = Convert.ToInt32(((TextBox)row1.FindControl("txt_amt_pay")).Text.ToString().Trim());
                    // row contains current Clicked Gridview Row
                    // string grpid = dgvData.DataKeys[row.RowIndex].Values["Group_title"].ToString();
                    string grpid = dgvData.DataKeys[row.RowIndex].Values["Group_title"].ToString();
                    //string fees = dgvData.DataKeys[row.RowIndex].Values["Amount"].ToString();
                    Session.Add("grptitle", grpid);
                    // Session.Add("totalfees", amt_val);
                    DataSet bank_slip = cls.fill_dataset("select F_name+' '+m_name+' '+l_name as name from d_adm_applicant where form_no='" + Session["Formno"].ToString() + "'");
                    string name = bank_slip.Tables[0].Rows[0]["name"].ToString();
                    string formno = Session["Formno"].ToString();

                }
                else
                {
                    ErrorMessageDisplay("Intake Capacity is Full");

                }
            }
            else
            {
                ErrorMessageDisplay("Intake Capacity is Full");
            }


        }
    }

    public void deletebutton()
    {
        DataSet ds1 = cls.fill_dataset("select * from OLA_FY_adm_CourseSelection where formno='" + Session["Formno"].ToString() + "'");//and status ='paid'
        if (ds1.Tables[0].Rows.Count > 0)
        {

            int rowscountdgv = dgvData.Rows.Count;
            int rowcountdatatbl = ds1.Tables[0].Rows.Count;
            for (int i = 0; i < rowscountdgv; i++)
            {
                for (int j = 0; j < rowcountdatatbl; j++)
                {
                    Label lbldgv = (Label)dgvData.Rows[i].FindControl("lblGroupid");
                    string lbldatatbl = ds1.Tables[0].Rows[j]["group_id"].ToString();
                    LinkButton bt = (LinkButton)dgvData.Rows[j].Cells[5].Controls[0];
                    Button btn_con = (Button)dgvData.Rows[i].FindControl("btn_confirm_add");

                    //Button btn_offline = (Button)dgvData.Rows[i].FindControl("btn_off");
                    //Button btn_recpt = (Button)dgvData.Rows[i].FindControl("btn_reciept");

                    TextBox txt_amt_pay = (TextBox)dgvData.Rows[i].FindControl("txt_amt_pay");
                    if (lbldgv.Text == lbldatatbl.ToString())
                    {
                        //dgvData.Rows[0].Cells[5].Enabled = true;
                        bt.Visible = true;
                        //  DataSet ds_add_con=cls.fill_dataset("select distinct a.Form_no,b.group_id,b.formno++replace(b.group_id,'GRP','') from d_adm_applicant as a,OLA_FY_adm_CourseSelection as b where a.Form_no=b.formno and  a.stud_id is null and form_no='" + Session["Formno"].ToString() + "' and b.group_id='"+lbldatatbl.ToString()+"' and Is_Inhouse='0' and a.del_flag=b.del_flag and b.del_flag=0 and status='paid' and (Category='OPEN' or b.formno+replace(b.group_id,'GRP','') in (select stud_id from grant_freeshipscholarship where ayid=(select max(ayid) from m_academic where IsCurrent='1') and del_flag=0)) and b.group_id in (select group_id from m_crs_subjectgroup_tbl where subcourse_id in (select subcourse_id from m_crs_subcourse_tbl where course_id in ('CRS001','CRS002','CRS003') and subcourse_name like 'F%'))");
                        //bocm admisson confirm btn closed by rohit grp155
                        // and subcourse_name like 'F%')
                        //DataSet ds_add_con = cls.fill_dataset("select distinct a.Form_no,b.group_id,b.formno++replace(b.group_id,'GRP','') from d_adm_applicant as a,OLA_FY_adm_CourseSelection as b where a.Form_no=b.formno and  b.stud_id is null and form_no='" + Session["Formno"].ToString() + "' and b.group_id='" + lbldatatbl.ToString() + "'  and a.del_flag=b.del_flag and b.del_flag=0 and status='paid' and b.group_id in (select group_id from m_crs_subjectgroup_tbl where subcourse_id in (select subcourse_id from m_crs_subcourse_tbl where course_id not in ('CRS006','CRS002','CRS010','CRS009'))) union all select a.formno,'" + lbldatatbl.ToString() + "','' from merit_list as a,OLA_FY_adm_CourseSelection as b where a.formno=b.formno+replace(b.group_id,'GRP','') and a.formno='" + Session["Formno"].ToString() + "'+replace('" + lbldatatbl.ToString() + "','GRP','') and stud_id is null  and (group_id not in ('GRP207','GRP147','GRP154','GRP155') or a.merit_dt  in ('2020-08-24') ) union all select a.formno,'" + lbldatatbl.ToString() + "','' from merit_list as a,OLA_FY_adm_CourseSelection as b where a.formno=b.formno+replace(b.group_id,'GRP','') and a.formno='" + Session["Formno"].ToString() + "'+replace('" + lbldatatbl.ToString() + "','GRP','') and stud_id is null  and  a.merit_dt  in ('2020-09-04','2020-09-05','2020-09-07','2020-09-09','2020-09-10','2020-09-11','2020-09-12','2020-09-14','2020-09-15','2020-09-16','2020-09-17','2020-09-18','2020-09-19','2020-09-21','2020-09-22')  ");//or a.merit_dt  <> '2020-08-07')");
                        
                        //Document Approval----sukant  
                        
                        //DataSet ds_add_con = cls.fill_dataset("select * from Documents_approval where form_no='" + Session["Formno"].ToString() + "' and staff_status='approved' and del_flag=0");//or a.merit_dt  <> '2020-08-07')");

                        //if (ds_add_con.Tables.Count > 0)
                        //{
                        //    if (ds_add_con.Tables[0].Rows.Count > 0)
                        //    {
                               btn_con.Visible = true;
                        //        //btn_offline.Visible = true;
                        //        //txt_amt_pay.Visible = true;
                        //        //btn_recpt.Visible = true;

                        //    }
                        //}
                        // LinkButton1.Enabled = false;

                    }
                    DataSet ds_stud_id = cls.fill_dataset("select * from d_adm_applicant where form_no='" + Session["Formno"].ToString() + "'");//or a.merit_dt  <> '2020-08-07')");
                    if (ds_stud_id.Tables[0].Rows[0]["Stud_id"].ToString() != "")
                    {
                        bt.Visible = false;
                        btn_con.Visible = false;
                    }
                }
            }

        }
        else
        {

        }
    }

    public void get_amt_pay(string group_id)
    {
        Label lbldgv = (Label)dgvData.Rows[0].FindControl("lblGroupid");
        ds = ((DataSet)Session["stud_data"]);
        //string str = "select * from online_payment_grant where stud_id='" + Session["Username"] + "' and ayid=(select ayid from m_academic where iscurrent='1')";
        //DataSet dt = cls1.fill_dataset(str);

        int amt_val = 0;
        double k = 0;
        //if (dt.Tables[0].Rows.Count > 0)
        //{
        //    amt_val = Convert.ToInt32(dt.Tables[0].Rows[0]["fees"].ToString());
        //}
        //else
        //{
        string str1_n = "select sum(cast(amount as int)) from m_feemaster where Ayid=(select ayid from m_academic where IsCurrent='1') and Group_id='" + lbldgv.Text + "' and  (Struct_name not like 'TUT%' and Struct_name not like 'TUI%' and Struct_name not like 'dev%')  ";
        dt_n = cls.fill_dataset(str1_n);
        string str1_n_o = "select sum(cast(amount as int)) from m_feemaster where Ayid=(select ayid from m_academic where IsCurrent='1') and Group_id='" + lbldgv.Text + "' and Struct_name  like 'Dev%' ";
        dt_n_o = cls.fill_dataset(str1_n_o);
        string str1 = "select sum(cast(amount as int)) from m_feemaster where Ayid=(select ayid from m_academic where IsCurrent='1') and Group_id='" + lbldgv.Text + "' and (Struct_name like 'TUT%' or Struct_name like 'TUI%')";
        dt1 = cls.fill_dataset(str1);
       
        if (dt1.Tables[0].Rows.Count > 0)
        {
            oth_amt = Convert.ToInt32(dt_n.Tables[0].Rows[0][0].ToString());
            Session["other_amount"] = oth_amt;


            if (Session["cast_new"].ToString() == "OBC" || Session["cast_new"].ToString() == "EBC" || Session["cast_new"].ToString() == "SEBC")
            {
                k = Convert.ToDouble(dt1.Tables[0].Rows[0][0].ToString()) / 2;
                amt_val = Convert.ToInt32(k);
                if (Convert.ToInt32(k.ToString().Split('.').Length) > 1)
                {
                    if (Convert.ToInt32(k.ToString().Split('.')[1]) > 0)
                    {
                        amt_val = amt_val + 1;
                    }
                }
                amt_val = amt_val + Convert.ToInt32(dt_n.Tables[0].Rows[0][0].ToString()) + Convert.ToInt32(dt_n_o.Tables[0].Rows[0][0].ToString());


            }
            else if (Session["cast_new"].ToString() == "TFWS" || Session["cast_new"].ToString() == "NT-1 (NT-B)" || Session["cast_new"].ToString() == "NT-2 (NT-C)" || Session["cast_new"].ToString() == "NT-3 (NT-D)"  || Session["cast_new"].ToString() == "VJ/DT(A)" || Session["cast_new"].ToString() == "SBC" || Session["cast_new"].ToString() == "EWS")
            {
                amt_val = 0;
                amt_val = amt_val + Convert.ToInt32(dt_n_o.Tables[0].Rows[0][0].ToString()) + Convert.ToInt32(dt_n.Tables[0].Rows[0][0].ToString());

            }
            else if (Session["cast_new"].ToString() == "ST" || Session["cast_new"].ToString() == "SC")
            {
                amt_val = 0;
                amt_val = amt_val + Convert.ToInt32(dt_n.Tables[0].Rows[0][0].ToString());
            }
            else if (Session["cast_new"].ToString() == "OPEN")
            {
                k = Convert.ToDouble(dt1.Tables[0].Rows[0][0].ToString());
                amt_val = Convert.ToInt32(k);
                if (Convert.ToInt32(k.ToString().Split('.').Length) > 1)
                {
                    if (Convert.ToInt32(k.ToString().Split('.')[1]) > 0)
                    {
                        amt_val = amt_val + 1;
                    }
                }
                amt_val = amt_val + Convert.ToInt32(dt_n.Tables[0].Rows[0][0].ToString()) + Convert.ToInt32(dt_n_o.Tables[0].Rows[0][0].ToString());

            }

        }
        //}
        txt_amount_final.Text = amt_val.ToString();
    }

    protected void dgvData_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < dgvData.Rows.Count; i++)
        {
            if (dgvData.SelectedIndex == i)
            {
                string grpid = (dgvData.SelectedRow.FindControl("lblGroupid") as Label).Text;
                // Session["group_id"] = grpid;
                //string sub = (dgvData.SelectedRow.FindControl("lbl_subject") as Label).Text;
                Response.Redirect("WebReport.aspx", false);
            }
        }
    }

    protected void dgvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lbl = (Label)dgvData.Rows[e.RowIndex].FindControl("lblGroupid");
        DataSet ds_chk = cls.fill_dataset("select submit_dt from dbo.OLA_FY_adm_CourseSelection where formno = '" + Session["Formno"].ToString() + "' and submit_dt is not null and group_id='" + lbl.Text.Trim() + "'");
        //Label lbl = (Label)dgvData.Rows[e.RowIndex].FindControl("lblGroupid");
        if (ds_chk.Tables.Count > 0 && ds_chk.Tables[0].Rows.Count > 0)
        {
            ErrorMessageDisplay("You have already submitted for the selected group");
        }
        else
        {
            string str = "Delete from OLA_FY_adm_CourseSelection where formno='" + Session["Formno"] + "' and group_id='" + lbl.Text + "'";
            if (cls.bulk_insert_for_applicant(str, "update") == "TRANSACTION SUCCESSFUL")
            {
                DataSet ds = cls.fill_dataset("select distinct pre_faculty,s.subcourse_name,c.course_name,g.Group_title,g.group_id from  dbo.d_adm_applicant app,  dbo.OLA_FY_adm_CourseSelection adm,dbo.m_crs_subcourse_tbl s,dbo.m_crs_course_tbl c,dbo.m_crs_subjectgroup_tbl g where app.Form_no=adm.formno and adm.group_id=g.group_id and c.course_id=s.course_id and g.Subcourse_id=s.subcourse_id and adm.group_id=g.group_id and formno='" + Session["Formno"].ToString() + "' and app.acdid='" + Session["AYID"].ToString() + "'");
                dgvData.DataSource = ds.Tables[0];
                dgvData.DataBind();
                if (Session["submit"].ToString() == "True")
                {
                    for (int i = 0; i <= dgvData.Rows.Count - 1; i++)
                    {
                        dgvData.Rows[i].Cells[5].Enabled = false;

                    }
                }
                //txttotal();
                deletebutton();
            }
        }
    }

    //protected void txt_amount_final_TextChanged(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt32(txt_amount_final.Text)< 10000)
    //    {
    //        txt_amount_final.Text = "";
    //    }
    //    else
    //    {

    //    }
    //}
}