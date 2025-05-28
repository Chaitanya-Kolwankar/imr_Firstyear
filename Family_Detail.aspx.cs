using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FY_Family_Detail : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataSet ds = new DataSet();
    clsvalidate valid = new clsvalidate();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            errorMessage.Visible = false;
            ds = (DataSet)Session["stud_data"];
            if (!IsPostBack)
            {

                if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
                {
                    if (Session["submit"].ToString() == "True")
                    {
                        Response.Redirect("Apply_Course.aspx", false);

                    }
                    if (Session["step3_flag"] != null)
                    {
                        if (Session["step3_flag"].ToString() == "True")
                        {
                            if (Session["step4_flag"].ToString() == "True")
                            {
                                txtFather_Name.Text = ds.Tables[0].Rows[0]["M_name"].ToString();
                                txtfatheraddress.Text = ds.Tables[0].Rows[0]["Father_Busi_addr"].ToString();
                                txtfatherage.Text = ds.Tables[0].Rows[0]["Father_age"].ToString();
                                txtfathercontact.Text = ds.Tables[0].Rows[0]["Father_contact_No"].ToString();
                                txtfatherdesignation.Text = ds.Tables[0].Rows[0]["Father_desg"].ToString();
                                txtfatheremail.Text = ds.Tables[0].Rows[0]["Father_emailID"].ToString();
                                txtfatheroccupation.SelectedItem.Text = ds.Tables[0].Rows[0]["Father_Occup"].ToString();
                                txtfatherqualification.Text = ds.Tables[0].Rows[0]["Father_Qualification"].ToString();
                                txtmotheraddress.Text = ds.Tables[0].Rows[0]["Mother_Busi_addr"].ToString();
                                txtmotherage.Text = ds.Tables[0].Rows[0]["Mother_age"].ToString();
                                txtmothercontactno.Text = ds.Tables[0].Rows[0]["Mother_contact_No"].ToString();
                                txtmotherdesignation.Text = ds.Tables[0].Rows[0]["Mother_desg"].ToString();
                                txtmotheremail_id.Text = ds.Tables[0].Rows[0]["Mother_emailID"].ToString();
                                txtmothername.Text = ds.Tables[0].Rows[0]["Mo_name"].ToString();
                                txtmotheroccupation.SelectedItem.Text = ds.Tables[0].Rows[0]["Mother_Occup"].ToString();
                                txtmotherqualification.Text = ds.Tables[0].Rows[0]["Mother_Qualification"].ToString();
                            }
                            else
                            {
                                if (Session["FatherName"] != null)
                                {
                                    txtFather_Name.Text = Session["FatherName"].ToString();
                                }
                                if (Session["MotherName"] != null)
                                {
                                    txtmothername.Text = Session["MotherName"].ToString();
                                }
                                else
                                {
                                    txtmothername.Text = "";
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Education_Detail.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("Education_Detail.aspx");
                    }


                }

             
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Validate_Data())
        {
            int fage=0, mage=0;
            if (txtfatherage.Text == string.Empty)
            {
                fage = 0;
            }
            else
            {
                try
                {
                    fage = Convert.ToInt32(txtfatherage.Text);
                }
                catch (Exception ex)
                {
                    errorMessage.InnerText = "Please enter numeric values";
                }
            }
            if (txtmotherage.Text == string.Empty)
            {
                mage = 0;
            }
            else
            {
                try
                {
                    mage = Convert.ToInt32(txtmotherage.Text);
                }
                catch (Exception ex)
                {
                    errorMessage.InnerText = "Please enter numeric values";
                }
            }
            string updt_query = "UPDATE d_adm_applicant SET M_name='" + valid.replacequote(txtFather_Name.Text.Trim().ToUpper()) + "',Father_age=" + fage + ",Father_emailID='" + valid.replacequote(txtfatheremail.Text.Trim().ToLower()) + "',Father_contact_No='" + txtfathercontact.Text.Trim().ToUpper() + "',Father_Qualification='" + valid.replacequote(txtfatherqualification.Text.Trim().ToUpper()) + "',Father_Occup='" + valid.replacequote(txtfatheroccupation.Text.Trim().ToUpper()) + "',Father_desg='" + valid.replacequote(txtfatherdesignation.Text.Trim().ToUpper()) + "',Father_Busi_addr='" + valid.replacequote(txtfatheraddress.Text.Trim().ToUpper()) + "',Mother_age=" + mage + ",Mother_emailID='" + txtmotheremail_id.Text.Trim().ToLower() + "',Mother_contact_No='" + txtmothercontactno.Text.Trim().ToUpper() + "',Mother_Qualification='" + valid.replacequote(txtmotherqualification.Text.Trim().ToUpper()) + "',Mother_Occup='" + valid.replacequote(txtmotheroccupation.Text.Trim().ToUpper()) + "',Mother_desg='" + valid.replacequote(txtmotherdesignation.Text.Trim().ToUpper()) + "',Mother_Busi_addr='" + valid.replacequote(txtmotheraddress.Text.Trim().ToUpper()) + "',step4_flag=1,step4_dt=getdate() where Form_no='" + Session["Formno"].ToString() + "' and Del_Flag=0 and acdid='" + Session["AYID"].ToString() + "'";

            ds.Tables[0].Rows[0]["M_name"] = txtFather_Name.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Father_age"] = fage;
            ds.Tables[0].Rows[0]["Father_emailID"] = txtfatheremail.Text.Trim();
            ds.Tables[0].Rows[0]["Father_contact_No"] = txtfathercontact.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Father_Qualification"] = txtfatherqualification.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Father_Occup"] = txtfatheroccupation.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Father_desg"] = txtfatherdesignation.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Father_Busi_addr"] = txtfatheraddress.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_age"] = mage;
            ds.Tables[0].Rows[0]["Mother_emailID"] = txtmotheremail_id.Text.Trim();
            ds.Tables[0].Rows[0]["Mother_contact_No"] = txtmothercontactno.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_Qualification"] = txtmotherqualification.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_Occup"] = txtmotheroccupation.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_desg"] = txtmotherdesignation.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_Busi_addr"] = txtmotheraddress.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_emailID"] = txtmotheremail_id.Text.Trim();
            ds.Tables[0].Rows[0]["Mother_contact_No"] = txtmothercontactno.Text.Trim().ToUpper();
            ds.Tables[0].Rows[0]["Mother_Qualification"] = txtmotherqualification.Text.Trim().ToUpper();

           
            if (cls.bulk_insert_for_applicant(updt_query, "update").ToString() == "TRANSACTION SUCCESSFUL")
            {
                Session["step4_flag"] = true;
                Response.Redirect("Other_Information.aspx");
            }

        }
    }

    public bool Validate_Data()
    {

        if (txtFather_Name.Text == "" || txtfatheraddress.Text == "" || txtfathercontact.Text == "" || txtfatherdesignation.Text == "" || txtfatheremail.Text == "" || txtfatheroccupation.Text == "" || txtfatherqualification.Text == "" || txtmotheraddress.Text == "" ||  txtmothercontactno.Text == "" || txtmotherdesignation.Text == "" || txtmotheremail_id.Text == "" || txtmothername.Text == "" || txtmotheroccupation.Text == "" || txtmotherqualification.Text == "")
        {
            if (txtFather_Name.Text == "")
            {
                ErrorMessageDisplay("Enter Father Name");
                return false;
            }

            else
            {
                if (txtfathercontact.Text == "")
                {

                    ErrorMessageDisplay("Enter Father's Contact No.");
                    return false;
                }

                else
                {
                    if (txtfatheroccupation.Text == "")
                    {
                        ErrorMessageDisplay("Enter Father's Occupation");
                        return false;
                    }

                    else
                    {
                        if (txtmothercontactno.Text == "")
                        {
                            ErrorMessageDisplay("Enter Mother's Contact No.");
                            return false;
                        }

                        else
                        {
                            if (txtmothername.Text == "")
                            {
                                ErrorMessageDisplay("Enter Mother's Name");
                                return false;
                            }
                            else
                            {
                                if (txtmotheroccupation.Text == "")
                                {
                                    ErrorMessageDisplay("Enter Mother's Occupation");
                                    return false;
                                }

                            }
                        }

                    }

                }

            }

        }
        else
        {
            if (valid.CheckName(txtFather_Name.Text) != true)
            {
                ErrorMessageDisplay("Enter Correct Father's Name");
                return false;
            }
            else
            {
                
                    if (valid.CheckName(txtmothername.Text) != true)
                    {
                        ErrorMessageDisplay("Enter Correct Mother's Name");
                        return false;
                    }
                   
                
            }

        }
        return true;

    }
    public void ErrorMessageDisplay(string ex)
    {
        errorMessage.Visible = true;
        errorMessage.InnerText = ex;
        //string csError = "PopupError";
        //Type cstype = this.GetType();
        //ClientScriptManager cs = Page.ClientScript;
        //if (!cs.IsStartupScriptRegistered(cstype, csError))
        //{
        //    String cstext1 = "alert('" + ex + "'" + ");";
        //    cs.RegisterStartupScript(cstype, csError, cstext1, true);
        //}
    }
}