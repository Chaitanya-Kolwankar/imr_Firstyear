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

public partial class Basic_Detail : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataSet ds = new DataSet();
    DataSet dss;
    DateTime final_date;
    clsvalidate valid = new clsvalidate();
    int count = 0;
    basic_model bs = new basic_model();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        ds = (DataSet)Session["stud_data"];
        if (Session["applicant_type"] != null)
        {
            if (Session["applicant_type"].ToString() == "FY")
            {
                divrdb.Visible = false;
                rbthouse.Visible = false;
                rbtoutsider.Visible = false;
                //rbt17number.Visible = true;
            }            
            else
            {
                divrdb.Visible = false;
            }
        }
        if (!IsPostBack)
        {
            try
            {
                errorMessage.Visible = false;
                btnsubmit.Attributes.Add("onclick", "return validate()");
                //rdbDisable();

               

                Session["ayid"] = valid.check_db_null(ds.Tables[0].Rows[0]["ayid"].ToString());
                if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
                {
                    if (Session["submit"] != null && Session["submit"].ToString() == "False")
                    {

                        check_flag_withimage();

                        if (Session["step1_flag"].ToString() == "True")
                        {
                            //ds = cls.fill_dataset("select distinct F_name,M_name ,L_name ,Mo_name, Email_id ,Phone_No,Mob_No,form_no ,convert(varchar(max),DOB,105) as DOB,Is_Inhouse,Prev_Stud_Id,Branch,Stud_Class from d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");

                            txtfirstname.Text = valid.check_db_null(ds.Tables[0].Rows[0]["F_name"].ToString().ToUpper());
                            txtmiddlename.Text = valid.check_db_null(ds.Tables[0].Rows[0]["M_name"].ToString().ToUpper());
                            txtsurname.Text = valid.check_db_null(ds.Tables[0].Rows[0]["L_name"].ToString().ToUpper());
                            txtmothername.Text = ds.Tables[0].Rows[0]["Mo_name"].ToString().ToUpper();

                            Session["name"] = txtsurname.Text + " " + txtfirstname.Text + " " + txtmiddlename.Text + " " + txtmothername.Text ;
                            //DateTime dateOfbirth = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString()).Date;

                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["dob"])))
                            {
                                setDOB(ds.Tables[0].Rows[0]["dob"].ToString());
                            }
                            //DateTime date_new = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"].ToString());
                            //string test = date_new.ToString("ddmmyyyy");
                            //String dt_new = date_new.Day + "-" + date_new.Month + "-" + date_new.Year;
                            //txtdate_activity.Text = dateOfbirth.ToShortDateString();
                            setDOB(ds.Tables[0].Rows[0]["dob"].ToString());

                     
                            txtemailid.Text = valid.check_db_null(ds.Tables[0].Rows[0]["email_id"].ToString().ToLower());
                            txtcontact.Text = valid.check_db_null(ds.Tables[0].Rows[0]["mob_no"].ToString());
                            txtothercontact.Text = valid.check_db_null(ds.Tables[0].Rows[0]["Phone_no"].ToString());

                          

                            if (ds.Tables[0].Rows[0]["inserted"].ToString() == "Yes")
                            {
                                if (ds.Tables[0].Rows[0]["Is_Inhouse"].ToString() == "0")
                                {
                                    rbthouse.Checked = true;
                                    txtprevious.Visible = true;
                                    span_stud_id.Visible = true;
                                    lblPrevious.Visible = true;
                                    Img2.Visible = true;
                                    Label1.Visible = true;
                                    txtprevious.Text = valid.check_db_null(ds.Tables[0].Rows[0]["Prev_Stud_Id"].ToString().Trim().ToUpper());

                                    Session["Previous_id"] = txtprevious.Text.ToString().Trim().ToUpper();
                                    if (ds.Tables[0].Rows[0]["Branch"] != DBNull.Value)
                                    {
                                        if (ds.Tables[0].Rows[0]["Branch"].ToString().Trim() == "Viva Junior College Of Commerce Nalasopara")
                                        {
                                            ddbranch.SelectedIndex = 2;
                                            divinhouse.Visible = true;
                                            ddbranch.Visible = true;
                                        }
                                        else
                                        {
                                            divinhouse.Visible = true;
                                            ddbranch.Visible = true;
                                            ddbranch.SelectedIndex = 1;
                                        }
                                    }
                                    else
                                    {
                                        divinhouse.Visible = false;
                                        ddbranch.Visible = false;
                                        ddbranch.SelectedIndex = 0;
                                    }
                                }
                                else
                                {
                                    rbtoutsider.Checked = true;
                                }
                            }
                            else
                            {
                                rbtoutsider.Checked = true;
                            }

                            Session["exists"] = true;
                            Session["FatherName"] = ds.Tables[0].Rows[0]["m_name"].ToString().ToUpper();
                            Session["MotherName"] = ds.Tables[0].Rows[0]["mo_name"].ToString().ToUpper();


                        }
                        else
                        {
                            txtfirstname.Text = valid.check_db_null(ds.Tables[0].Rows[0]["F_name"].ToString().ToUpper());
                            txtmiddlename.Text = valid.check_db_null(ds.Tables[0].Rows[0]["M_name"].ToString().ToUpper());
                            txtsurname.Text = valid.check_db_null(ds.Tables[0].Rows[0]["L_name"].ToString().ToUpper());
                            txtmothername.Text = ds.Tables[0].Rows[0]["Mo_name"].ToString().ToUpper();
                            Session["name"] = txtsurname.Text + " " + txtfirstname.Text + " " + txtmiddlename.Text + " " + txtmothername.Text;
                            //txtdate_activity.Text = valid.check_db_null(ds.Tables[0].Rows[0]["dob"].ToString().ToUpper()); 
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["dob"])))
                            {
                                setDOB(ds.Tables[0].Rows[0]["dob"].ToString());
                            }
                            txtemailid.Text = valid.check_db_null(ds.Tables[0].Rows[0]["email_id"].ToString().ToLower());
                            txtcontact.Text = valid.check_db_null(ds.Tables[0].Rows[0]["mob_no"].ToString());
                            txtothercontact.Text = "";
                            rbtoutsider.Checked = true;

                        }
                    }
                    else
                    {
                        Response.Redirect("Apply_Courses.aspx", false);
                        //valid.DisableControls(this);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx", false);
            }
        }

    }

    public void rdbDisable()
    {
        rbthouse.Visible = false;
        rbtoutsider.Visible = false;
        rbt17number.Visible = false;
    }

    public void check_flag_withimage()
    {
        dss = check_flag();
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
                Response.Redirect("index.aspx");
                return null;
            }

        }
        catch (Exception ex)
        {

            Response.Redirect("index.aspx");
            return null;
        }
    }

    public void retrievedata()
    {
        
        //bs.final_date = Convert.ToDateTime(txtdate_activity.Text.ToString());
        bs.first_name = valid.replacequote(txtfirstname.Text);
        bs.middle_name = valid.replacequote(txtmiddlename.Text);
        bs.last_name = valid.replacequote(txtsurname.Text);
        bs.mother_name = valid.replacequote(txtmothername.Text);
        bs.mobile_no = txtcontact.Text;
        bs.phone_no = txtothercontact.Text;
        bs.Prev_Stud_Id = txtprevious.Text;
        bs.email_id = txtemailid.Text;
        bs.formno = Session["Formno"].ToString();

        if (Session["step1_flag"].ToString() == "True")
        {
            bs.step1_flag = "True";
        }
        else
        {
            bs.step1_flag = "False";
        }

        bs.Branch = ddbranch.SelectedItem.Text.Trim(); 
        bs.Is_Inhouse = inhouse_outhouse;
        bs.ayid = Session["ayid"].ToString();
        
     
    }

    string step1_flg = "False";
    int inhouse_outhouse = 3;
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime date = DateTime.Parse(txtdate_activity.Text);
            //string month=date.Month.ToString();
            //string day = date.Day.ToString();
            //string year = date.Year.ToString();
            //string DOB = month +"/"+ day +"/"+ year + " 12:00:00 AM";
            //string date_final = ddyear.SelectedItem.Text + "/" + ddmonth.SelectedValue.ToString() + "/" + ddday.SelectedItem.Text;
           // string date_final = ddday.Text.ToString() + '-' + ddmonth.Text.ToString() + '-' + ddyear.Text.ToString();

            string DOB = ddday.Text.ToString() + '-' + ddmonth.Text.ToString() + '-' + ddyear.Text.ToString();

            //DateTime DOB = Convert.ToDateTime(date_final);





            errorMessage.Visible = false;
            if (rbthouse.Checked == false && rbtoutsider.Checked == false && rbt17number.Checked == false)
            {
                string str = "Please select Inhouse ,Outsider";
                errorMessage.InnerText = str;
                errorMessage.Visible = true;
            }
            else if (ddday.Text.ToLower() == "day" || ddmonth.Text.ToLower() == "month" || ddyear.Text.ToLower() == "year")
            {
                string str = "Please select proper DOB.";
                errorMessage.InnerText = str;
                errorMessage.Visible = true;
            }
            else
            {

                if (rbthouse.Checked == true)
                {
                    inhouse_outhouse = 0;
                    Session["inhouse/out"] = inhouse_outhouse;
                }
                else if (rbtoutsider.Checked == true)
                {
                    inhouse_outhouse = 1;
                    Session["inhouse/out"] = inhouse_outhouse;
                }
                else if (rbt17number.Checked == true)
                {
                    inhouse_outhouse = 2;
                    Session["inhouse/out"] = inhouse_outhouse;
                }

                string branch;
                branch = ddbranch.SelectedItem.Text.Trim();
                Session["branch"] = ddbranch.Text.ToString().Trim();

                string prev_id;
                if (txtprevious.Text.Trim() == string.Empty)
                {
                    prev_id = "NULL";
                }
                else
                {
                    prev_id = txtprevious.Text.Trim().ToUpper();

                    Session["Previous_id"] = txtprevious.Text.ToString().Trim();
                }
                //string subcourse_id;
                bs.subcourse_id = getsubcourse(Session["ayid"].ToString(), Session["Formno"].ToString());

                /////////////////////////////////////////////////////////////////////////////////////////////
                if (rbthouse.Checked == true)
                {
                    if (txtprevious.Text == "" && ddbranch.SelectedItem.Text == "--Select--")
                    {
                        string str = "Please select Branch and Previous year student Id";
                        string cScript = @"<script type='text/javascript'>alert( '" + str + "');location.href='Basic_Detail.aspx';</script>";
                        ClientScript.RegisterStartupScript(
                        typeof(Page),
                        "simplemessage",
                         cScript);
                    }

                }

                retrievedata();
           
                var result = "";
                //if (bs.step1_flag == "False")
                //{
                //    string ins_query = "INSERT INTO [d_adm_applicant] ([ACDID],[Form_no],[F_name],[M_name],[L_name],[Mo_name],[DOB],[Phone_No],[Mob_No],[Email_id],user_id,step1_flag,step1_dt,Del_Flag,Is_Inhouse,Prev_Stud_Id,Branch,Stud_Class)";
                //    ins_query = ins_query + "values('" + bs.ayid + "','" + bs.formno + "','" + bs.first_name + "','" + bs.middle_name + "','" + bs.last_name + "','" + bs.mother_name + "','" + DOB + "','" + bs.phone_no + "','" + bs.mobile_no + "','" + bs.email_id + "','admin',1,getdate(),0,'" + bs.Is_Inhouse + "','" + bs.Prev_Stud_Id + "','" + bs.Branch + "','" + bs.subcourse_id + "')";
                //    if (cls.bulk_insert_for_applicant(ins_query, "insert").ToString() == "TRANSACTION SUCCESSFUL")
                //    {
                //        result="TRANSACTION SUCCESSFUL";
                //    }
                //    else
                //    {
                //        result = "";
                //    }
                //}
                //else
                {
                    string updt_query = "update d_adm_applicant set F_name='" + bs.first_name.ToUpper() + "',M_name='" + bs.middle_name.ToUpper() + "',L_name ='" + bs.last_name.ToUpper() + "',Mo_name='" + bs.mother_name.ToUpper() + "',dob='" + DOB + "',Phone_No='" + bs.phone_no + "',Mob_No='" + bs.mobile_no + "',Email_id='" + bs.email_id + "',step1_flag=1,step1_dt=getdate(),Stud_Class='" + bs.subcourse_id + "'  where form_no='" + bs.formno + "' and ACDID='" + bs.ayid + "' and del_flag=0";

                    if (cls.bulk_insert_for_applicant(updt_query, "update").ToString() == "TRANSACTION SUCCESSFUL")
                    {
                        result = "TRANSACTION SUCCESSFUL";
                    }
                    else
                    {
                        result = "";
                    }
                }
         

                    DataSet ds1 = new DataSet();
                    DataSet stud_ds = new DataSet();
                    if (result != "")
                    {

                        if (Session["step1_flag"].ToString() == "False")
                        {
                            stud_ds = cls.fill_dataset("Select app.*,ent.passwd,ent.formno,ent.seat_no,ent.Out_of as reg_outOf,ent.Marks_obtained as reg_marksObt,ent.Percentage as reg_perct,ent.pass_month,ent.pass_year,ent.SEM_1 as reg_sem1,ent.SEM_2 as reg_sem2,ent.SEM_3 as reg_sem3,ent.SEM_4 as reg_sem4 from d_adm_applicant app ,dbo.adm_applicant_registration ent where app.form_no=ent.formno and ACDID = (select max(ayid) from dbo.m_academic) and form_no='" + Session["Formno"].ToString() + "' and app.del_flag=0");

                            if (Session["applicant_type"].ToString() == "FY")
                            {
                                string str1 = "Select app.*,ent.passwd,ent.formno,ent.seat_no,ent.Out_of as reg_outOf,ent.Marks_obtained as reg_marksObt,ent.Percentage as reg_perct,ent.pass_month,ent.pass_year,ent.SEM_1 as reg_sem1,ent.SEM_2 as reg_sem2,ent.SEM_3 as reg_sem3,ent.SEM_4 as reg_sem4 from d_adm_applicant app ,dbo.adm_applicant_registration ent where app.form_no=ent.formno and ACDID = (select max(ayid) from dbo.m_academic) and form_no='" + Session["Formno"].ToString() + "' and app.del_flag=0";
                                //str1 += "select * from hsc_previous_detail where hsc_seat_no='" + ds.Tables[0].Rows[0]["seat_no"].ToString() + "'";
                                stud_ds = cls.fill_dataset(str1);
                            }

                            if (stud_ds.Tables.Count > 0 && stud_ds.Tables[0].Rows.Count > 0)
                            {
                                DataTable dt_submit = cls.fill_datatable("select submit_dt from dbo.OLA_FY_adm_CourseSelection where formno = '" + Session["Formno"].ToString() + "' and submit_dt is not null");


                                if (dt_submit.Rows.Count > 0)
                                {
                                    stud_ds.Tables[0].Columns.Add("is_submited");
                                    stud_ds.Tables[0].Rows[0]["is_submited"] = "Yes";
                                    stud_ds.Tables[0].Columns.Add("applicant_type");
                                    stud_ds.Tables[0].Rows[0]["applicant_type"] = Session["applicant_type"].ToString();
                                    stud_ds.Tables[0].Columns.Add("Inserted");
                                    stud_ds.Tables[0].Rows[0]["is_submited"] = "Yes";
                                    stud_ds.Tables[0].Columns.Add("ayid");
                                    stud_ds.Tables[0].Rows[0]["ayid"] = Session["ayid"].ToString();

                                }
                                else
                                {
                                    stud_ds.Tables[0].Columns.Add("is_submited");
                                    stud_ds.Tables[0].Rows[0]["is_submited"] = "No";
                                    stud_ds.Tables[0].Columns.Add("applicant_type");
                                    stud_ds.Tables[0].Rows[0]["applicant_type"] = Session["applicant_type"].ToString();
                                    stud_ds.Tables[0].Columns.Add("Inserted");
                                    stud_ds.Tables[0].Rows[0]["Inserted"] = "Yes";
                                    stud_ds.Tables[0].Columns.Add("ayid");
                                    stud_ds.Tables[0].Rows[0]["ayid"] = Session["ayid"].ToString();

                                }

                    

                            }
                   


                            if (stud_ds.Tables[0].Rows.Count > 0)
                            {
                                Session["stud_data"] = stud_ds;
                                ds = (DataSet)Session["stud_data"];
                            }
                            
                        }

                        ds.Tables[0].Rows[0]["F_name"] = txtfirstname.Text.ToUpper();
                        ds.Tables[0].Rows[0]["M_name"] = txtmiddlename.Text.ToUpper();
                        ds.Tables[0].Rows[0]["L_name"] = txtsurname.Text.ToUpper();
                        ds.Tables[0].Rows[0]["Mo_name"] = txtmothername.Text.ToUpper();
                        //ds.Tables[0].Rows[0]["dob"] = Convert.ToDateTime(txtdate_activity.Text.ToString()).Date;
                        try
                        { ds.Tables[0].Rows[0]["dob"] = DOB; }
                        catch (Exception ex)
                        {
                            DOB = ddday.Text.ToString() + '-' + ddmonth.Text.ToString() + '-' + ddyear.Text.ToString();
                            ds.Tables[0].Rows[0]["dob"] = DOB; 
                        
                        }
                       
                        ds.Tables[0].Rows[0]["Phone_No"] = txtothercontact.Text;
                        ds.Tables[0].Rows[0]["Mob_No"] = txtcontact.Text;
                        ds.Tables[0].Rows[0]["Email_id"] = txtemailid.Text;
                        ds.Tables[0].Rows[0]["Is_Inhouse"] = inhouse_outhouse;
                        ds.Tables[0].Rows[0]["Prev_Stud_Id"] = prev_id;
                        ds.Tables[0].Rows[0]["Branch"] = branch;
                        Session["FatherName"] = txtmiddlename.Text.ToUpper();
                        Session["MotherName"] = txtmothername.Text.ToString().ToUpper();
                        Session["step1_flag"] = "True";
                        Response.Redirect("Personal_Detail.aspx", false);

                    }
                    else
                    {
                        Session["step1_flag"] = "False";
                        Response.Redirect("Login.aspx",false);
                    }
                

                ////////////////////////////////////////////////////////////////////////////////////////////

           

            }
            /////////////////////////////////////////////////////////////////////////////////////////////

        }
        catch (Exception ex)
        {
            ex.ToString();
        }

           

        }
    
    

    public string getsubcourse(string ayid, string formno)
    {
        string q;
        q = "select distinct Subcourse_id from  dbo.m_crs_subjectgroup_tbl where group_id=(select distinct group_id from dbo.adm_applicant_entry_FY where formno='" + formno + "' and AYID='" + ayid + "')";
        SqlDataReader s;
        s = cls.RetriveQuery(q);
        if (s.HasRows)
        {
            while (s.Read())
            {
                return s[0].ToString().Trim().ToUpper();
            }
        }
        return string.Empty;
    }

 
    public void enable_Inhouse_fields()
    {
        txtprevious.Text = string.Empty;
        ddbranch.SelectedIndex = 0;
        //txtuniver_enrol_no.Text = string.Empty;

        txtprevious.Visible = true;
        ddbranch.Visible = true;
        // txtuniver_enrol_no.Visible = true;
        lblPrevious.Visible = true;
        txtprevious.Visible = true;
        // lblUniv_enrol_no.Visible = true;
        Img2.Visible = true;
        Label1.Visible = true;
        span_stud_id.Visible = true;

    }

    protected void rbthouse_CheckedChanged1(object sender, EventArgs e)
    {
        if (rbthouse.Checked)
        {
            if (Convert.ToBoolean(Session["inhouse_flag"]) == true)
            {
                enable_Inhouse_fields();
            }
            else
            {

                //txtprevious.Visible = true;
                ddbranch.Visible = true;
                // txtuniver_enrol_no.Visible = true;
                lblPrevious.Visible = true;
                txtprevious.Visible = true;
                // lblUniv_enrol_no.Visible = true;
                Img2.Visible = true;
                Label1.Visible = true;
                span_stud_id.Visible = true;
            }
        }
        else
        {

            //txtprevious.Visible = true;
            ddbranch.Visible = true;
            // txtuniver_enrol_no.Visible = true;
            lblPrevious.Visible = true;
            txtprevious.Visible = true;
            // lblUniv_enrol_no.Visible = true;
            Img2.Visible = true;
            Label1.Visible = true;
            span_stud_id.Visible = true;
        }
    }
    protected void rbtoutsider_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtoutsider.Checked)
        {

            //txtprevious.Visible = true;
            ddbranch.Visible = false;
            // txtuniver_enrol_no.Visible = true;
            lblPrevious.Visible = false;
            txtprevious.Visible = false;
            txtprevious.Text = "";
            // lblUniv_enrol_no.Visible = true;
            Img2.Visible = false;
            Label1.Visible = false;
            span_stud_id.Visible = false;

        }
        
    }
    protected void rbt17number_CheckedChanged(object sender, EventArgs e)
    {
        if (rbt17number.Checked)
        {

            //txtprevious.Visible = true;
            ddbranch.Visible = false;
            // txtuniver_enrol_no.Visible = true;
            lblPrevious.Visible = false;
            txtprevious.Text = "";
            txtprevious.Visible = false;
            // lblUniv_enrol_no.Visible = true;
            Img2.Visible = false;
            Label1.Visible = false;
            span_stud_id.Visible = false;

        }
    }
    protected void txtprevious_TextChanged(object sender, EventArgs e)
    {
        if (txtprevious.Text != "")
        {
            if (txtprevious.Text.Length == 8)
            {
                DataSet ds = cls.fill_dataset("select * from dbo.hsc_previous_detail where stud_id='" + txtprevious.Text + "' and del_flag=0");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    txtprevious.Text = "";
                    string script = "alert(\"Student ID does not exist\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
        }
    }
    public void setDOB(string dob)
    {
        string[] arr;
        if (dob.Contains("/"))
        {
            DateTime dob_d = Convert.ToDateTime(dob);


            arr = dob_d.ToShortDateString().Split('/');

            ddday.SelectedIndex = Convert.ToInt32(arr[1].Trim().ToString());

            if (arr[0].Trim().ToString().Length <= 1)
            {
                ddmonth.SelectedValue = "0" + arr[0].Trim().ToString();

            }
            else
            {
                ddmonth.SelectedValue = arr[0].Trim().ToString();
            }
            ddyear.SelectedIndex = ddyear.Items.IndexOf(new ListItem(arr[2].Trim().ToString()));

        }
        else
        {
            arr = dob.Split('-');
            ddday.SelectedIndex = Convert.ToInt32(arr[0].Trim().ToString());
            if (arr[1].Trim().ToString().Length <= 1)
            {
                ddmonth.Text = "0" + arr[1].Trim().ToString();

            }
            else
            {
                ddmonth.SelectedItem.Text = arr[1].Trim().ToString();
            }
            ddyear.SelectedIndex = ddyear.Items.IndexOf(new ListItem(arr[2].Trim().ToString()));

        }

        // string[] arr_dt = dob.Split('-');
       

        

    }

}