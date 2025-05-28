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


public partial class Register : System.Web.UI.Page
{
    Class1 cls = new Class1();
    clsvalidate valid = new clsvalidate();
    DataTable dt=new DataTable();
    sy_model mod = new sy_model();
    DataSet ds = new DataSet();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Convert.ToString(HttpContext.Current.Request.Url);
        string[] ss1 = url.Split('/');
        if (ss1[2].ToString().StartsWith("103"))
        {
            Response.Redirect("http://imr.vivacollege.in/imr_fy/Register.aspx");
        }
        if (!IsPostBack)
        {
           // disable();
            try
            {
               ddl_applicant_type.SelectedIndex = 1;
               ddl_applicant_type.Enabled = false;
                errorMessage.Visible = false;
                btnsubmit.Attributes.Add("onclick", "return validate()");
                lbl_captcha.Text = generateString();
             

                for (int i = 2020; i >= 1990; i--)
                {
                    string s = i.ToString();
                    //dd12passyear.Items.Add(s);
                }

                DataSet ds = cls.fill_dataset("select max(ayid) as 'ayid' from dbo.m_academic");
                Session["AYID"] = ds.Tables[0].Rows[0]["ayid"].ToString();

                //if (Session["Formno"].ToString() != "" || Session["Formno"] == null)
                //{
                //    string sss = Session["Formno"].ToString();
                //    Response.Redirect("Basic_Detail.aspx", false);
                //}             

            }
            catch (Exception ex)
            {
                Session["Formno"] = "";
                Response.Redirect("Register.aspx");
            }
        }
        
        dt.Columns.Add("f_name");
        dt.Columns.Add("m_name");
        dt.Columns.Add("l_name");
        dt.Columns.Add("mo_name");
        dt.Columns.Add("dob");
        dt.Columns.Add("mob_no");
        dt.Columns.Add("prefaculty");
        dt.Columns.Add("subcourse_name");
        dt.Columns.Add("group_id");
        dt.Columns.Add("passwd");
        dt.Columns.Add("Out_of");
        dt.Columns.Add("Marks_obtained");
        dt.Columns.Add("Percentage");
        dt.Columns.Add("ayid");
        dt.Columns.Add("email_id");
        dt.Columns.Add("seat_no");
        dt.Columns.Add("pass_month");
        dt.Columns.Add("pass_year");
        dt.Columns.Add("is_diploma");
        dt.Columns.Add("SEM_1");
        dt.Columns.Add("SEM_2");
        dt.Columns.Add("SEM_3");
        dt.Columns.Add("SEM_4");
        dt.Columns.Add("applicant_type");
     
    }
    

    
    public static string generateString()
    {   
        int Lenght = 6;
        int NonAlphaNumericChars = 1;
        string allowedChars = "abcdefghijkmnopqrstuvwxyz0123";
        string allowedNonAlphaNum = "abcdef";
        Random rd = new Random();

        if (NonAlphaNumericChars > Lenght || Lenght <= 0 || NonAlphaNumericChars < 0)
            throw new ArgumentOutOfRangeException();

        char[] pass = new char[Lenght];
        int[] pos = new int[Lenght];
        int i = 0, j = 0, temp = 0;
        bool flag = false;

        //Random the position values of the pos array for the string Pass
        while (i < Lenght - 1)
        {
            j = 0;
            flag = false;
            temp = rd.Next(0, Lenght);
            for (j = 0; j < Lenght; j++)
                if (temp == pos[j])
                {
                    flag = true;
                    j = Lenght;
                }

            if (!flag)
            {
                pos[i] = temp;
                i++;
            }
        }

        //Random the AlphaNumericChars
        for (i = 0; i < Lenght - NonAlphaNumericChars; i++)
            pass[i] = allowedChars[rd.Next(0, allowedChars.Length)];

        //Random the NonAlphaNumericChars
        for (i = Lenght - NonAlphaNumericChars; i < Lenght; i++)
            pass[i] = allowedNonAlphaNum[rd.Next(0, allowedNonAlphaNum.Length)];

        //Set the sorted array values by the pos array for the rigth posistion
        char[] sorted = new char[Lenght];
        for (i = 0; i < Lenght; i++)
            sorted[i] = pass[pos[i]];

        string Pass = new String(sorted);

        return Pass;


    }

    public bool CheckEmail(string s)
    {
        Regex reg = new Regex("^([0-9a-zA-Z]+[-._])*[0-9a-zA-Z]+@([0-9a-zA-Z]+[.])+[a-zA-Z]{2,3}$");
        return reg.IsMatch(s);
    }

    public bool Valid_data()
    {
        try
        {
            //if (ddl_applicant_type.SelectedIndex == 1)
            //{
            //    mod.applicant_type = "FY";
            //}
            //else
                if (ddl_applicant_type.SelectedValue == "02")
            {
                mod.applicant_type = "SY";
            }
            else if (ddl_applicant_type.SelectedValue == "03")
            {
                mod.applicant_type = "TY";
            }
            //else if (ddl_applicant_type.SelectedIndex == 4)
            //{
            //    mod.applicant_type = "FYPG";
            //}
            //else if (ddl_applicant_type.SelectedIndex == 5)
            //{
            //    mod.applicant_type = "SYPG";
            //}

            //if (ddl_applicant_type.SelectedIndex == 1 || ddl_applicant_type.SelectedIndex == 4 || ddl_applicant_type.SelectedIndex == 5)
            //{
            //    if (txtSeatNo.Value.ToString() != "")
            //    {
            //        mod.seat_no = txtSeatNo.Value.ToString();
            //        DataSet dss1 = cls.fill_dataset("select seat_no from adm_applicant_registration where seat_no='" + valid.replacequote(txtSeatNo.Value) + "' and ayid='" + Session["AYID"].ToString() + "'");
            //        if (dss1.Tables.Count > 0 && dss1.Tables[0].Rows.Count > 0)
            //        {
            //            txtSeatNo.Value = "";

            //            ErrorMessageDisplay("Seat Number is already registered with us enter Seat Number");
            //            return false;
            //        }
            //        else
            //        {
            //            txtSeatNo.Value = txtSeatNo.Value.ToLower();
            //            errorMessage.InnerText = "";
            //            errorMessage.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        ErrorMessageDisplay("Please enter seat no.");
            //        return false;
            //    }

            //    if (dd12passmonth.SelectedIndex > 0)
            //    {
            //        mod.pass_month = dd12passmonth.Text;
            //    }
            //    else
            //    {
            //        ErrorMessageDisplay("Please enter seat no.");
            //        return false;
            //    }

            //    if (dd12passyear.SelectedIndex > 0)
            //    {
            //        mod.pass_year = dd12passyear.Text;
            //    }
            //    else
            //    {
            //        ErrorMessageDisplay("Please enter seat no.");
            //        return false;
            //    }

            //    mod.is_diploma = "";
            //    mod.prefaculty = "";
            //    mod.subcourse_name = "";
            //    mod.group_id = "";
            //    mod.Percentage = "";
            //    mod.Out_of = "";
            //    mod.Marks_obtained ="";
            //    mod.is_diploma="";
            //    mod.SEM_1 = "";
            //    mod.SEM_2 = "";
            //    mod.SEM_3 = "";
            //    mod.SEM_4 = "";
            //    mod.Out_of = "";
            //    mod.Marks_obtained = "";
            //}
            //else
                if (ddl_applicant_type.SelectedValue == "02" || ddl_applicant_type.SelectedValue == "03")
            {
                mod.seat_no = "";
                mod.pass_month = "";
                mod.pass_year = "";
                mod.Out_of = "";
                mod.Marks_obtained = "";

                //if (rdbYes.Checked)
                //{
                //    mod.is_diploma = "Yes";
                //}
                //else
                //{
                //    mod.is_diploma = "No";
                //}

                //if (cmbPrefaculty.SelectedIndex > 0)
                //{
                //    mod.prefaculty = cmbPrefaculty.SelectedValue.ToString();
                //}
                //else
                //{
                //    ErrorMessageDisplay("Please select prefaculty");
                //    return false;
                //}
                //if (cmbSubcourseName.SelectedIndex > 0)
                //{
                //    mod.subcourse_name = cmbSubcourseName.SelectedValue.ToString();
                //}
                //else
                //{
                //    ErrorMessageDisplay("Please select subcourse");
                //    return false;
                //}
                //if (cmbGroupname.SelectedIndex > 0)
                //{
                //    mod.group_id = cmbGroupname.SelectedValue.ToString();
                //}
                //else
                //{
                //    ErrorMessageDisplay("Please select group name.");
                //    return false;
                //}             
            
                //if (txtPercentage.Text != "")
                //{
                //    mod.Percentage = txtPercentage.Text; ;
                //}
                //else
                //{
                //    mod.Percentage = "";
                //}
                //if (txtCredit1.Text != "")
                //{
                //    mod.SEM_1 = txtCredit1.Text;
                //}
                //else
                //{
                //    if (txtCredit1.Visible == true)
                //    {
                //        ErrorMessageDisplay("Please Enter Credit of SEM-1");
                //        return false;
                //    }
                //    else
                //    {
                //        mod.SEM_1 = "";
                //    }
                //}
                //if (txtCredit2.Text != "")
                //{
                //    mod.SEM_2 = txtCredit2.Text;
                //}
                //else
                //{
                //    if (txtCredit2.Visible == true)
                //    {
                //        ErrorMessageDisplay("Please Enter Credit of SEM-2");
                //        return false;
                //    }
                //    else
                //    {
                //        mod.SEM_2 = "";
                //    }
                //}
                //if (txtCredit3.Text != "")
                //{
                //    mod.SEM_3 = txtCredit3.Text;
                //}
                //else
                //{
                //    if (txtCredit3.Visible == true)
                //    {
                //        ErrorMessageDisplay("Please Enter Credit of SEM-3");
                //        return false;
                //    }
                //    else
                //    {
                //        mod.SEM_3 = "";
                //    }
                //}
                //if (txtCredit4.Text != "")
                //{
                //    mod.SEM_4 = txtCredit4.Text;
                //}
                //else
                //{
                //    if (txtCredit4.Visible == true)
                //    {
                //        ErrorMessageDisplay("Please Enter Credit of SEM-4");
                //        return false;
                //    }
                //    else
                //    {
                //        mod.SEM_4 = "";
                //    }
                //}
            }
            else
            {
                ErrorMessageDisplay("Please select option.");
                return false;
            }

            DataSet dss = cls.fill_dataset("select email_id  from adm_applicant_registration where email_id='" + valid.replacequote(txtEmailID.Value.ToString()) + "' and ayid='" + Session["AYID"].ToString() + "'");
            if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                txtEmailID.Value = "";
                ErrorMessageDisplay("Email ID is already registered with us enter another ID");
                return false;
            }
            else
            {
                txtEmailID.Value = txtEmailID.Value.ToLower();
            }

            

            if (!txt_code.Value.Equals(lbl_captcha.Text))
            {
                txt_code.Value = "";
                txt_code.Focus();
                ErrorMessageDisplay("Please Enter Exact Security Code");
                return false;
            }
            if (!txtPasswd.Text.Equals(txtVerifyPass.Text))
            {
                txt_code.Value = "";
                txt_code.Focus();
                ErrorMessageDisplay("Please Enter Same Password In Both Fields");
                return false;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
        }
        return true;
    }

    public void ErrorMessageDisplay(string ex)
    {
        errorMessage.InnerHtml = "<strong>ERROR!</strong> " + ex;
        errorMessage.Visible = true;
    }

    protected void txtVerifyPass_TextChanged(object sender, EventArgs e)
    {
        
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
           // btnsubmit.Enabled = false;
            if (Valid_data())
            {
                if (valid.CheckEmail(txtEmailID.Value) != true)
                {
                    ErrorMessageDisplay("Enter Proper Email ID");
                    return;
                }

                mod.f_name = txtFname.Value;
                mod.m_name = txtMname.Value;
                mod.l_name = txtSurname.Value;
                mod.mo_name = txtMoName.Value;
                mod.mob_no = txtMobNo.Value;
                mod.passwd = txtPasswd.Text.Trim();
                mod.ayid = Session["AYID"].ToString();
                mod.email_id = txtEmailID.Value;
                if (ddl_applicant_type.SelectedIndex == 1)
                { mod.applicant_type = "FY"; }
                else if (ddl_applicant_type.SelectedIndex == 2)
                { mod.applicant_type = "SY"; }
                //string month = Convert.ToDateTime(datetimepicker1.Text.ToString()).Month.ToString();
                //string day =  Convert.ToDateTime(datetimepicker1.Text.ToString()).Day.ToString();
                //string year =  Convert.ToDateTime(datetimepicker1.Text.ToString()).Year.ToString();

                //string DOB = ddday.Text.ToString() + '-' + ddmonth.Text.ToString() + '-' + ddyear.Text.ToString();
                string DOB = ddday.Text.ToString() + '-' + ddmonth.SelectedItem.Text.ToString() + '-' + ddyear.Text.ToString();


                //string DOB = month + "/" + day + "/" + year + " 12:00:00 AM";
                mod.dob = DOB;
                //mod.dob = ddday.Text.ToString() + '-' + ddmonth.Text.ToString() + '-' + ddyear.Text.ToString();
                //mod.pass_year = dd12passyear.Text.ToString();
                //mod.pass_month = dd12passmonth.Text.ToString();

                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(mod);
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.0.201/Sytyapi/registration/");
                //httpWebRequest.ContentType = "text/json";
                //httpWebRequest.Method = "POST";

                //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                //{
                //    streamWriter.Write(json);
                //    streamWriter.Flush();
                //    streamWriter.Close();
                //}

                //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    var result = streamReader.ReadToEnd();

                //  //  String chk_q = result;
                //    result = result.Replace("\"", "");
                //    if (result == "fail")
                //    {
                //        errorMessage.InnerText = "Error Occured";
                //        errorMessage.Visible = true;
                //    }
                //    else if (result != "")
                //    {
                //        Session["Formno"] = result;
                //        Session["passwd"] = txtPasswd.Text;

                //        errorMessage.InnerText = "Your user id is: " + Session["Formno"].ToString() + " and password is: " + Session["Passwd"].ToString() + "";
                //        sendemail();
                //        sendmessage();
                //        clear();
                //        errorMessage.Visible = true;
                //        Session.Clear();
                //        Session.Abandon();
                //    }
                //}

                //string result = cls.ins_register(mod.f_name, mod.m_name, mod.l_name, mod.mo_name, null, null, null, mod.mob_no, mod.dob, mod.passwd,0 ,0 , null, mod.ayid, mod.email_id, null, null, null, null, null, null, null, null, ddl_applicant_type.SelectedIndex);

                DataSet dss = cls.fill_dataset("select email_id from d_adm_applicant where email_id='" + valid.replacequote(txtEmailID.Value) + "' and ACDID='" + Session["AYID"].ToString() + "'");
                DataSet dss_phone = cls.fill_dataset("select mob_no from d_adm_applicant where mob_no='" + valid.replacequote(txtMobNo.Value) + "' and ACDID='" + Session["AYID"].ToString() + "'");

                if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    txtEmailID.Value = "";

                    ErrorMessageDisplay("Email ID is already registered with us enter another ID");
                }
                else if (dss_phone.Tables.Count > 0 && dss_phone.Tables[0].Rows.Count > 0)
                {
                    txtMobNo.Value = "";

                    ErrorMessageDisplay("Mobile Number is already registered with us enter another Number");
                }
                else
                {
                    string result = cls.insrt_registar(mod);
                    if (result == "fail")
                    {
                        //btnsubmit.Enabled = true;
                        errorMessage.InnerText = "Error Occured";
                        errorMessage.Visible = true;
                    }
                    else if (result != "")
                    {
                        Session["Formno"] = result;
                        Session["passwd"] = txtPasswd.Text;

                        errorMessage.InnerText = "Your user id is: " + Session["Formno"].ToString() + " and password is: " + Session["Passwd"].ToString() + "";
                        sendemail();
                        sendmessage();
                       // btnsubmit.Enabled = true;
                        clear();
                        errorMessage.Visible = true;
                        Session.Clear();
                        Session.Abandon();

                    }
                }
            }
        }
        catch(Exception ex1)
        {
            //btnsubmit.Enabled = true; 
        }
        
    }

    public bool sendemail()
    {
        try
        {
            SmtpClient client = new SmtpClient();

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.EnableSsl = true;

            client.Host = "smtp.gmail.com";

            client.Port = 587;

            // setup Smtp authentication

            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("admission@vivacollege.org", "admission@321");

            client.UseDefaultCredentials = false;

            client.Credentials = credentials;



            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("admission@vivacollege.org");

            msg.To.Add(new MailAddress(txtEmailID.Value.Trim()));



            msg.Subject = "ThankYou for Registering.";

            msg.IsBodyHtml = true;

            msg.Body = string.Format("<html><head></head><body><b>Your User ID is : <font color=red>" + Session["Formno"] + "</font><br/><b>Your Password is : <font color=red>" + Session["passwd"] + "</font> <br/>For Online Admission from VIVA College</pre></b></body>");
            msg.IsBodyHtml = true;
            client.Send(msg);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }


    }

    //public bool sendmessage()
    //{
    //    try
    //    {
    //        string uid = "vivavit347422";
    //        string pwd = "24034";
    //        string gsmsenderid = "VIVACL";

    //        string mob = txtMobNo.Value.Trim();
    //        string msg = "Dear Student Your User ID is " + Session["Formno"] + " and Password is " + Session["passwd"] + " for Online Admission from VIVA College";
    //        string strRequest = "username=" + uid + "&password=" + pwd + "&sender=" + gsmsenderid + "&to=" + mob + "&message=" + msg + "&priority=0&dnd=1&unicode=0";
    //        string url = "http://www.sms19.com/ComposeSMS.aspx?";
    //        string Result_FromSMS = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = strRequest.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(strRequest);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            Result_FromSMS = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }

    //}


    public bool sendmessage()
    {
        try
        {
            string uid = "vivavit347422";
            string pwd = "24034";
            string gsmsenderid = "VIWAED";
            string cdmasenderid = "VIWAED";
            string msg = "Dear Student Your User ID is " + Session["Formno"] + " and Password is " + Session["passwd"] + " for Online Admission from Viva Institute of Management and Research";
            string strRequest = "username=" + uid + "&password=" + pwd + "&sender=" + gsmsenderid + "&cdmasender=" + cdmasenderid + "&to=" + txtMobNo.Value.Trim() + "&message=" + msg + "&priority=0&dnd=1&unicode=0";
            string url = "http://www.kit19.com/ComposeSMS.aspx?";
            string Result_FromSMS = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
            objRequest.Method = "POST";
            objRequest.ContentLength = strRequest.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(strRequest);
            myWriter.Close();
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                Result_FromSMS = sr.ReadToEnd();
                sr.Close();
            }

            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }


    public void disable()
    {
        txtEmailID.Disabled=true;
        txt_code.Disabled=true;
        txtFname.Disabled=true;
        txtMname.Disabled=true;
        txtMobNo.Disabled=true;
        txtMoName.Disabled=true;
        txtPasswd.Enabled=false;
        //txtSeatNo.Disabled=true;
        txtSurname.Disabled=true;
        txtVerifyPass.Enabled=false;
        ddday.Enabled = false;
        ddmonth.Enabled = false;
        ddyear.Enabled = false;

        //dd12passyear.Enabled = false;
        //dd12passmonth.Enabled = false;
        //rdbNo.Enabled = false;
        //rdbYes.Enabled = false;
        //cmbSubcourseName.Enabled = false;
        //cmbPrefaculty.Enabled = false;
        //cmbGroupname.Enabled = false;
        //txtPercentage.Enabled = false;
        //txtCredit1.Enabled = false;
        //txtCredit2.Enabled = false;
        //txtCredit3.Enabled = false;
        //txtCredit4.Enabled = false;
    }

    public void enable()
    {
        txtEmailID.Disabled = false;
        txt_code.Disabled = false;
        txtFname.Disabled = false;
        txtMname.Disabled = false;
        txtMobNo.Disabled = false;
        txtMoName.Disabled = false;
        txtPasswd.Enabled = true;
        //txtSeatNo.Disabled = false;
        txtSurname.Disabled = false;
        txtVerifyPass.Enabled = true;
        //datetimepicker1.Enabled = true;

        ddday.Enabled = true;
        ddmonth.Enabled = true;
        ddyear.Enabled = true;

        //dd12passyear.Enabled = true;
        //dd12passmonth.Enabled = true;
        //rdbNo.Enabled = false;
        //rdbYes.Enabled = false;
        //cmbSubcourseName.Enabled = false;
        //cmbPrefaculty.Enabled = false;
        //cmbGroupname.Enabled = false;
        //txtPercentage.Enabled = false;
        //txtCredit1.Enabled = false;
        //txtCredit2.Enabled = false;
        //txtCredit3.Enabled = false;
        //txtCredit4.Enabled = false;
    }

    public void enableFySy()
    {
        txtEmailID.Disabled = false;
        txt_code.Disabled = false;
        txtFname.Disabled = false;
        txtMname.Disabled = false;
        txtMobNo.Disabled = false;
        txtMoName.Disabled = false;
        txtPasswd.Enabled = true;
       // txtSeatNo.Disabled = true;
        txtSurname.Disabled = false;
        txtVerifyPass.Enabled = true;
        //datetimepicker1.Enabled=true;
        ddday.Enabled = true;
        ddmonth.Enabled = true;
        ddyear.Enabled = true;
        //dd12passyear.Enabled = false;
       // dd12passmonth.Enabled = false;
        //rdbNo.Enabled = true;
        //rdbYes.Enabled = true;
        //cmbSubcourseName.Enabled = true;
        //cmbPrefaculty.Enabled = true;
        //cmbGroupname.Enabled = true;
        //txtPercentage.Enabled = true;
        //txtCredit1.Enabled = true;
        //txtCredit2.Enabled = true;
        //txtCredit3.Enabled = true;
        //txtCredit4.Enabled = true;
    }

    public void clear()
    {
        txtEmailID.Value = "";
        txt_code.Value = "";
        txtFname.Value = "";
        txtMname.Value = "";
        txtMobNo.Value = "";
        txtMoName.Value = "";
        txtPasswd.Text = "";
        //txtSeatNo.Value = "";
        txtSurname.Value = "";
        txtVerifyPass.Text = "";
        //datetimepicker1.Text = "";
        ddday.SelectedIndex = 0;
        ddmonth.SelectedIndex=0;
        ddyear.SelectedIndex=0;

        //if (dd12passmonth.SelectedIndex > 0)
        //{
        //    dd12passmonth.SelectedIndex = 0;
        //}
        //if (dd12passyear.SelectedIndex > 0)
        //{
        //    dd12passyear.SelectedIndex = 0;
        //}
        //if (cmbGroupname.SelectedIndex > 0)
        //{
        //    cmbGroupname.SelectedIndex = 0;
        //}
        //if (cmbPrefaculty.SelectedIndex > 0)
        //{
        //    cmbPrefaculty.SelectedIndex = 0;
        //}
        //if (cmbSubcourseName.SelectedIndex > 0)
        //{
        //    cmbSubcourseName.SelectedIndex = 0;
        //}

        //rdbNo.Checked=false;
        //rdbYes.Checked = false;
     
        //txtPercentage.Text = "";
        //txtCredit1.Text = "";
        //txtCredit2.Text = "";
        //txtCredit3.Text = "";
        //txtCredit4.Text = "";
    }

    protected void rdbFyOutsider_CheckedChanged(object sender, EventArgs e)
    {
             
    }
  
    protected void rdbFyPG_CheckedChanged(object sender, EventArgs e)
    {
     
    }

    protected void rdbTy_CheckedChanged(object sender, EventArgs e)
    {
        enableFySy();
        clear();
        //lblSeatNo.Text = "Enter Seat No.";
        //lblPassingYr.Text = "Select Passing Year";
        //lblPassingMnt.Text = "Select Passing Month";
    }
    protected void rdbSy_CheckedChanged(object sender, EventArgs e)
    {
       
    }
    //protected void cmbPrefaculty_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    String q = "";
    //    if (ddl_applicant_type.SelectedValue=="02")
    //    {
    //        q = "select subcourse_name,subcourse_id from m_crs_subcourse_tbl s, dbo.m_crs_course_tbl c,dbo.m_crs_faculty f where s.course_id=c.course_id and c.faculty_id=f.faculty_id and (subcourse_name like 's%') and faculty_name ='" + cmbPrefaculty.Text.Trim() + "' order by subcourse_name";
    //    }
    //    if (ddl_applicant_type.SelectedValue == "03")
    //    {
    //        q = "select subcourse_name,subcourse_id from m_crs_subcourse_tbl s, dbo.m_crs_course_tbl c,dbo.m_crs_faculty f where s.course_id=c.course_id and c.faculty_id=f.faculty_id and (subcourse_name like 't%') and faculty_name ='" + cmbPrefaculty.Text.Trim() + "' order by subcourse_name";
    //    }

    //    DataSet dsPrefaculty = new DataSet();
    //    dsPrefaculty = cls.fill_dataset(q);
    //    DataRow dr;
    //    dr = dsPrefaculty.Tables[0].NewRow();
    //    dr[0] = "----SELECT----";

    //    dsPrefaculty.Tables[0].Rows.InsertAt(dr, 0);

    //    //cmbSubcourseName.DataSource = dsPrefaculty.Tables[0];
    //    //cmbSubcourseName.DataTextField = "subcourse_name";
    //    //cmbSubcourseName.DataValueField = "subcourse_id";
    //    //cmbSubcourseName.DataBind();

    //}
    //protected void cmbSubcourseName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    String q = "";
    //    q = "select Group_title,Group_id from dbo.m_crs_subjectgroup_tbl as a,m_crs_subcourse_tbl as b where a.Subcourse_id=b.Subcourse_id and b.subcourse_id='" + cmbSubcourseName.SelectedValue + "'";
    //    DataSet dsSubcourse = new DataSet();
    //    dsSubcourse = cls.fill_dataset(q);
    //    DataRow dr;
    //    dr = dsSubcourse.Tables[0].NewRow();
    //    dr[0] = "----SELECT----";

    //    dsSubcourse.Tables[0].Rows.InsertAt(dr, 0);

    //    //cmbGroupname.DataSource = dsSubcourse.Tables[0];
    //    //cmbGroupname.DataTextField = "Group_title";
    //    //cmbGroupname.DataValueField = "Group_id";
    //    //cmbGroupname.DataBind();


    //    cre_visible();
    //}

    //private void cre_visible()
    //{
    //    string a = cmbSubcourseName.SelectedItem.ToString();

    //    if (a.StartsWith("S"))
    //    {
    //        txtCredit1.Visible = true;
    //        lblcredit1.Visible = true;

    //        txtCredit2.Visible = true;
    //        lblcredit2.Visible = true;

    //        txtCredit3.Visible = false;
    //        lblcredit3.Visible = false;

    //        txtCredit4.Visible = false;
    //        lblcredit4.Visible = false;

    //    }
    //    else if (a.StartsWith("T"))
    //    {
    //        txtCredit1.Visible = true;
    //        lblcredit1.Visible = true;

    //        txtCredit2.Visible = true;
    //        lblcredit2.Visible = true;

    //        txtCredit3.Visible = true;
    //        lblcredit3.Visible = true;

    //        txtCredit4.Visible = true;
    //        lblcredit4.Visible = true;
    //    }
    //}
    protected void cmbGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void rdbSyPG_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_applicant_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_applicant_type.SelectedIndex > 0)
        {
            //if (ddl_applicant_type.SelectedIndex == 1)
            //{
            //    divdisable.Visible = false;
            //    divdisable2.Visible = true;
            //    enable();
            //    clear();
            //    lblSeatNo.Text = "Enter HSC Seat No.";
            //    lblPassingYr.Text = "Select HSC Passing Year";
            //    lblPassingMnt.Text = "Select HSC Passing Month";
            //}
            //else
                if (ddl_applicant_type.SelectedValue == "02")
            {
                //divdisable.Visible = true;
                //divdisable2.Visible = false;
                enableFySy();
                clear();
                //lblSeatNo.Text = "Enter Seat No.";
                //lblPassingYr.Text = "Select Passing Year";
                //lblPassingMnt.Text = "Select Passing Month";

                //txtCredit1.Visible = true;
                //lblcredit1.Visible = true;

                //txtCredit2.Visible = true;
                //lblcredit2.Visible = true;

                //txtCredit3.Visible = false;
                //lblcredit3.Visible = false;

                //txtCredit4.Visible = false;
                //lblcredit4.Visible = false;
            }
            else if (ddl_applicant_type.SelectedValue == "03")
            {
                //divdisable.Visible = true;
                //divdisable2.Visible = false;
                enableFySy();
                clear();
                //lblSeatNo.Text = "Enter Seat No.";
                //lblPassingYr.Text = "Select Passing Year";
                //lblPassingMnt.Text = "Select Passing Month";

                //txtCredit1.Visible = true;
                //lblcredit1.Visible = true;

                //txtCredit2.Visible = true;
                //lblcredit2.Visible = true;

                //txtCredit3.Visible = true;
                //lblcredit3.Visible = true;

                //txtCredit4.Visible = true;
                //lblcredit4.Visible = true;

            }
            //else if (ddl_applicant_type.SelectedIndex == 4)
            //{
            //    divdisable.Visible = false;
            //    divdisable2.Visible = true;
            //    enable();
            //    clear();
            //    lblSeatNo.Text = "Enter TY Seat No.";
            //    lblPassingYr.Text = "Select TY Passing Year";
            //    lblPassingMnt.Text = "Select TY Passing Month";
            //}
            //else if (ddl_applicant_type.SelectedIndex == 5)
            //{
            //    divdisable.Visible = false;
            //    divdisable2.Visible = true;
            //    enable();
            //    clear();
            //    lblSeatNo.Text = "Enter TY Seat No.";
            //    lblPassingYr.Text = "Select TY Passing Year";
            //    lblPassingMnt.Text = "Select TY Passing Month";
            //}
            else
            {
            }
        }
        else
        {
            disable();
            clear();
        }
    }
    protected void cmbGroupname_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}