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


public partial class FY_Other_Information : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataSet ds = new DataSet();
    clsvalidate valid = new clsvalidate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            try
            {
                btnsubmit.Attributes.Add("onclick", "return validate()");
                if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
                {
                    if (Session["submit"].ToString() == "True")
                    {
                        Response.Redirect("Apply_Course.aspx", false);

                    }
                    if (Session["step4_flag"] != null)
                    {
                        if (Session["step4_flag"].ToString() == "True")
                        {
                            if (Session["step5_flag"].ToString() == "True")
                            {
                                fill_data();
                            }
                            else
                            {
                                fillCaste();
                                //ddlCategory.Enabled = false;
                                ddlCast.Enabled = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("Family_Detail.aspx");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    void fillCaste()
    {

        ds = cls.fill_dataset("select Extra_Curricular_Activities ,Other_criteria ,Category ,Caste ,Phy_handicap_Description ,is_NSS_NCC ,is_Scholarship ,Earning , NonEarning , Annual_Income from d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");


        //ddlCategory.SelectedItem.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OPEN")
        {
            ddlCategory.SelectedIndex = 1;
            Session["category"] = "OPEN";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-1 (NT-B)")
        {
            ddlCategory.SelectedIndex = 2;
            Session["category"] = "NT-1 (NT-B)";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-2 (NT-C)")
        {
            ddlCategory.SelectedIndex = 3;
            Session["category"] = "NT-2 (NT-C)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-3 (NT-D)")
        {
            ddlCategory.SelectedIndex = 4;
            Session["category"] = "NT-3 (NT-D)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OBC")
        {
            ddlCategory.SelectedIndex = 5;
            Session["category"] = "OBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SBC")
        {
            ddlCategory.SelectedIndex = 6;
            Session["category"] = "SBC";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SC")
        {
            ddlCategory.SelectedIndex = 7;
            Session["category"] = "SC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "ST")
        {
            ddlCategory.SelectedIndex = 8;
            Session["category"] = "ST";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "VJ/DT(A)")
        {
            ddlCategory.SelectedIndex = 9;
            Session["category"] = "VJ/DT(A)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "TWFS")
        {
            ddlCategory.SelectedIndex = 10;
            Session["category"] = "TWFS";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EBC")
        {
            ddlCategory.SelectedIndex = 11;
            Session["category"] = "EBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SEBC")
        {
            ddlCategory.SelectedIndex = 12;
            Session["category"] = "SEBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EWS")
        {
            ddlCategory.SelectedIndex = 13;
            Session["category"] = "EWS";

        }

        DataSet state_board_name = cls.fill_dataset("select  child from dbo.State_category_details where Main = 'Reserved Category' and parent = '" + ddlCategory.Text.ToString().Trim() + "'");
        ddlCast.DataSource = state_board_name.Tables[0];

        ddlCast.DataTextField = "child";
        ddlCast.DataBind();
        ddlCast.Items.Insert(0, new ListItem("-- Select --", "0"));



        if (ds.Tables[0].Rows[0]["Caste"].ToString() != "")
        {
            ddlCast.Enabled = true;
            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();

        }

        if (ds.Tables[0].Rows[0]["Caste"].ToString() == "0")
        {

            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
            ddlCast.Enabled = false;
        }


        if (ds.Tables[0].Rows[0]["Other_criteria"].ToString() != "")
        {
            specialcategory.SelectedItem.Text = ds.Tables[0].Rows[0]["Other_criteria"].ToString();

        }
        if (ds.Tables[0].Rows[0]["Phy_handicap_Description"].ToString() != "")
        {
            ddhandicap.SelectedItem.Text = ds.Tables[0].Rows[0]["Phy_handicap_Description"].ToString();
        }
        if (ds.Tables[0].Rows[0]["is_NSS_NCC"].ToString() != "")
        {
            ddlNcc.SelectedItem.Text = ds.Tables[0].Rows[0]["is_NSS_NCC"].ToString();
        }

    }

    public void fill_data()
    {
        //ds = cls.fill_dataset("select Category,Certificate_No,Other_criteria,Phy_handicap,Phy_handicap_Description,Extra_Curricular_Activities,is_NSS_NCC,is_Scholarship,Earning,NonEarning,Annual_Income from dbo.d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");


        ds = cls.fill_dataset("select Extra_Curricular_Activities,Certificate_No ,Other_criteria ,Category ,Caste ,Phy_handicap_Description ,is_NSS_NCC ,is_Scholarship ,Earning,case when remark is null then '' when Remark like '%|%' then substring(Remark, 1, CHARINDEX('|',Remark)-1) else remark end as Remark,case when remark is null then '' when Remark like '%|%' then substring(Remark, CHARINDEX('|',Remark)+1, LEN(Remark)) else '' end as DTE , NonEarning , Annual_Income from d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");


        //ddlCategory.SelectedItem.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OPEN")
        {
            ddlCategory.SelectedIndex = 1;
            Session["category"] = "OPEN";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-1 (NT-B)")
        {
            ddlCategory.SelectedIndex = 2;
            Session["category"] = "NT-1 (NT-B)";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-2 (NT-C)")
        {
            ddlCategory.SelectedIndex = 3;
            Session["category"] = "NT-2 (NT-C)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "NT-3 (NT-D)")
        {
            ddlCategory.SelectedIndex = 4;
            Session["category"] = "NT-3 (NT-D)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "OBC")
        {
            ddlCategory.SelectedIndex = 5;
            Session["category"] = "OBC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SBC")
        {
            ddlCategory.SelectedIndex = 6;
            Session["category"] = "SBC";


        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SC")
        {
            ddlCategory.SelectedIndex = 7;
            Session["category"] = "SC";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "ST")
        {
            ddlCategory.SelectedIndex = 8;
            Session["category"] = "ST";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "VJ/DT(A)")
        {
            ddlCategory.SelectedIndex = 9;
            Session["category"] = "VJ/DT(A)";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "TWFS")
        {
            ddlCategory.SelectedIndex = 10;
            Session["category"] = "TWFS";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EBC")
        {
            ddlCategory.SelectedIndex = 11;
            Session["category"] = "EBC";
            incomediv.Visible = true;
            dincdate.SelectedIndex = 0;
            dincmonth.SelectedIndex = 0;
            dincyear.SelectedIndex = 0;
            txtincert.Text = "";
        }

        if (ds.Tables[0].Rows[0]["Category"].ToString() == "SEBC")
        {
            ddlCategory.SelectedIndex = 12;
            Session["category"] = "SEBC";
            incomediv.Visible = true;
            dincdate.SelectedIndex = 0;
            dincmonth.SelectedIndex = 0;
            dincyear.SelectedIndex = 0;
            txtincert.Text = "";

        }
        if (ds.Tables[0].Rows[0]["Category"].ToString() == "EWS")
        {
            ddlCategory.SelectedIndex = 13;
            Session["category"] = "EWS";
            incomediv.Visible = true;
            dincdate.SelectedIndex = 0;
            dincmonth.SelectedIndex = 0;
            dincyear.SelectedIndex = 0;
            txtincert.Text = "";
        }

        if (ds.Tables[0].Rows[0]["Category"].ToString() != "OPEN" && ds.Tables[0].Rows[0]["Category"].ToString() != "EBC")
        {
            castdiv.Visible = true;
            incomediv.Visible = true;
            dincdate.SelectedIndex = 0;
            dincmonth.SelectedIndex = 0;
            dincyear.SelectedIndex = 0;
            dddate.SelectedIndex = 0;
            ddmonth.SelectedIndex = 0;
            ddyear.SelectedIndex = 0;
            txtvalidity.Text = "";
            txtincert.Text = "";
        }

        if (ds.Tables[0].Rows[0]["Remark"].ToString() != "")
        {
            txtaadhar.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
        }
        else
        {
            txtaadhar.Text = "";
        }

        if (ds.Tables[0].Rows[0]["DTE"].ToString() != "")
        {
            txtdteid.Text = ds.Tables[0].Rows[0]["DTE"].ToString();
        }
        else
        {
            txtdteid.Text = "";
        }

        if (ds.Tables[0].Rows[0]["Certificate_No"].ToString().ToUpper() != string.Empty)
        {
            String[] arrcert = new String[5];
            if (ds.Tables[0].Rows[0]["Certificate_No"].ToString().Contains("|"))
            {
                arrcert = Convert.ToString(ds.Tables[0].Rows[0]["Certificate_No"]).Split('|');
                txtCertificateno.Text = arrcert[0].ToString();
                txtCertificateno.Visible = true;
                certificate.Visible = true;

                if (arrcert.Length > 3)
                {
                    castdiv.Visible = true;
                    incomediv.Visible = true;
                    if (!string.IsNullOrEmpty(arrcert[2].ToString()))
                    {
                        setcastdd(arrcert[2].ToString());
                    }
                    else
                    {
                        dddate.SelectedIndex = 0;
                        ddmonth.SelectedIndex = 0;
                        ddyear.SelectedIndex = 0;
                    }

                    if (!string.IsNullOrEmpty(arrcert[4].ToString()))
                    {
                        setincomedd(arrcert[4].ToString());
                    }
                    else
                    {
                        dincdate.SelectedIndex = 0;
                        dincmonth.SelectedIndex = 0;
                        dincyear.SelectedIndex = 0;
                    }

                    if (arrcert[1].ToString() != "")
                    {
                        txtvalidity.Text = arrcert[1].ToString();
                    }
                    else
                    {
                        txtvalidity.Text = "";
                    }

                    if (arrcert[3].ToString() != "")
                    {
                        txtincert.Text = arrcert[3].ToString();
                    }
                    else
                    {
                        txtincert.Text = "";
                    }
                }
                else
                {
                    castdiv.Visible = false;
                    incomediv.Visible = true;
                    if (!string.IsNullOrEmpty(arrcert[2].ToString()))
                    {
                        setincomedd(arrcert[2].ToString());
                    }
                    else
                    {
                        dincdate.SelectedIndex = 0;
                        dincmonth.SelectedIndex = 0;
                        dincyear.SelectedIndex = 0;
                    }

                    if (arrcert[1].ToString() != "")
                    {
                        txtincert.Text = arrcert[1].ToString();
                    }
                    else
                    {
                        txtincert.Text = "";
                    }
                }
            }
            else
            {
                txtCertificateno.Text = ds.Tables[0].Rows[0]["Certificate_No"].ToString();
                txtCertificateno.Visible = true;
                //lblCertificateNo.Visible = true;
                certificate.Visible = true;
            }
        }

        DataSet state_board_name = cls.fill_dataset("select  child from dbo.State_category_details where Main = 'Reserved Category' and parent = '" + ddlCategory.Text.ToString().Trim() + "'");
        ddlCast.DataSource = state_board_name.Tables[0];

        ddlCast.DataTextField = "child";
        ddlCast.DataBind();
        ddlCast.Items.Insert(0, new ListItem("-- Select --", "0"));



        if (ds.Tables[0].Rows[0]["Caste"].ToString() != "")
        {
            ddlCast.Enabled = true;
            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();

        }

        if (ds.Tables[0].Rows[0]["Caste"].ToString() == "0")
        {

            ddlCast.SelectedItem.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
            ddlCast.Enabled = false;
        }


        if (ds.Tables[0].Rows[0]["Other_criteria"].ToString() != "")
        {
            specialcategory.SelectedItem.Text = ds.Tables[0].Rows[0]["Other_criteria"].ToString();

        }
        if (ds.Tables[0].Rows[0]["Phy_handicap_Description"].ToString() != "")
        {
            ddhandicap.SelectedItem.Text = ds.Tables[0].Rows[0]["Phy_handicap_Description"].ToString();
        }
        if (ds.Tables[0].Rows[0]["is_NSS_NCC"].ToString() != "")
        {
            ddlNcc.SelectedItem.Text = ds.Tables[0].Rows[0]["is_NSS_NCC"].ToString();
        }


        if (ds.Tables[0].Rows[0]["is_Scholarship"].ToString().ToUpper() == "TRUE")
        {
            rbtnNo_isScholorship.Checked = true;
        }
        else
        {
            rbtnYes_isScholorship.Checked = true;
        }

        if (checkNull("Extra_Curricular_Activities") == "Yes")
        {
            rbtYesCuriculum.Checked = true;

        }
        else
        {
            rbtNoCuricullum.Checked = true;

        }
        txtEarning.Text = checkNull("Earning");
        txtNonEarning.Text = checkNull("NonEarning");
        txtTotal.Text = calc_total(txtEarning.Text, txtNonEarning.Text);
        txtIncome.Text = checkNull("Annual_Income");
    }

    public void setcastdd(string dob)
    {
        string[] arr;
        arr = dob.Split('-');

        if (arr[1].ToString().Contains("Day") || arr[1].ToString().Contains("Month") || arr[1].ToString().Contains("Year"))
        {
            ddmonth.SelectedIndex = 0;
            ddyear.SelectedIndex = 0;
            dddate.SelectedIndex = 0;
        }
        else
        {
            dddate.SelectedIndex = Convert.ToInt32(arr[0].Trim().ToString());
            if (arr[1].Trim().ToString().Length <= 1)
            {
                ddmonth.Text = "0" + arr[1].Trim().ToString();
            }
            else
            {
                ddmonth.SelectedValue = arr[1].Trim().ToString();
            }
            ddyear.SelectedIndex = ddyear.Items.IndexOf(new ListItem(arr[2].Trim().ToString()));
        }
    }

    public void setincomedd(string dob)
    {
        string[] arr;
        arr = dob.Split('-');

        if (arr[1].ToString().Contains("Day") || arr[1].ToString().Contains("Month") || arr[1].ToString().Contains("Year"))
        {
            dincdate.SelectedIndex = 0;
            dincmonth.SelectedIndex = 0;
            dincyear.SelectedIndex = 0;
        }
        else
        {
            dincdate.SelectedIndex = Convert.ToInt32(arr[0].Trim().ToString());
            if (arr[1].Trim().ToString().Length <= 1)
            {
                dincmonth.Text = "0" + arr[1].Trim().ToString();
            }
            else
            {
                dincmonth.SelectedValue = arr[1].Trim().ToString();
            }
            dincyear.SelectedIndex = ddyear.Items.IndexOf(new ListItem(arr[2].Trim().ToString()));
        }

    }


    public String checkNull(string s)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][s] == DBNull.Value)
            {
                return "";
            }
            else
            {
                return ds.Tables[0].Rows[0][s].ToString();
            }
        }
        else
        {
            return "";
        }

    }

    public string calc_total(string s1, string s2)
    {
        try
        {
            int earn = Convert.ToInt32(s1);
            int nonearn = Convert.ToInt32(s2);
            int total = earn + nonearn;
            string total_final = Convert.ToString(total);
            return total_final;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool check_radio()
    {
        if (rbtnYes_isScholorship.Checked == false && rbtnNo_isScholorship.Checked == false)
        {
            return false;
        }

        return true;
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void ddlCast_SelectedIndexChanged(object sender, EventArgs e)
    {

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


    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        errorMessage.Visible = false;
        if (ddlCategory.SelectedItem.Text != "OPEN")
        {
            if (ddlCast.SelectedIndex > 0 || ddlCast.SelectedItem.Text != "--Select--")
            {
                if (check_radio() == true)
                {
                    string UpdateQuery = string.Empty;
                    string specialCat = string.Empty;
                    string NCC_NSS = string.Empty;
                    string is_scholorship = string.Empty;
                    Session["category"] = ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper();
                    UpdateQuery = "Update d_adm_applicant set Category='" + ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper() + "', ";

                    string splCategory;
                    if (specialcategory.SelectedIndex == 0)
                    {
                        splCategory = "NULL";
                    }
                    else
                    {
                        splCategory = specialcategory.SelectedItem.Text.Trim();
                        // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                    }
                    UpdateQuery = UpdateQuery + " Other_criteria='" + splCategory + "', ";

                    string caste;
                    if (ddlCast.SelectedIndex == 0)
                    {
                        caste = "NULL";
                    }
                    else
                    {
                        caste = ddlCast.SelectedItem.Text.Trim();
                        // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                    }

                    UpdateQuery = UpdateQuery + " Caste='" + caste + "', ";

                    bool chkflag = false;
                    string certificatedt = "";
                    if (ddlCategory.SelectedItem.Text != "OPEN")
                    {
                        if (ddlCategory.SelectedItem.Text == "EBC" || ddlCategory.SelectedItem.Text == "SEBC" || ddlCategory.SelectedItem.Text == "EWS")
                        {
                            if (txtincert.Text == "" || dincdate.SelectedIndex == 0 || dincmonth.SelectedIndex == 0 || dincyear.SelectedIndex == 0)
                            {
                                chkflag = true;
                            }
                            else
                            {
                                chkflag = false;
                                certificatedt = txtincert.Text + '|' + dincdate.Text.ToString() + '-' + dincmonth.Text.ToString() + '-' + dincyear.Text.ToString();
                            }
                            UpdateQuery = UpdateQuery + "Certificate_No='" + txtCertificateno.Text + "'+'|'+'" + certificatedt + "',";
                        }
                        else
                        {
                            if (txtvalidity.Text == "" || ddmonth.SelectedIndex == 0 || ddyear.SelectedIndex == 0 || dddate.SelectedIndex == 0 || dincdate.SelectedIndex == 0 || dincmonth.SelectedIndex == 0 || dincyear.SelectedIndex == 0)
                            {
                                chkflag = true;
                            }
                            else
                            {
                                chkflag = false;
                                certificatedt = txtvalidity.Text + '|' + dddate.Text.ToString() + '-' + ddmonth.Text.ToString() + '-' + ddyear.Text.ToString() + '|' + txtincert.Text + '|' + dincdate.Text.ToString() + '-' + dincmonth.Text.ToString() + '-' + dincyear.Text.ToString();
                            }
                            UpdateQuery = UpdateQuery + "Certificate_No='" + txtCertificateno.Text + "'+'|'+'" + certificatedt + "',";
                        }
                    }

                    string handicap;
                    if (ddhandicap.SelectedIndex == 0)
                    {
                        handicap = "NULL";
                    }
                    else
                    {
                        handicap = ddhandicap.SelectedItem.Text.Trim();
                        // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                    }
                    UpdateQuery = UpdateQuery + " Phy_handicap_Description='" + handicap + "', ";


                    if (txtIncome.Text != string.Empty)
                    {
                        UpdateQuery = UpdateQuery + " Annual_Income='" + txtIncome.Text.Trim().ToUpper() + "', ";
                    }
                    else
                    {
                        UpdateQuery = UpdateQuery + " Annual_Income='', ";
                    }
                    if (rbtYesCuriculum.Checked == true)
                    {
                        UpdateQuery = UpdateQuery + " Extra_Curricular_Activities='Yes', ";

                    }
                    else if (rbtNoCuricullum.Checked == false)
                    {
                        UpdateQuery = UpdateQuery + " Extra_Curricular_Activities='No', ";

                    }
                    else
                    {
                        UpdateQuery = UpdateQuery + " Extra_Curricular_Activities=null, ";
                    }

                    UpdateQuery = UpdateQuery + " is_NSS_NCC='" + ddlNcc.Text + "', ";



                    if (rbtnYes_isScholorship.Checked == true)
                    {
                        UpdateQuery = UpdateQuery + " is_Scholarship=0, ";
                    }
                    else
                    {
                        UpdateQuery = UpdateQuery + " is_Scholarship=1, ";
                    }
                    UpdateQuery = UpdateQuery + " Earning=" + Convert.ToInt32(txtEarning.Text.ToString().Trim()) + ", NonEarning=" + Convert.ToInt32(txtNonEarning.Text.ToString().Trim()) + ",Remark='" + txtaadhar.Text + "'+'|'+'" + txtdteid.Text + "'  ";
                    UpdateQuery = UpdateQuery + "";

                    if (txtaadhar.Text == "")
                    {
                        //ErrorMessageDisplay("Please provide Aadhar No.");

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please provide Aadhar No.');", true);
                        chkflag = true;
                    }
                    else if (txtaadhar.Text.Length != 12)
                    {
                        //ErrorMessageDisplay("Please provide 12 Digit Aadhar No.");

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please provide 12 Digit Aadhar No.');", true);
                        chkflag = true;
                    }

                    if (txtdteid.Text == "" && chkflag == false)
                    {
                        //ErrorMessageDisplay("Please provide DTE Application No.");

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please provide DTE Application No.');", true);
                        chkflag = true;
                    }

                    bool updated = false;
                    if (chkflag == false)
                    {
                        updated = cls.insert_data_app(UpdateQuery + ",step5_flag=1,step5_dt=getdate() " + "where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");
                        if (updated == true)
                        {
                            Session["step5_flag"] = true;
                            Response.Redirect("Document_upload.aspx");
                        }
                        else
                        {
                            ErrorMessageDisplay("Error!!");
                            //ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Error!!!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Fill All Cast/Income Details.');", true);
                    }
                }
                else
                {
                    errorMessage.InnerText = "Please Check Scholarship Options";
                    errorMessage.Visible = true;
                }
            }
            else
            {

                errorMessage.InnerText = "Please Select Caste ";
                errorMessage.Visible = true;
            }
        }
        else
        {
            if (check_radio() == true)
            {
                string UpdateQuery = string.Empty;
                string specialCat = string.Empty;
                string NCC_NSS = string.Empty;
                string is_scholorship = string.Empty;
                Session["category"] = ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper();
                UpdateQuery = "Update d_adm_applicant set Category='" + ddlCategory.SelectedItem.Text.ToString().Trim().ToUpper() + "', ";

                string splCategory;
                if (specialcategory.SelectedIndex == 0)
                {
                    splCategory = "NULL";
                }
                else
                {
                    splCategory = specialcategory.SelectedItem.Text.Trim();
                    // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                }
                UpdateQuery = UpdateQuery + " Other_criteria='" + splCategory + "', ";

                string caste;
                if (ddlCast.SelectedIndex == 0)
                {
                    caste = "NULL";
                }
                else
                {
                    caste = ddlCast.SelectedItem.Text.Trim();
                    // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                }

                UpdateQuery = UpdateQuery + " Caste='" + caste + "', ";


                string handicap;
                if (ddhandicap.SelectedIndex == 0)
                {
                    handicap = "NULL";
                }
                else
                {
                    handicap = ddhandicap.SelectedItem.Text.Trim();
                    // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
                }
                UpdateQuery = UpdateQuery + " Phy_handicap_Description='" + handicap + "', ";





                if (txtIncome.Text != string.Empty)
                {
                    UpdateQuery = UpdateQuery + " Annual_Income='" + txtIncome.Text.Trim().ToUpper() + "', ";
                }
                else
                {
                    UpdateQuery = UpdateQuery + " Annual_Income='', ";
                }
                if (rbtYesCuriculum.Checked == true)
                {
                    UpdateQuery = UpdateQuery + " Extra_Curricular_Activities='Yes', ";

                }
                else if (rbtNoCuricullum.Checked == false)
                {
                    UpdateQuery = UpdateQuery + " Extra_Curricular_Activities='No', ";

                }
                else
                {
                    UpdateQuery = UpdateQuery + " Extra_Curricular_Activities=null, ";
                }
                bool chkflag = false;
                UpdateQuery = UpdateQuery + " is_NSS_NCC='" + ddlNcc.Text + "', ";

                if (txtaadhar.Text == "")
                {
                    //ErrorMessageDisplay("Please provide Aadhar No.");

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please provide Aadhar No.');", true);
                    chkflag = true;
                }
                else if (txtaadhar.Text.Length != 12)
                {
                    //ErrorMessageDisplay("Please provide 12 Digit Aadhar No.");

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please provide 12 Digit Aadhar No.');", true);
                    chkflag = true;
                }

                if (txtdteid.Text == "")
                {
                    //ErrorMessageDisplay("Please provide DTE Application No.");

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please provide DTE Application No.');", true);
                    chkflag = true;
                }


                if (rbtnYes_isScholorship.Checked == true)
                {
                    UpdateQuery = UpdateQuery + " is_Scholarship=0, ";
                }
                else
                {
                    UpdateQuery = UpdateQuery + " is_Scholarship=1, ";
                }
                UpdateQuery = UpdateQuery + " Earning=" + Convert.ToInt32(txtEarning.Text.ToString().Trim()) + ", NonEarning=" + Convert.ToInt32(txtNonEarning.Text.ToString().Trim()) + ",Remark='" + txtaadhar.Text + "'+'|'+'" + txtdteid.Text + "'  ";
                UpdateQuery = UpdateQuery + "";



                bool updated = false;
                if (chkflag == false)
                {
                    updated = cls.insert_data_app(UpdateQuery + ",step5_flag=1,step5_dt=getdate() " + "where Form_no='" + Session["Formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");
                    if (updated == true)
                    {
                        Session["step5_flag"] = true;
                        Response.Redirect("Document_upload.aspx");
                    }
                    else
                    {
                        ErrorMessageDisplay("Error!!");
                        //ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Error!!!')", true);
                    }
                }
                else
                {

                }
            }
            else
            {
                errorMessage.InnerText = "Please Check Scholarship Options";
                errorMessage.Visible = true;
            }
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.Text == "OPEN")
        {
            ddlCast.Enabled = false;
            if (ddlCast.SelectedIndex > 0)
            {
                ddlCast.SelectedIndex = 0;
            }

            castdiv.Visible = false;
            incomediv.Visible = false;
            txtincert.Text = "";
            dincdate.SelectedIndex = 0;
            dincmonth.SelectedIndex = 0;
            dincyear.SelectedIndex = 0;
            txtvalidity.Text = "";
            ddmonth.SelectedIndex = 0;
            ddyear.SelectedIndex = 0;
            dddate.SelectedIndex = 0;

            certificate.Visible = false;
            //lblCertificateNo.Visible = false ;
            txtCertificateno.Visible = false;
        }
        else
        {
            certificate.Visible = true;
            //lblCertificateNo.Visible = true;
            if (ddlCategory.SelectedItem.Text == "EBC" || ddlCategory.SelectedItem.Text == "SEBC" || ddlCategory.SelectedItem.Text == "EWS")
            {
                incomediv.Visible = true;
                castdiv.Visible = false;
            }
            else
            {
                incomediv.Visible = true;
                castdiv.Visible = true;
            }
            txtCertificateno.Text = string.Empty;
            txtCertificateno.Visible = true;


            ddlCast.Enabled = true;
            DataSet state_board_name = cls.fill_dataset("select  child from dbo.State_category_details where Main = 'Reserved Category' and parent = '" + ddlCategory.Text.ToString().Trim() + "'");
            ddlCast.DataSource = state_board_name.Tables[0];

            ddlCast.DataTextField = "child";
            ddlCast.DataBind();
            ddlCast.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlCast.Items.Insert(1, new ListItem("Others", "Others"));
        }
    }
    protected void txtEarning_TextChanged(object sender, EventArgs e)
    {
        if (txtEarning.Text != "")
        {
            try
            {
                     txtTotal.Text = Convert.ToString(Convert.ToInt16(txtEarning.Text));
                     if (txtNonEarning.Text != "")
                     {
                
                           txtTotal.Text = Convert.ToString(Convert.ToInt16(txtNonEarning.Text) + Convert.ToInt16(txtEarning.Text));
               
                     }
             }
            catch (Exception ex)
            {
                errorMessage.InnerText = "Please enter numeric values";
                errorMessage.Visible = true;
            }
        }
    }
    protected void txtNonEarning_TextChanged(object sender, EventArgs e)
    {
        if (txtNonEarning.Text != "")
        {
            try
            {
                txtTotal.Text = Convert.ToString(Convert.ToInt16(txtNonEarning.Text));
                if (txtEarning.Text != "")
                {                 
                    txtTotal.Text = Convert.ToString(Convert.ToInt16(txtNonEarning.Text) + Convert.ToInt16(txtEarning.Text));

                }
            }
            catch (Exception ex)
            {
                errorMessage.InnerText = "Please enter numeric values";
                errorMessage.Visible = true;
            }
        }
    }

    protected void ddmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddmonth.Text == "02" || ddmonth.Text == "04" || ddmonth.Text == "06" || ddmonth.Text == "09" || ddmonth.Text == "11")
        {
            if (ddmonth.Text == "Feb")
            {
                dddate.Items.Remove(dddate.Items.FindByText("31"));
                dddate.Items.Remove(dddate.Items.FindByText("30"));
            }
            else
            {
                dddate.Items.Remove(dddate.Items.FindByText("31"));
            }
        }
        else
        {
            ListItem itemne = dddate.Items.FindByText("30");
            if (itemne == null)
            {
                dddate.Items.Add(new ListItem("30"));
            }
            ListItem item = dddate.Items.FindByText("31");
            if (item == null)
            {
                dddate.Items.Add(new ListItem("31"));
            }
        }
    }

    protected void dincmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dincmonth.Text == "02" || dincmonth.Text == "04" || dincmonth.Text == "06" || dincmonth.Text == "09" || dincmonth.Text == "11")
        {
            if (dincmonth.Text == "Feb")
            {
                dincdate.Items.Remove(dincdate.Items.FindByText("31"));
                dincdate.Items.Remove(dincdate.Items.FindByText("30"));
            }
            else
            {
                dincdate.Items.Remove(dincdate.Items.FindByText("31"));
            }
        }
        else
        {
            ListItem itemne = dincdate.Items.FindByText("30");
            if (itemne == null)
            {
                dincdate.Items.Add(new ListItem("30"));
            }
            ListItem item = dincdate.Items.FindByText("31");
            if (item == null)
            {
                dincdate.Items.Add(new ListItem("31"));
            }
        }
    }

}