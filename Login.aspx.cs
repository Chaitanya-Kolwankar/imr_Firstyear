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

public partial class Login : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataSet dss = new DataSet();
    DataSet dss_submit = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string url = Convert.ToString(HttpContext.Current.Request.Url);
                string[] ss1 = url.Split('/');
                if (ss1[2].ToString().StartsWith("103"))
                {
                    Response.Redirect("http://imr.vivacollege.in/imr_fy/login.aspx");
                }
                errorMessage.Visible = false;
                btnLogin.Attributes.Add("onclick", "return validate()");
                //if (Session["Formno"].ToString() != "" || Session["Formno"] == null)
                //{
                //    string sss = Session["Formno"].ToString();
                //    Response.Redirect("Basic_Detail.aspx", false);
                //}

                string previousPage = Request.QueryString["PreviousPage"];

                if (string.IsNullOrEmpty(previousPage))
                {
                    DataSet ds = cls.fill_dataset("select max(ayid) as 'ayid' from dbo.m_academic");
                    Session["AYID"] = ds.Tables[0].Rows[0]["ayid"].ToString();
                }
                else if (previousPage.Contains("Register.aspx") == true)
                {
                    string msg = "Please Check your Email ID and Mobile Number for the received User ID and Password";
                    string alrt = "alert('" + msg + "'" + ");";
                    ClientScript.RegisterStartupScript(this.GetType(), "", alrt, true);

                }
            }
            catch (Exception ex)
            {
                Session["Formno"] = "";
            }
        }
    }

    public void ErrorMessageDisplay(string ex)
    {
        errorMessage.InnerHtml = "<strong>INVALID!</strong> " + ex;
        errorMessage.Visible = true;
    }

    public bool ValidateData()
    {
        if (txtUserid.Value.ToString() != "" && txtUserid.Value.ToString().Equals(string.Empty))
        {
            ErrorMessageDisplay("INCORRECT USER ID");
            return false;
        }
        if (txtPasswd.Value.ToString() != "" && txtPasswd.Value.ToString().Equals(string.Empty))
        {
            ErrorMessageDisplay("INCORRECT PASSWORD");
            return false;
        }
        return true;
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
           
            if (txtUserid.Value.ToString() == string.Empty && txtPasswd.Value.ToString() == string.Empty)
            {
                ErrorMessageDisplay("Enter Student ID and Password");
                txtUserid.Focus();
            }
            else if (txtUserid.Value.Trim().ToString() == string.Empty || txtPasswd.Value.ToString() == string.Empty)
            {
                if (txtUserid.Value.Trim().ToString() == string.Empty)
                {
                    ErrorMessageDisplay("Enter Student ID");
                    txtUserid.Focus();
                }
                if (txtPasswd.Value.Trim().ToString() == string.Empty)
                {
                    //lbl_msg.Text = "Enter Password";
                    ErrorMessageDisplay("Enter Password");
                    txtPasswd.Focus();
                }
            }
            else
            {
                //fun_login();
                //string sBaseUrl = "http://183.87.70.10/Sytyapi/outLogin/" + txtUserid.Value.ToString() + "/" + txtPasswd.Value.ToString();
                ////string sBaseUrl = "http://localhost:55265/outLogin/" + txtUserid.Value.ToString() + "/" + txtPasswd.Value.ToString();
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sBaseUrl);
                //request.Method = "GET";
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //String stringsize = response.ContentLength.ToString();
                //StreamReader reader = new StreamReader(response.GetResponseStream());

                DataSet stud_ds = cls.outlogin(txtUserid.Value.ToString(), txtPasswd.Value.ToString());

                if (stud_ds.Tables.Count>0)
                {                   
                    string name = "";                   
                    Session["stud_data"] = stud_ds;
                    Session["applicant_type"] = stud_ds.Tables[0].Rows[0]["applicant_type"].ToString();
                    Session["Formno"] = txtUserid.Value.ToString().Trim();
                    Session["password"] = txtPasswd.Value.ToString().Trim();

                    if (stud_ds.Tables[0].Rows[0]["is_submited"].ToString() == "Yes")
                    {
                        Session["submit"] = "True";
                        Session["step1_flag"] = true;
                        Response.Redirect("Apply_Course.aspx", false);
                    }
                    else
                    {
                        Session["submit"] = "False";
                        Session["step1_flag"] = false;
                        Response.Redirect("Basic_Detail.aspx", false);
                    }
                    // Response.Redirect("Basic_Detail.aspx", false);
                }
                else
                {
                    String msg = stud_ds.Tables[0].Rows[0][0].ToString();
                    Session["UserName"] = "";
                    txtUserid.Focus();
                    ErrorMessageDisplay(msg);

                }

                //if (Convert.ToInt32(stringsize) > 77)
                //{
                //    JObject results = JObject.Parse(reader.ReadToEnd());
                //    string name = "";
                //    DataSet stud_ds = new DataSet();
                //    stud_ds.Tables.Add(JsonConvert.DeserializeObject<DataTable>(results["Table"].ToString()));               

                //    Session["stud_data"] = stud_ds;
                //    Session["applicant_type"] = stud_ds.Tables[0].Rows[0]["applicant_type"].ToString();
                //    Session["Formno"] = txtUserid.Value.ToString().Trim();
                //    Session["password"] = txtPasswd.Value.ToString().Trim();

                //    if (stud_ds.Tables[0].Rows[0]["is_submited"].ToString() == "Yes")
                //    {
                //        Session["submit"] = "True";
                //        Session["step1_flag"] = true;
                //        Response.Redirect("Apply_Course.aspx", false);
                //    }
                //    else
                //    {
                //        Session["submit"] = "False";
                //        Session["step1_flag"] = false;
                //        Response.Redirect("Basic_Detail.aspx", false);
                //    }
                //   // Response.Redirect("Basic_Detail.aspx", false);
                //}
                //else
                //{
                //    String msg = reader.ReadToEnd();
                //    Session["UserName"] = "";
                //    txtUserid.Focus();
                //    ErrorMessageDisplay(msg);

                //}
            }
        }
        catch (Exception ex)
        {
            //string msg = "Error Code: 100 Login";
            //Response.Redirect("ErrorPage.aspx?x=" + msg + "", true);
        }

       
    }
}