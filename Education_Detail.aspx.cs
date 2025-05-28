using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FY_Education_Detail : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    clsvalidate valid = new clsvalidate();
    protected void Page_Load(object sender, EventArgs e)
    {
        err.Visible = false;
        err12.Visible = false;
        if (!IsPostBack)
        {
            try
            {
                hidetabs();
                for (int i = 2022; i >= 1990; i--)
                {
                    string s = i.ToString();
                    dd12passyear.Items.Add(s);
                    ddl10passyear.Items.Add(s);
                    ddlTYpassyear.Items.Add(s);
                    ddl_pg_passing_year.Items.Add(s);
                }
                if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
                {
                    if (Session["submit"].ToString() == "True")
                    {
                        Response.Redirect("Apply_Courses.aspx", false);
                    }
                    else
                    {                             
                            if (Session["step2_flag"] != null)
                            {
                                if (Session["step2_flag"].ToString() == "True")
                                {
                                    if (Session["step3_flag"].ToString() == "True")
                                    {
                                        if (((DataSet)Session["stud_data"]).Tables[0].Rows.Count > 0)
                                        {
                                            fill_data();
                                        }
                                    }
                                    else
                                    {
                                        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "FY")
                                        {
                                            txt12seatno.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["seat_no"].ToString();
                                            //txt12seatno.Enabled = false;
                                        }
                                        //if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "FYPG")
                                        //{
                                        //    txtTYseatno.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["seat_no1"].ToString();
                                        //    txtTYseatno.Enabled = false;
                                        //}

                                        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SY" || ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "TY" || ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SYPG" || ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SYPG")
                                        {

                                            //txt_sem1_cre.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["reg_sem1"].ToString();
                                            //txt_sem2_cre.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["reg_sem2"].ToString();
                                           
                                     
                                            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "TY" || ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SYPG" || ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "SYPG")
                                            {
                                                //txt_sem3_cre.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["reg_sem3"].ToString();
                                                //txt_sem4_cre.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["reg_sem4"].ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Response.Redirect("Personal_Detail.aspx");
                                }
                            }
                    }
                }
                else
                {
                   Response.Redirect("login.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
    }

    public void dropdown(DropDownList dropdown,string item)
    {
        int i;
        bool flag = false;
        for (i = 0; i <= dropdown.Items.Count; i++)
        {
            dropdown.SelectedIndex = i;
            if (dropdown.SelectedItem.Text == item)
            {
                dropdown.Items.FindByText(item).Selected = true;
                flag = true;
                break;
            }
        }
        if (flag)
        { }
        else
        {
            dropdown.SelectedIndex = 0;
        }
       // dropdown.SelectedIndex= i;
    }

    public void dropdownSelect(DropDownList dropdown1, string item)
    {
        DataSet state_board_name = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + item + "'");
        dropdown1.Items.Clear();
        dropdown1.DataSource = state_board_name.Tables[0];

        dropdown1.DataTextField = "child";
        dropdown1.DataBind();
        dropdown1.Items.Insert(0, new ListItem("-- Select --", "0"));
       // dropdown(ddl10board, setItem);
    }

    public void dropdownSelectHsc(DropDownList dropdown1, string item)
    {
        DataSet dsHSC = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + item + "'");
        dropdown1.Items.Clear();
        dropdown1.DataSource = dsHSC.Tables[0];

        dropdown1.DataTextField = "child";
        dropdown1.DataBind();
        dropdown1.Items.Insert(0, new ListItem("-- Select --", "0"));
        // dropdown(ddl10board, setItem);
    }

    public void dropdownSelectTy(DropDownList dropdown1, string item)
    {
        DataSet dsTY = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + item + "'");
        dropdown1.Items.Clear();
        dropdown1.DataSource = dsTY.Tables[0];

        dropdown1.DataTextField = "child";
        dropdown1.DataBind();
        dropdown1.Items.Insert(0, new ListItem("-- Select --", "0"));
        // dropdown(ddl10board, setItem);
    }

    public void dropdownSelectPG(DropDownList dropdown1, string item)
    {
        DataSet dsPG = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + item + "'");
        dropdown1.Items.Clear();
        dropdown1.DataSource = dsPG.Tables[0];

        dropdown1.DataTextField = "child";
        dropdown1.DataBind();
        dropdown1.Items.Insert(0, new ListItem("-- Select --", "0"));
        // dropdown(ddl10board, setItem);
    }

    public void fill_data()
    {
        //SSC details

        dropdown(ddl10StateBoard,((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_State"].ToString());
        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Board_name"].ToString() != "")
        {
            dropdownSelect(ddl10board, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_State"].ToString());
            if (ddl10board.Items.Count > 1)
            {
                ddl10board.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Board_name"].ToString()).Selected = true;
            }
        }
      
        //dropdown(ddl10board, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Board_name"].ToString());
        if (ddl10passyear.Items.Count > 1)
        {
            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Year"].ToString() != "")
            {
                ddl10passyear.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Year"].ToString().Trim()).Selected = true;
            }
        }
        if (ddl10passmonth.Items.Count > 1)
        {
            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Month"].ToString() != "")
            {
                ddl10passmonth.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Month"].ToString().Trim()).Selected = true;
            }
        }
        //dropdown(ddl10passyear, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Year"].ToString());
        //dropdown(ddl10passmonth, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Month"].ToString());
      

        txt10institutename.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Ins_Name"].ToString();
        txt10instituteplace.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Ins_place"].ToString();
        txt10marksobtained.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Mks_Obtained"].ToString();
        txt10seatno.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_seat_no"].ToString();
        txt10totalmarks.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Mks_OutOf"].ToString();
        txt10_grade.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_grade"].ToString();
       

        if (!string.IsNullOrEmpty(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_First_Attempt"].ToString()))
        {
          if (Convert.ToBoolean(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_First_Attempt"]))
            { rbt10YesAttempt.Checked = true; }
            else
            { rbt10NoAttempt.Checked = true; }
        }
        //-----------------------------------------

        //HSC 

        dropdown(ddl12StateBoard, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["State_board"].ToString());
        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Board_name"].ToString() != "")
        {
            dropdownSelectHsc(ddl12board, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["State_board"].ToString());
            if (ddl12board.Items.Count > 1)
            { 
                ddl12board.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Board_name"].ToString()).Selected = true;
            }
        }


        if (dd12passyear.Items.Count > 1)
        {
            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Year"].ToString() != "")
            {
                dd12passyear.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Year"].ToString().Trim()).Selected = true;
            }
        }
        if (dd12passmonth.Items.Count > 1)
        {
            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Month"].ToString() != "")
            {
                dd12passmonth.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Month"].ToString().Trim()).Selected = true;
            }
        }

        txt12institutename.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Ins_name"].ToString();
        txt12instituteplace.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Ins_place"].ToString();
        txt12marksobtained.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Mks_Obtained"].ToString();        
        txt12totalmarks.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Mks_Outof"].ToString();
        txt12grade.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["grade"].ToString();
        if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString() == "FY")
        {
            txt12seatno.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["seat_no"].ToString();
            //txt12seatno.Enabled = false;
        }
        else
        {
            txt12seatno.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Seat_No"].ToString();
            //txt12seatno.Enabled = true;
        }

        if (!string.IsNullOrEmpty(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"].ToString()))
        {
            if (Convert.ToBoolean(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"]))
            { rbt12HYes.Checked = true; }
            else
            { rbt12Hno.Checked = true; }
        }

        if (!string.IsNullOrEmpty(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["diploma_holder"].ToString()))
        {
            if (Convert.ToBoolean(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["diploma_holder"]))
            { chk12Diploma.Checked = true; }
            else
            { chk12Diploma.Checked = false; }
        }
        //-----------------------------------------


        //FY
        //txtFYinstitutename.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fyi_Institute_name"].ToString();
        //txtFYinstituteplace.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fyi_Institute_place"].ToString();
        txtSem1Sgpi.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_sgpi"].ToString();
        txtSem2Sgpi.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_sgpi"].ToString();

        txt_sem1_mkobtain.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_obtain_mks"].ToString();
        txt_sem2_mkobtain.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_obtain_mks"].ToString();
        txt_sem1_ttmks.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_total_mks"].ToString();
        txt_sem2_ttmks.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_total_mks"].ToString();

        //txtFYinstituteplace.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_Institute_place"].ToString();

        //txt_fy_univer.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_university_name"].ToString();

       

        //-------------------------------graduation

        dropdown(ddlTYstate, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_state"].ToString());
        //ddlTYstate.SelectedItem.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_state"].ToString();

        //if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_board"].ToString() != "")
        //{
        //    dropdownSelectTy(ddlTYboard, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_state"].ToString());

        //    if (ddlTYboard.Items.Count > 1)
        //    {
        //        ddlTYboard.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_board"].ToString()).Selected = true;
        //    }
        //}
        if (ddlTYpassyear.Items.Count > 1)
        {
            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_pass_year"].ToString() != "")
            {
                ddlTYpassyear.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_pass_year"].ToString().Trim()).Selected = true;
            }
        }
        if (ddlTYmonth.Items.Count > 1)
        {
            if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_pass_month"].ToString() != "")
            {

                ddlTYmonth.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_pass_month"].ToString().Trim()).Selected = true;
            }
        }

        txtGraduationCourse.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_course"].ToString();
        txtTYinstitutename.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_Institute_name"].ToString();
        txtTYinstituteplace.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_Institute_place"].ToString();
        txtTYmarksobtained.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_marks_obt"].ToString();
        txtTYtotalmarks.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_out_of"].ToString();
        txtTYgrade.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_grade_obt"].ToString();
        txtTYseatno.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_seat_no"].ToString();
        txtTYgrade.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_grade_obt"].ToString();
        txt_graduation_university.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_board"].ToString();
        ddl_examcet_type.SelectedValue = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["exam_type"].ToString();
      //  txt_cet_mks_obt.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["jee_obt"].ToString();
       // txt_cet_mks_outof.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["jee_outof"].ToString();
        txt_percentile.Text =((DataSet)Session["stud_data"]).Tables[0].Rows[0]["entrance_percentile"].ToString();
        //txt_entrance_rollno.Text= ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["entrance_rollno"].ToString();
        //txt_entrancepasswd.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["entrance_password"].ToString();

        if (!string.IsNullOrEmpty(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"].ToString()))
        {
            if (Convert.ToBoolean(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"]))
            { rbtTYyes.Checked = true; }
            else
            { rbtTYno.Checked = true; }
        }

        //PG

        if (string.IsNullOrEmpty(Convert.ToString(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_inst_name"])))
        {
        }
        else
        {
            dropdown(ddl_pg_state, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_state"].ToString());
            chkPG.Checked = true;
            txt_postGraduate_course.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_course"].ToString();
            txt_pg_institute_name.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_inst_name"].ToString();
            txt_pg_institute_place.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_inst_place"].ToString();
            txt_pg_tot_mks_obt.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_total_mks"].ToString();
            txt_pg_outof_mks.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_out_of_mks"].ToString();
            txt_pg_grade.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_grade"].ToString();
            txt_pg_seat.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_seat_no"].ToString();
            txt_pg_university.Text = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_board"].ToString();

            if (ddl_pg_passing_year.Items.Count > 1)
            {
                if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_passing_tear"].ToString() != "")
                {
                    ddl_pg_passing_year.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_passing_tear"].ToString().Trim()).Selected = true;
                }
            }
            if (ddl_pg_passing_month.Items.Count > 1)
            {
                if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_passing_month"].ToString() != "")
                {
                    ddl_pg_passing_month.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_passing_month"].ToString().Trim()).Selected = true;
                }
            }
            //if (((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_board"].ToString() != "")
            //{
            //    dropdownSelectPG(ddl_pg_board, ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_state"].ToString());

            //    if (ddl_pg_board.Items.Count > 1)
            //    {
            //        ddl_pg_board.Items.FindByText(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_board"].ToString()).Selected = true;
            //    }
            //}
            if (!string.IsNullOrEmpty(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_first_attempt"].ToString()))
            {
                if (Convert.ToBoolean(((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_first_attempt"]))
                { rbtPgYes.Checked = true; }
                else
                { rbtPgNo.Checked = true; }
            }


        }

        //if (1 == 1)
        //{ rbtTYyes.Checked = true; }
        //else
        //{ rbtTYno.Checked = true; }

        //-----------------------------------------
    }

    void hidetabs()
    {
        tabhsc.Visible = false;       
        tab_grad.Visible = false;
        tabpg.Visible = false;
        tabfy.Visible = false;
        //tab_cet.Visible = false;
    }



    protected void ddl10StateBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        DataSet state_board_name = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + ddl10StateBoard.Text.ToString().Trim() + "'");
        ddl10board.Items.Clear();
        ddl10board.DataSource = state_board_name.Tables[0];
        
        ddl10board.DataTextField = "child";
        ddl10board.DataBind();
        ddl10board.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
 
    protected void ddl12StateBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet state_board_name12 = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + ddl12StateBoard.Text.ToString().Trim() + "'");
        ddl12board.Items.Clear();
        ddl12board.DataSource = state_board_name12.Tables[0];

        ddl12board.DataTextField = "child";
        ddl12board.DataBind();
        ddl12board.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    protected void ddlTYstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet state_board_namety = c1.fill_dataset("select  child from dbo.State_category_details where Main = 'State' and parent = '" + ddlTYstate.Text.ToString().Trim() + "'");
        //ddlTYboard.DataSource = state_board_namety.Tables[0];

        //ddlTYboard.DataTextField = "child";
        //ddlTYboard.DataBind();
        //ddlTYboard.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
         
    protected void ddl_pg_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet state_board_namepg = c1.fill_dataset("select child from dbo.State_category_details where Main = 'State' and parent = '" + ddl_pg_state.Text.ToString().Trim() + "'");
        //ddl_pg_board.Items.Clear();
        //ddl_pg_board.DataSource = state_board_namepg.Tables[0];

        //ddl_pg_board.DataTextField = "child";
        //ddl_pg_board.DataBind();
        //ddl_pg_board.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    protected void btn_fy_next_Click(object sender, EventArgs e)
    {
        errorMessage.Visible = false;
        if (txtFYinstitutename.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Institute name";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txt_fy_univer.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter University name";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute place');", true);
        }
        else if (txtFYinstituteplace.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Institute place";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute place');", true);
        }        
        else if (txt_sem1_mkobtain.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Sem-2 marks Obtain";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Sem2 credit');", true);
        }
        else if (txt_sem1_ttmks.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Sem-2 Total Marks";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Sem2 credit');", true);
        }
        else if (txtSem1Sgpi.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Sem-1 SGPI";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Sem2 credit');", true);
        }
        else if (txtSem2Sgpi.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Sem-2 SGPI";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Sem2 credit');", true);
        }
        else if (txt_sem2_mkobtain.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Sem-2 marks Obtain";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Sem2 credit');", true);
        }
        else if (txt_sem2_ttmks.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Sem-2 Total Marks";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Sem2 credit');", true);
        }
        else
        {
            DataSet ds = ((DataSet)Session["stud_data"]);
            string type = ds.Tables[0].Rows[0]["applicant_type"].ToString(), qry = "";

            qry = "update dbo.d_adm_applicant set fyi_Institute_name='" + valid.replacequote( txtFYinstitutename.Text) + "',fy_sem1_obtain_mks='" + txt_sem1_mkobtain.Text + "',fy_sem1_total_mks='" + txt_sem1_mkobtain.Text + "', fyi_Institute_place='" + valid.replacequote (txtFYinstituteplace.Text) + "'," +
                   " fy_sem1_sgpi='" + txtSem1Sgpi.Text + "',fy_university_name='" + txt_fy_univer.Text + "', fy_sem2_sgpi='" + txtSem2Sgpi.Text + "',fy_sem2_total_mks='" + txt_sem2_ttmks.Text + "',fy_sem2_obtain_mks='" + txt_sem2_mkobtain.Text + "'" +
                   " ,step3_flag=1,step3_dt=getDate() where Form_no='" + ds.Tables[0].Rows[0]["formno"].ToString() + "' and ACDID='" + ds.Tables[0].Rows[0]["ayid"].ToString() + "'";



            if (c1.insert_data_app(qry))
            {
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fyi_Institute_name"] = txtFYinstitutename.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fyi_Institute_place"] = txtFYinstituteplace.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_university_name"] = txt_fy_univer.Text;

                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_sgpi"] = txtSem1Sgpi.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_sgpi"] = txtSem2Sgpi.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_CR"] = txt_sem1_cre.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_CR"] = txt_sem2_cre.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_cg"] = txt_sem1_cg.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_cg"] = txt_sem2_cg.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["sem1_ce"] = txt_sem1_ce.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["sem2_ce"] = txt_sem2_ce.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["sem1_sgpi"] = txt_sem1_sgpi.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["sem2_sgpi"] = txt_sem2_sgpi.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_obtain_mks"] = txt_sem1_mkobtain.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_obtain_mks"] = txt_sem2_mkobtain.Text;

                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem1_total_mks"] = txt_sem1_ttmks.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["fy_sem2_total_mks"] = txt_sem2_ttmks.Text;

                if (type == "SY")
                {
                    Session["step3_flag"] = "True";
                    Response.Redirect("Family_Detail.aspx");
                }
                else
                {
                    tabfy.Visible = false;
                    //tabsy.Visible = true;
                    Response.Redirect("Family_Detail.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data not saved');", true);
            }
        }
    }
    protected void btn_fy_back_Click(object sender, EventArgs e)
    {
        tabfy.Visible = false;
        tab_grad.Visible = true;
    }
    protected void btn_post_graduation_next_Click(object sender, EventArgs e)
    {
        errorMessage.Visible = false;
        if (ddl_pg_state.SelectedItem.Text.ToLower() == "--select--")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select State";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select State ');", true);
        }
        else if (txt_pg_university.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select University";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Board');", true);
        }
        else if (txt_postGraduate_course.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Post Graduation course";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txt_pg_institute_name.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Institute name";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txt_pg_institute_place.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Institute place";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute place');", true);
        }
        else if (ddl_pg_passing_year.SelectedItem.Text.ToLower() == "year")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select passing year";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select passing year');", true);
        }
        else if (ddl_pg_passing_month.SelectedItem.Text.ToLower() == "month")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select Passing month";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Passing month');", true);
        }
        else if (txt_pg_seat.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Seat No.";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Seat No.');", true);
        }
        else if (txt_pg_tot_mks_obt.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Marks obtained";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Marks obtained');", true);
        }
        else if (txt_pg_outof_mks.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Out of marks";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Out of marks');", true);
        }
        //else if (txt_pg_grade.Text == "")
        //{
        //    errorMessage.Visible = true;
        //    errorMessage.InnerText = "Enter Grade";
        //    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Grade');", true);
        //}
        else
        {
            // DataSet ds = ((DataSet)Session["App_data"]);
            string type = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString(), qry = "";
            int attempt = 0;
            if (rbtPgYes.Checked)
            {
                attempt = 1;
            }

            qry = "update dbo.d_adm_applicant set pg_inst_name='" +valid.replacequote( txt_pg_institute_name.Text) + "', pg_inst_place='" + valid.replacequote(txt_pg_institute_place.Text) + "', " +
                   " pg_board='" +txt_pg_university.Text + "',pg_seat_no='" + txt_pg_seat.Text + "',pg_first_attempt='" + attempt + "', pg_state='" + ddl_pg_state.SelectedItem.Text + "'," +
                   " pg_total_mks='" + txt_pg_tot_mks_obt.Text + "',pg_passing_tear='" + ddl_pg_passing_year.Text + "',pg_course='"+txt_postGraduate_course.Text+"',pg_passing_month='" + ddl_pg_passing_month.Text + "', pg_out_of_mks='" + txt_pg_outof_mks.Text + "', pg_grade='" + txt_pg_grade.Text + "' " +
                   " ,step3_flag=1,step3_dt=getDate() where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"] + "'";

            if (c1.insert_data_app(qry))
            {
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_inst_name"] = txtTYinstitutename.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_inst_place"] = txtTYinstituteplace.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_board"] = txt_pg_university.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_state"] = ddlTYstate.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_total_mks"] = txtTYmarksobtained.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_out_of_mks"] = txtTYtotalmarks.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_grade"] = txtTYgrade.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_passing_tear"] = ddl_pg_passing_year.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_passing_month"] = ddl_pg_passing_month.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["pg_seat_no"] = txt_pg_seat.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Mks_Obtained"] = txt12marksobtained.Text;
                Session["step3_flag"] = "True";
                if (type == "SY")
                {
                    tabpg.Visible = false;
                    tabfy.Visible = true;
                    //txt_fy_univer.Text = "";
                }
                else
                {
                    Response.Redirect("Family_Detail.aspx");
                }
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data not saved');", true);
                errorMessage.Visible = true;
                errorMessage.InnerText = "Data not saved";
            }
        }
    }
    protected void btn_post_graduation_back_Click(object sender, EventArgs e)
    {
        tab_grad.Visible = true;
        tabpg.Visible = false;
    }
    protected void btn_graduation_back_Click(object sender, EventArgs e)
    {
        tab_grad.Visible = false;
        tabhsc.Visible = true;
    }
    protected void btn_graduation_next_Click(object sender, EventArgs e)
    {
        errorMessage.Visible = false;
        if (ddlTYstate.SelectedItem.Text.ToLower() == "--select--")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select State";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select State ');", true);
        }
        else if (txt_graduation_university.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select University";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Board');", true);
        }
        else if (txtGraduationCourse.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Course name";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txtTYinstitutename.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Institute name";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txtTYinstituteplace.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Institute place";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute place');", true);
        }
        else if (ddlTYpassyear.SelectedItem.Text.ToLower() == "year")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select passing year";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select passing year');", true);
        }
        else if (ddlTYmonth.SelectedItem.Text.ToLower() == "month")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Select Passing month";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Passing month');", true);
        }
        else if (txtTYseatno.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Seat No.";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Seat No.');", true);
        }
        else if (txtTYmarksobtained.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Marks obtained";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Marks obtained');", true);
        }
        else if (txtTYtotalmarks.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Out of marks";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Out of marks');", true);
        }
        //else if (txt_cet_mks_obt.Text == "")
        //{
        //    errorMessage.Visible = true;
        //    errorMessage.InnerText = "Enter Exam Marks Obtained";
        //}
        //else if (txt_cet_mks_outof.Text == "")
        //{
        //    errorMessage.Visible = true;
        //    errorMessage.InnerText = "Enter Exam Marks Out of";
        //}
        else if (ddl_examcet_type.SelectedIndex == 0)
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Exam Type";
        }
        else if (txt_percentile.Text == "")
        {
            errorMessage.Visible = true;
            errorMessage.InnerText = "Enter Percentile of Entrance Exam";
        }
        //else if (txt_entrance_rollno.Text == "")
        //{
        //    errorMessage.Visible = true;
        //    errorMessage.InnerText = "Enter Entrance Exam Roll no";
        //}
        //else if (txt_entrancepasswd.Text == "")
        //{
        //    errorMessage.Visible = true;
        //    errorMessage.InnerText = "Enter Entrance Exam Password";
        //}
        //else if (txtTYgrade.Text == "")
        //{
        //    errorMessage.Visible = true;
        //    errorMessage.InnerText = "Enter Grade";
        //    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Grade');", true);
        //}
        else
        {
            // DataSet ds = ((DataSet)Session["App_data"]);
            string type = ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["applicant_type"].ToString(), qry = "";
            int attempt = 0;
            if (rbtTYyes.Checked)
            {
                attempt = 1;
            }

            //qry = "update dbo.d_adm_applicant set ty_Institute_name='" +valid.replacequote( txtTYinstitutename.Text )+ "', ty_Institute_place='" + valid.replacequote( txtTYinstituteplace.Text) + "', " +
            //       " ty_board='" + txt_graduation_university.Text + "',ty_pass_year='" + ddlTYpassyear.Text + "',ty_course='" + txtGraduationCourse.Text + "',ty_pass_month='" + ddlTYmonth.Text + "', ty_state='" + ddlTYstate.SelectedItem.Text + "',ty_seat_no='" + txtTYseatno.Text + "'," +
            //       " ty_marks_obt='" + txtTYmarksobtained.Text + "', ty_out_of='" + txtTYtotalmarks.Text + "',entrance_percentile='" + txt_percentile.Text + "',entrance_password='" + txt_entrancepasswd.Text + "',entrance_rollno='" + txt_entrance_rollno.Text + "',exam_type='" + ddl_examcet_type.Text + "',jee_obt='" + txt_cet_mks_obt.Text + "',jee_outof='" + txt_cet_mks_outof.Text + "', ty_grade_obt='" + txtTYgrade.Text + "',ty_first_attempt=" + attempt + " " +
            //       " ,step3_flag=1,step3_dt=getDate() where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"] + "'";

            qry = "update dbo.d_adm_applicant set ty_Institute_name='" + valid.replacequote(txtTYinstitutename.Text) + "', ty_Institute_place='" + valid.replacequote(txtTYinstituteplace.Text) + "', " +
                 " ty_board='" + txt_graduation_university.Text + "',ty_pass_year='" + ddlTYpassyear.Text + "',ty_course='" + txtGraduationCourse.Text + "',ty_pass_month='" + ddlTYmonth.Text + "', ty_state='" + ddlTYstate.SelectedItem.Text + "',ty_seat_no='" + txtTYseatno.Text + "'," +
                 " ty_marks_obt='" + txtTYmarksobtained.Text + "', ty_out_of='" + txtTYtotalmarks.Text + "',entrance_percentile='" + txt_percentile.Text + "',exam_type='" + ddl_examcet_type.Text + "',jee_obt='',jee_outof='', ty_grade_obt='" + txtTYgrade.Text + "',ty_first_attempt=" + attempt + " " +
                 " ,step3_flag=1,step3_dt=getDate() where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"] + "'";

            if (c1.insert_data_app(qry))
            {
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_Institute_name"] = txtTYinstitutename.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_Institute_place"] = txtTYinstituteplace.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_board"] = txt_graduation_university.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_state"] = ddlTYstate.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_marks_obt"] = txtTYmarksobtained.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_out_of"] = txtTYtotalmarks.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_grade_obt"] = txtTYgrade.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_pass_month"] = ddlTYmonth.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_pass_year"] = ddlTYpassyear.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["ty_seat_no"] = txtTYseatno.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["exam_type"] = ddl_examcet_type.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["jee_obt"] = txt_cet_mks_obt.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["jee_outof"] = txt_cet_mks_outof.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["entrance_percentile"] = txt_percentile.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["entrance_rollno"] = txt_entrance_rollno.Text;
                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["entrance_password"] = txt_entrancepasswd.Text;

                //((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Mks_Obtained"] = txt12marksobtained.Text;
                Session["step3_flag"] = "True";
                if (chkPG.Checked)
                {
                    tab_grad.Visible = false;
                    tabpg.Visible = true;
                }
                else
                {
                    if (type == "SY")
                    {
                        tab_grad.Visible = false;
                        tabfy.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("Family_Detail.aspx");
                    }
                }

            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data not saved');", true);
                errorMessage.Visible = true;
                errorMessage.InnerText = "Data not saved";
            }
        }
    }
    protected void btn_hsc_back_Click(object sender, EventArgs e)
    {
        tabssc.Visible = true;
        tabhsc.Visible = false;
    }    
    protected void btn_ssc_next_Click(object sender, EventArgs e)
    {
        err.Visible = false;

        if (ddl10StateBoard.SelectedIndex <= 0)
        {
            err.Visible = true;
            err.InnerText = "Select State";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select State ');", true);
        }
        else if (ddl10board.SelectedIndex <= 0)
        {
            err.Visible = true;
            err.InnerText = "Select Board";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Board');", true);
        }
        else if (txt10institutename.Text == "")
        {
            err.Visible = true;
            err.InnerText = "Enter Institute name";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txt10instituteplace.Text == "")
        {
            err.Visible = true;
            err.InnerText = "Enter Institute place";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute place');", true);
        }
        else if (ddl10passyear.SelectedIndex <= 0)
        {
            err.Visible = true;
            err.InnerText = "Select passing year";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select passing year');", true);
        }
        else if (ddl10passmonth.SelectedIndex <= 0)
        {
            err.Visible = true;
            err.InnerText = "Select Passing manth";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Passing manth');", true);
        }
        else if (txt10seatno.Text == "")
        {
            err.Visible = true;
            err.InnerText = "Enter Seat No.";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Seat No.');", true);
        }
        else if (txt10marksobtained.Text == "")
        {
            err.Visible = true;
            err.InnerText = "Enter Marks obtained";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Marks obtained');", true);
        }
        else if (txt10totalmarks.Text == "")
        {
            err.Visible = true;
            err.InnerText = "Enter Out of marks";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Out of marks');", true);
        }

        else if (Convert.ToInt16(txt10marksobtained.Text) > Convert.ToInt16(txt10totalmarks.Text))
        {
            err.Visible = true;
            err.InnerText = "Marks Obtained should be less than total marks";
        }
        else
        {
            string grade = "";
            if (txt10_grade.Text != "")
            {
                grade = txt10_grade.Text;
            }
            else
            {
                grade = txt10_grade.Text;
            }
            DataSet ds = ((DataSet)Session["stud_data"]);
            string type = ds.Tables[0].Rows[0]["applicant_type"].ToString(), qry = "";
            int attempt = 1;

            if (rbt10YesAttempt.Checked)
            {
                attempt = 1;
            }
            else
            {
                attempt = 0;
            }

            qry = "update dbo.d_adm_applicant set s_exam='S.S.C', S_Ins_Name='" + valid.replacequote( txt10institutename.Text) + "', S_Ins_place='" + valid.replacequote( txt10instituteplace.Text )+ "', S_seat_no='" + txt10seatno.Text + "'," +
                   " S_Board_name='" + ddl10board.SelectedItem.Text + "', S_State='" + ddl10StateBoard.SelectedItem.Text + "', S_Month='" + ddl10passmonth.SelectedItem.Text + "', S_Year='" + ddl10passyear.SelectedItem.Text + "'," +
                   " S_Mks_Obtained='" + txt10marksobtained.Text + "', S_Mks_OutOf='" + txt10totalmarks.Text + "', S_grade='" + grade + "',S_First_Attempt=" + attempt + " " +
                   " ,step3_flag=1,step3_dt=getDate() where Form_no='" + ds.Tables[0].Rows[0]["formno"].ToString() + "' and ACDID='" + ds.Tables[0].Rows[0]["ayid"].ToString() + "'";

            if (c1.insert_data_app(qry))
            {
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Ins_Name"] = txt10institutename.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Ins_place"] = txt10instituteplace.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_seat_no"] = txt10seatno.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Board_name"] = ddl10board.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_State"] = ddl10StateBoard.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Month"] = ddl10passmonth.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Year"] = ddl10passyear.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Mks_Obtained"] = txt10marksobtained.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_Mks_OutOf"] = txt10totalmarks.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_grade"] = txt10_grade.Text;

                if (rbt10NoAttempt.Checked == true)
                {
                    ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_First_Attempt"] = false;
                }
                else
                {
                    ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["S_First_Attempt"] = true;
                }

                tabssc.Visible = false;
                tabhsc.Visible = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data not saved');", true);
            }
        }
    }
    protected void btn_hsc_next_Click(object sender, EventArgs e)
    {
        err12.Visible = false;


        if (ddl12StateBoard.SelectedIndex <= 0)
        {
            err12.Visible = true;
            err12.InnerText = "Select State";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select State ');", true);
        }
        else if (ddl12board.SelectedIndex <= 0)
        {
            err12.Visible = true;
            err12.InnerText = "Select Board";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Board');", true);
        }
        else if (txt12institutename.Text == "")
        {
            err12.Visible = true;
            err12.InnerText = "Enter Institute name";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute name');", true);
        }
        else if (txt12instituteplace.Text == "")
        {
            err12.Visible = true;
            err12.InnerText = "Enter Institute place";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Institute place');", true);
        }
        else if (dd12passyear.SelectedIndex <= 0)
        {
            err12.Visible = true;
            err12.InnerText = "Select passing year";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select passing year');", true);
        }
        else if (dd12passmonth.SelectedIndex <= 0)
        {
            err12.Visible = true;
            err12.InnerText = "Select Passing month";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Passing month');", true);
        }
        else if (txt12seatno.Text == "")
        {
            err12.Visible = true;
            err12.InnerText = "Enter Seat No.";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Seat No.');", true);
        }
        else if (txt12marksobtained.Text == "")
        {
            err12.Visible = true;
            err12.InnerText = "Enter Marks obtained";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Marks obtained');", true);
        }
        else if (txt12totalmarks.Text == "")
        {
            err12.Visible = true;
            err12.InnerText = "Enter Out of marks";
            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Out of marks');", true);
        }

        else if (Convert.ToInt16(txt12marksobtained.Text) > Convert.ToInt16(txt12totalmarks.Text))
        {

            err12.Visible = true;
            err12.InnerText = "Marks Obtained should be less than total marks";

        }
        else
        {
            string grade12 = "";
            if (txt12grade.Text != "")
            {
                grade12 = txt12grade.Text;
            }
            else
            {
                grade12 = "";
            }

            DataSet ds = ((DataSet)Session["stud_data"]);
            string type = ds.Tables[0].Rows[0]["applicant_type"].ToString(), qry = "";
            int attempt = 1, diploma = 0;
            if (rbt12HYes.Checked)
            {
                attempt = 1;
            }
            else
            {
                attempt = 0;
            }

            if (chk12Diploma.Checked)
            {
                diploma = 1;
            }
            else
            {
                diploma = 0;
            }


            qry = "update dbo.d_adm_applicant set exam='H.S.C', Ins_name='" +valid.replacequote( txt12institutename.Text) + "', Ins_place='" +valid.replacequote( txt12instituteplace.Text) + "', Seat_No='" + txt12seatno.Text + "'," +
                   " Board_name='" + ddl12board.SelectedItem.Text + "', State_board='" + ddl12StateBoard.SelectedItem.Text + "', Month='" + dd12passmonth.SelectedItem.Text + "', Year='" + dd12passyear.SelectedItem.Text + "'," +
                   " Mks_Obtained='" + txt12marksobtained.Text + "', Mks_Outof='" + txt12totalmarks.Text + "',diploma_holder=" + diploma + ", grade='" + grade12 + "',firstAttempt=" + attempt + " " +
                   " ,step3_flag=1,step3_dt=getDate() where Form_no='" + ds.Tables[0].Rows[0]["formno"].ToString() + "' and ACDID='" + ds.Tables[0].Rows[0]["ayid"].ToString() + "' ";

            if (c1.insert_data_app(qry))
            {
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Ins_name"] = txt12institutename.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Ins_place"] = txt12instituteplace.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Seat_No"] = txt12seatno.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Board_name"] = ddl12board.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["State_board"] = ddl12StateBoard.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Month"] = dd12passmonth.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Year"] = dd12passyear.SelectedItem.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Mks_Obtained"] = txt12marksobtained.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["Mks_Outof"] = txt12totalmarks.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["grade"] = txt12grade.Text;
                ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"] = attempt;

                //if (type == "FY")
                //{            
                //    if (rbt12HYes.Checked == true)
                //    {
                //        ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"] = true;
                //    }
                //    else
                //    {
                //        ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["firstAttempt"] = false;
                //    }
                //    if (chk12Diploma.Checked == true)
                //    {
                //        ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["diploma_holder"] = true;
                //    }
                //    else
                //    {
                //        ((DataSet)Session["stud_data"]).Tables[0].Rows[0]["diploma_holder"] = false;
                //    }
                //    Session["step3_flag"]="True";
                //    Response.Redirect("Family_Detail.aspx");
                //}
                //else
                //{
                //    tabhsc.Visible = false;
                //    tabgraduate.Visible = true;
                //}


                tabhsc.Visible = false;
                tab_grad.Visible = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data not saved');", true);
            }
        }
    }

    void fillState()
    {
        ddl_pg_state.Items.Clear();
        ddl_pg_state.Items.Add("--SELECT--");
        ddl_pg_state.Items.Add("MAHARASHTRA");
        ddl_pg_state.Items.Add("ANDHRA PRADESH");
        ddl_pg_state.Items.Add("ARUNACHAL PRADESH");
        ddl_pg_state.Items.Add("ASSAM");
        ddl_pg_state.Items.Add("BIHAR");
        ddl_pg_state.Items.Add("CHHATTISGARH");
        ddl_pg_state.Items.Add("GOA");
        ddl_pg_state.Items.Add("GUJARAT");
        ddl_pg_state.Items.Add("HARYANA");
        ddl_pg_state.Items.Add("HIMACHAL PRADESH");
        ddl_pg_state.Items.Add("JAMMU AND KASHMIR");
        ddl_pg_state.Items.Add("JHARKHAND");
        ddl_pg_state.Items.Add("MADHYA PRADESH");
        ddl_pg_state.Items.Add("MANIPUR");
        ddl_pg_state.Items.Add("MIZORAM");
        ddl_pg_state.Items.Add("NAGALAND");
        ddl_pg_state.Items.Add("ORISSA");
        ddl_pg_state.Items.Add("PUNJAB");
        ddl_pg_state.Items.Add("RAJASTHAN");
        ddl_pg_state.Items.Add("SIKKIM");
        ddl_pg_state.Items.Add("TAMIL NADU");
        ddl_pg_state.Items.Add("TRIPURA");
        ddl_pg_state.Items.Add("UTTAR PRADESH");
        ddl_pg_state.Items.Add("UTTARAKHAND");
        ddl_pg_state.Items.Add("WEST BENGAL");
        ddl_pg_state.Items.Add("CHANDIGARH");
        ddl_pg_state.Items.Add("NATIONAL CAPITAL TERRITORY OF DELHI");
    }
    protected void btn_exam_details_back_Click(object sender, EventArgs e)
    {
        tabhsc.Visible = false;
        tabssc.Visible = false;
        tabpg.Visible = false;
        tabfy.Visible = false;
        tab_grad.Visible = true;
    }
}