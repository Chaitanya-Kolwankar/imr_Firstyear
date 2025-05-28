using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FY_Personal_Detail : System.Web.UI.Page
{

    Class1 cls = new Class1();
    DataSet ds = new DataSet();
    clsvalidate valid = new clsvalidate();



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ds = (DataSet)Session["stud_data"];
            if (!IsPostBack)
            {
                if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
                {
                    if (Session["submit"].ToString() == "True")
                    {
                        Response.Redirect("Apply_Course.aspx", false);

                    }
                    if (Session["step1_flag"] != null)
                    {
                        if (Session["step1_flag"].ToString() == "True")
                        {
                            if (Session["step2_flag"] != null)
                            {
                             if (Session["step2_flag"].ToString() == "True")
                             {
                                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    txtadddress1.Text = ds.Tables[0].Rows[0]["Address_line1"].ToString();
                                    txtadddress2.Text = ds.Tables[0].Rows[0]["Address_line2"].ToString();
                                    txtadddress3.Text = ds.Tables[0].Rows[0]["Address_line3"].ToString();
                                    txtCity.Text = ds.Tables[0].Rows[0]["city"].ToString(); ;
                                    txtdomicile.Text = ds.Tables[0].Rows[0]["Domicile"].ToString();
                                    txtpincode.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
                                    txtplaceofbirth.Text = ds.Tables[0].Rows[0]["birth_place"].ToString();
                                    ddbloodgroup.SelectedValue = ds.Tables[0].Rows[0]["blood_group"].ToString();
                                    ddlState.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
                                    ddReligion.SelectedValue = ds.Tables[0].Rows[0]["Religion"].ToString().Trim();
                                    if (ds.Tables[0].Rows[0]["Marital_status"].ToString() == "False")
                                    {
                                        ddmarried.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        ddmarried.SelectedIndex = 1;
                                    }
                                    // ddmarried.SelectedIndex = Convert.ToInt16(ds.Tables[0].Rows[0]["Marital_status"].ToString());
                                    if (ds.Tables[0].Rows[0]["Gender"].ToString() == "0")
                                    {
                                        rbtfemale.Checked = true;
                                    }
                                    else
                                    {
                                        rbtmale.Checked = true;
                                    }

                                    Session["ayid"] = valid.check_db_null(ds.Tables[0].Rows[0]["ayid"].ToString());
                                }
                            }
                        }
                            else
                            {

                            }
                        }
                        else
                        {
                            Response.Redirect("Basic_Detail.aspx");
                        }
                    }


                }
               
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
        }
        
    }
    public void ErrorMessageDisplay(string ex)
    {
        errorMessage.InnerHtml = "<strong>ERROR!</strong> " + ex;
        errorMessage.Visible = true;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int gender, marital_status;
        if (rbtfemale.Checked == true)
        {
            gender = 0;
        }
        else
        {
            gender = 1;

        }

        // string address = txtadddress.Text + " "+"State:" + ddlState.Text.Trim() + ",Pincode:" + txtpincode.Text.Trim();

        if (ddmarried.SelectedIndex == 0)
        {
            marital_status = 0;
        }
        else
        { 
            marital_status = 1;
        }

        string bloodgrp;
        if (ddbloodgroup.SelectedIndex == 0)
        {
            bloodgrp = "NULL";
        }
        else
        {
            bloodgrp = ddbloodgroup.SelectedItem.Text.Trim();
            // Session["branch"] = ddbloodgroup.Text.ToString().Trim();
        }

        bool exitFlag = false;

        if (ddReligion.SelectedIndex == 0)
        {
            ErrorMessageDisplay("Please select Region");
            return;
        }

        if (exitFlag == false)
        {
            //this.imgquestion.Attributes.Add("onclick", "javascript:return Opencaste()");
            string updt_query = "update d_adm_applicant set gender=" + gender + ",blood_group='" + bloodgrp + "',birth_place='" + valid.replacequote(txtplaceofbirth.Text.Trim().ToUpper()) + "',Domicile='" + valid.replacequote(txtdomicile.Text.Trim().ToUpper()) + "',Marital_status=" + marital_status + ",Address_line1='" + valid.replacequote(txtadddress1.Text.Trim().ToUpper()) + "', Address_line2='" + valid.replacequote(txtadddress2.Text.Trim().ToUpper()) + "', Address_line3='" + valid.replacequote(txtadddress3.Text.Trim().ToUpper()) + "', city='" + valid.replacequote(txtCity.Text.Trim().ToUpper()) + "', pincode='" + valid.replacequote(txtpincode.Text.Trim().ToUpper()) + "', state='" + valid.replacequote(ddlState.Text.Trim().ToUpper()) + "',Religion='" + valid.replacequote(ddReligion.Text.Trim().ToUpper()) + "',step2_flag=1,step2_dt=getdate() where Form_no='" + Session["Formno"].ToString() + "' and Del_Flag=0 and  ACDID='" + Session["ayid"].ToString() + "'";

            ds.Tables[0].Rows[0]["gender"] = gender;
            ds.Tables[0].Rows[0]["blood_group"] = bloodgrp;
            ds.Tables[0].Rows[0]["birth_place"] = txtplaceofbirth.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Domicile"] = txtdomicile.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Marital_status"] = marital_status;
            ds.Tables[0].Rows[0]["Address_line1"] = txtadddress1.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Address_line2"] = txtadddress2.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Address_line3"] = txtadddress3.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["city"] = txtCity.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["pincode"] = txtpincode.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["state"] = ddlState.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Religion"] = ddReligion.Text.Trim().ToUpper();

            if (cls.bulk_insert_for_applicant(updt_query, "update").ToString() == "TRANSACTION SUCCESSFUL")
            {
                Session["step2_flag"] = true;
                Response.Redirect("Education_Detail.aspx");

            }

     
        
        }
    }
}