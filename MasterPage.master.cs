using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataSet dss;
    Class1 cls = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Formno"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }

            dss = cls.fill_dataset("select distinct F_name,L_name from d_adm_applicant where Form_no ='" + Session["Formno"].ToString() + "' and ACDID='" + Session["AYID"].ToString() + "'");
            if (dss.Tables[0].Rows.Count > 0)
            {
                lblfirstname.Text = dss.Tables[0].Rows[0]["F_name"].ToString().ToUpper() + " " + dss.Tables[0].Rows[0]["L_name"].ToString().ToUpper(); ;
               
            }
            else
            {
                dss = cls.fill_dataset("select distinct f_name,l_name from adm_applicant_registration where Formno ='" + Session["Formno"].ToString() + "' and ayid='" + Session["AYID"].ToString() + "'");
                lblfirstname.Text = dss.Tables[0].Rows[0]["f_name"].ToString().ToUpper() + " " + dss.Tables[0].Rows[0]["l_name"].ToString().ToUpper();
              
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
        }


        if (IsPostBack == false)
        {
            step1img.Visible = false;
            step2img.Visible = false;
            step3img.Visible = false;
            step4img.Visible = false;
            step5img.Visible = false;
            step6img.Visible = false;
            step7img.Visible = false;

            dss = check_flag();
            if (dss.Tables[0].Rows.Count > 0)
            {
                if (dss.Tables[0].Rows[0]["step1_flag"].ToString() == "True")
                {
                    //Image img1 = this.Master.FindControl("step1img") as Image;
                    //img1.Visible = true;
                    Session["step1_flag"] = dss.Tables[0].Rows[0]["step1_flag"].ToString();
                    step1img.Visible = true;

                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";
                }
                else
                {
                    Session["step1_flag"] = "False";
                    basic.Attributes["class"] = "btn btn-primary btn-circle";

                }
                if (dss.Tables[0].Rows[0]["step2_flag"].ToString() == "True")
                {
                    //Image img2 = this.Master.FindControl("step2img") as Image;
                    //img2.Visible = true;
                    Session["step2_flag"] = dss.Tables[0].Rows[0]["step2_flag"].ToString();
                    step2img.Visible = true;

                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";


                    personal.Attributes.Remove("disabled");
                    personal.Attributes["class"] = "btn btn-success btn-circle";
                }
                else
                {
                    Session["step2_flag"] = "False";
                    personal.Attributes["class"] = "btn btn-primary btn-circle";
                }
                if (dss.Tables[0].Rows[0]["step3_flag"].ToString() == "True")
                {
                    //Image img2 = this.Master.FindControl("step3img") as Image;
                    //img2.Visible = true;
                    Session["step3_flag"] = dss.Tables[0].Rows[0]["step3_flag"].ToString();
                    step3img.Visible = true;

                    personal.Attributes.Remove("disabled");
                    personal.Attributes["class"] = "btn btn-success btn-circle";


                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";

                    education.Attributes.Remove("disabled");
                    education.Attributes["class"] = "btn btn-success btn-circle";
                }
                else
                {
                    Session["step3_flag"] = "False";
                    education.Attributes["class"] = "btn btn-primary btn-circle";
                }
                if (dss.Tables[0].Rows[0]["step4_flag"].ToString() == "True")
                {
                    //Image img = this.Master.FindControl("step4img") as Image;
                    //img.Visible = true;
                    Session["step4_flag"] = dss.Tables[0].Rows[0]["step4_flag"].ToString();
                    step4img.Visible = true;

                    personal.Attributes.Remove("disabled");
                    personal.Attributes["class"] = "btn btn-success btn-circle";


                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";


                    education.Attributes.Remove("disabled");
                    education.Attributes["class"] = "btn btn-success btn-circle";

                    family.Attributes.Remove("disabled");
                    family.Attributes["class"] = "btn btn-success btn-circle";

                }
                else
                {
                    Session["step4_flag"] = "False";
                    family.Attributes["class"] = "btn btn-primary btn-circle";
                }
                if (dss.Tables[0].Rows[0]["step5_flag"].ToString() == "True")
                {
                    //Image img = this.Master.FindControl("step5img") as Image;
                    //img.Visible = true;
                    Session["step5_flag"] = dss.Tables[0].Rows[0]["step5_flag"].ToString();
                    step5img.Visible = true;

                    personal.Attributes.Remove("disabled");
                    personal.Attributes["class"] = "btn btn-success btn-circle";


                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";


                    education.Attributes.Remove("disabled");
                    education.Attributes["class"] = "btn btn-success btn-circle";


                    family.Attributes.Remove("disabled");
                    family.Attributes["class"] = "btn btn-success btn-circle";

                    other.Attributes.Remove("disabled");
                    other.Attributes["class"] = "btn btn-success btn-circle";
                }
                else
                {
                    Session["step5_flag"] = "False";
                    other.Attributes["class"] = "btn btn-primary btn-circle";
                }
                if (dss.Tables[0].Rows[0]["step6_flag"].ToString() == "True")
                {
                    //Image img = this.Master.FindControl("step6img") as Image;
                    //img.Visible = true;
                    Session["step6_flag"] = dss.Tables[0].Rows[0]["step6_flag"].ToString();
                    step6img.Visible = true;

                    personal.Attributes.Remove("disabled");
                    personal.Attributes["class"] = "btn btn-success btn-circle";


                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";


                    education.Attributes.Remove("disabled");
                    education.Attributes["class"] = "btn btn-success btn-circle";


                    family.Attributes.Remove("disabled");
                    family.Attributes["class"] = "btn btn-success btn-circle";


                    other.Attributes.Remove("disabled");
                    other.Attributes["class"] = "btn btn-success btn-circle";


                    images.Attributes.Remove("disabled");
                    images.Attributes["class"] = "btn btn-success btn-circle";
                }
                else
                {
                    Session["step6_flag"] = "False";
                    images.Attributes["class"] = "btn btn-primary btn-circle";
                }
                if (dss.Tables[0].Rows[0]["step7_flag"].ToString() == "True")
                {
                    //Image img = this.Master.FindControl("step7img") as Image;
                    //img.Visible = true;
                    Session["step7_flag"] = dss.Tables[0].Rows[0]["step7_flag"].ToString();
                    step7img.Visible = true;

                    personal.Attributes.Remove("disabled");
                    personal.Attributes["class"] = "btn btn-success btn-circle";


                    basic.Attributes.Remove("disabled");
                    basic.Attributes["class"] = "btn btn-success btn-circle";


                    education.Attributes.Remove("disabled");
                    education.Attributes["class"] = "btn btn-success btn-circle";


                    family.Attributes.Remove("disabled");
                    family.Attributes["class"] = "btn btn-success btn-circle";


                    other.Attributes.Remove("disabled");
                    other.Attributes["class"] = "btn btn-success btn-circle";


                    images.Attributes.Remove("disabled");
                    images.Attributes["class"] = "btn btn-success btn-circle";


                    apply.Attributes.Remove("disabled");
                    apply.Attributes["class"] = "btn btn-success btn-circle";
                }
                else
                {
                    Session["step7_flag"] = "False";
                    apply.Attributes["class"] = "btn btn-primary btn-circle";
                }
            }
            HighlightCurrentStep();

        }
        dss = check_flag();
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (dss.Tables[0].Rows[0]["step1_flag"].ToString() == "True")
            {
                //Image img1 = this.Master.FindControl("step1img") as Image;
                //img1.Visible = true;
                Session["step1_flag"] = dss.Tables[0].Rows[0]["step1_flag"].ToString();
                step1img.Visible = true;

                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";
            }
            else
            {
                Session["step1_flag"] = "False";
                basic.Attributes["class"] = "btn btn-primary btn-circle";
            }
            if (dss.Tables[0].Rows[0]["step2_flag"].ToString() == "True")
            {
                //Image img2 = this.Master.FindControl("step2img") as Image;
                //img2.Visible = true;
                Session["step2_flag"] = dss.Tables[0].Rows[0]["step2_flag"].ToString();
                step2img.Visible = true;

                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";


                personal.Attributes.Remove("disabled");
                personal.Attributes["class"] = "btn btn-success btn-circle";


            }
            else
            {
                Session["step2_flag"] = "False";
                personal.Attributes["class"] = "btn btn-primary btn-circle";
            }
            if (dss.Tables[0].Rows[0]["step3_flag"].ToString() == "True")
            {
                //Image img2 = this.Master.FindControl("step3img") as Image;
                //img2.Visible = true;
                Session["step3_flag"] = dss.Tables[0].Rows[0]["step3_flag"].ToString();
                step3img.Visible = true;



                personal.Attributes.Remove("disabled");
                personal.Attributes["class"] = "btn btn-success btn-circle";


                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";

                education.Attributes.Remove("disabled");
                education.Attributes["class"] = "btn btn-success btn-circle";



            }
            else
            {
                Session["step3_flag"] = "False";
                education.Attributes["class"] = "btn btn-primary btn-circle";
            }
            if (dss.Tables[0].Rows[0]["step4_flag"].ToString() == "True")
            {
                //Image img = this.Master.FindControl("step4img") as Image;
                //img.Visible = true;
                Session["step4_flag"] = dss.Tables[0].Rows[0]["step4_flag"].ToString();
                step4img.Visible = true;


                personal.Attributes.Remove("disabled");
                personal.Attributes["class"] = "btn btn-success btn-circle";


                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";


                education.Attributes.Remove("disabled");
                education.Attributes["class"] = "btn btn-success btn-circle";

                family.Attributes.Remove("disabled");
                family.Attributes["class"] = "btn btn-success btn-circle";




            }
            else
            {
                Session["step4_flag"] = "False";
                family.Attributes["class"] = "btn btn-primary btn-circle";
            }
            if (dss.Tables[0].Rows[0]["step5_flag"].ToString() == "True")
            {
                //Image img = this.Master.FindControl("step5img") as Image;
                //img.Visible = true;
                Session["step5_flag"] = dss.Tables[0].Rows[0]["step5_flag"].ToString();
                step5img.Visible = true;


                personal.Attributes.Remove("disabled");
                personal.Attributes["class"] = "btn btn-success btn-circle";


                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";


                education.Attributes.Remove("disabled");
                education.Attributes["class"] = "btn btn-success btn-circle";


                family.Attributes.Remove("disabled");
                family.Attributes["class"] = "btn btn-success btn-circle";

                other.Attributes.Remove("disabled");
                other.Attributes["class"] = "btn btn-success btn-circle";




            }
            else
            {
                Session["step5_flag"] = "False";
                other.Attributes["class"] = "btn btn-primary btn-circle";
            }
            if (dss.Tables[0].Rows[0]["step6_flag"].ToString() == "True")
            {
                //Image img = this.Master.FindControl("step6img") as Image;
                //img.Visible = true;
                Session["step6_flag"] = dss.Tables[0].Rows[0]["step6_flag"].ToString();
                step6img.Visible = true;

                personal.Attributes.Remove("disabled");
                personal.Attributes["class"] = "btn btn-success btn-circle";


                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";


                education.Attributes.Remove("disabled");
                education.Attributes["class"] = "btn btn-success btn-circle";


                family.Attributes.Remove("disabled");
                family.Attributes["class"] = "btn btn-success btn-circle";


                other.Attributes.Remove("disabled");
                other.Attributes["class"] = "btn btn-success btn-circle";


                images.Attributes.Remove("disabled");
                images.Attributes["class"] = "btn btn-success btn-circle";



            }
            else
            {
                Session["step6_flag"] = "False";
                images.Attributes["class"] = "btn btn-primary btn-circle";
            }
            if (dss.Tables[0].Rows[0]["step7_flag"].ToString() == "True")
            {
                //Image img = this.Master.FindControl("step7img") as Image;
                //img.Visible = true;
                Session["step7_flag"] = dss.Tables[0].Rows[0]["step7_flag"].ToString();
                step7img.Visible = true;



                personal.Attributes.Remove("disabled");
                personal.Attributes["class"] = "btn btn-success btn-circle";


                basic.Attributes.Remove("disabled");
                basic.Attributes["class"] = "btn btn-success btn-circle";


                education.Attributes.Remove("disabled");
                education.Attributes["class"] = "btn btn-success btn-circle";


                family.Attributes.Remove("disabled");
                family.Attributes["class"] = "btn btn-success btn-circle";


                other.Attributes.Remove("disabled");
                other.Attributes["class"] = "btn btn-success btn-circle";


                images.Attributes.Remove("disabled");
                images.Attributes["class"] = "btn btn-success btn-circle";


                apply.Attributes.Remove("disabled");
                apply.Attributes["class"] = "btn btn-success btn-circle";



            }
            else
            {
                Session["step7_flag"] = "False";
                apply.Attributes["class"] = "btn btn-primary btn-circle";
            }
        }
        HighlightCurrentStep();
    }

    private void HighlightCurrentStep()
    {
        string currentPage = System.IO.Path.GetFileNameWithoutExtension(Request.Url.AbsolutePath);

        Dictionary<string, HtmlControl> steps = new Dictionary<string, HtmlControl>
    {
        { "Basic_Detail", basic },
        { "Personal_Detail", personal },
        { "Education_Detail", education },
        { "Family_Detail", family },
        { "Other_Information", other },
        { "Document_upload", images },
        { "Apply_Course", apply }
    };

        Dictionary<string, string> stepFlags = new Dictionary<string, string>
    {
        { "Basic_Detail", Session["step1_flag"] as string },
        { "Personal_Detail", Session["step2_flag"] as string },
        { "Education_Detail", Session["step3_flag"] as string },
        { "Family_Detail", Session["step4_flag"] as string },
        { "Other_Information", Session["step5_flag"] as string },
        { "Document_upload", Session["step6_flag"] as string },
        { "Apply_Course", Session["step7_flag"] as string }
    };

        foreach (var step in steps)
        {
            if (step.Value != null)
            {
                // If this is the current page, make it red
                if (step.Key.Equals(currentPage, StringComparison.OrdinalIgnoreCase))
                {
                    step.Value.Attributes["class"] = "btn btn-primary btn-circle";
                }
                else
                {
                    // Check the flag status
                    string stepFlag = stepFlags.ContainsKey(step.Key) ? stepFlags[step.Key] : "False";

                    if (stepFlag == "True")
                    {
                        step.Value.Attributes["class"] = "btn btn-success btn-circle"; // Green if step completed
                    }
                    else if (step.Value.Attributes["disabled"] != null)
                    {
                        step.Value.Attributes["class"] = "btn btn-danger btn-circle"; // Grey if disabled
                    }
                    else
                    {
                        step.Value.Attributes["class"] = "btn btn-danger btn-circle"; // Blue if enabled but not completed
                    }
                }
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear session and redirect to login page
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }


    public DataSet check_flag()
    {
        try
        {
            if (Session["Formno"].ToString() != string.Empty || Session["Formno"].ToString() != "")
            {
                DataSet ds_flag = cls.fill_dataset("select step1_flag,step2_flag,step3_flag,step4_flag,step5_flag,step6_flag,step7_flag from d_adm_applicant where Form_no='" + Session["Formno"].ToString() + "' and acdid='" + Session["AYID"].ToString() + "'");
                if (ds_flag.Tables[0].Rows.Count > 1)
                {


                    return ds_flag;
                }
                else
                {

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
}
