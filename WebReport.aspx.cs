using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Configuration;
using System.IO;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using QRCoder;

public partial class WebReport : System.Web.UI.Page
{ 
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
    
    Class1 C1 = new Class1();
    SqlCommand cmd;
    SqlDataAdapter da;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("OLA_GET_FY_ADMISSION_PrintForm_Data");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = C1.con;
            cmd.Parameters.Add("@form_no", SqlDbType.VarChar, 8).Value = Session["Formno"].ToString();
            cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 8).Value = Session["ayid"].ToString();
            cmd.Parameters.Add("@grpid", SqlDbType.VarChar, 8).Value = Session["group_id"].ToString();

            //cmd.Parameters.Add("@form_no", SqlDbType.VarChar, 8).Value = Session["Formno"].ToString().ToUpper().Trim();
            //cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 8).Value = Session["ayid"].ToString().ToUpper().Trim();
            //cmd.Parameters.Add("@grpid", SqlDbType.VarChar, 8).Value = Session["group_id"].ToString().ToUpper().Trim();

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            C1.con_close();

            string qr_qry = "select a.Form_no ,isnull(F_name,' ')+' '+isnull(M_name,' ')+' '+isnull(L_name,' ')+' '+isnull(Mo_name,' ') as [STUDENT NAME], c.Group_title,Certificate_No, case dte_insti when '0' then 'DTE' else 'INSTITUTE' end as [dte_insti],case when a.remark is null then '' when a.remark like '%|%' then substring(a.remark, 1, CHARINDEX('|',a.remark)-1) else a.remark end as Aadhar_No,case when a.remark is null then '' when a.remark like '%|%' then substring(a.remark, CHARINDEX('|',a.remark)+1, LEN(a.remark)) else '' end as DTE, isnull(Other_criteria,' ') as [SPECIAL CATEGORY], a.Category from dbo.d_adm_applicant as a , OLA_FY_adm_CourseSelection as b , m_crs_subjectgroup_tbl as c where a.Form_no = b.formno and b.Group_id = c.Group_id and a.form_no= '" + Session["Formno"].ToString() + "' and b.Group_id = '" + Session["group_id"].ToString() + "' and a.ACDID = '" + Session["ayid"].ToString() + "'";
            cmd = new SqlCommand(qr_qry);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = C1.con;
            da = new SqlDataAdapter(cmd);
            DataSet ds_qr = new DataSet();
            da.Fill(ds_qr);
            C1.con_close();





            lblform.Text = ds.Tables[0].Rows[0]["Form_no"].ToString().Trim();
            lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString().Trim();
            lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString().Trim();
            lblmobNo.Text = ds.Tables[0].Rows[0]["Mob_No"].ToString().Trim();
            string phone_no = ds.Tables[0].Rows[0]["Phone_No"].ToString().Trim();
            lblphoneNo.Text = phone_no + ", " + ds.Tables[0].Rows[0]["Father_contact_No"].ToString().Trim();
            lblexam1.Text = ds.Tables[0].Rows[0]["exam"].ToString().Trim();
            lblexam.Text = ds.Tables[0].Rows[0]["s_exam"].ToString().Trim();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email_id"].ToString().Trim();
            // lbl_dte_Institute.Text = ds_qr.Tables[0].Rows[0]["dte_insti"].ToString().Trim();
            lblaadhar.Text = ds_qr.Tables[0].Rows[0]["Aadhar_No"].ToString().Trim();
            lblate.Text = ds_qr.Tables[0].Rows[0]["DTE"].ToString().Trim();


            if (ds.Tables[0].Rows[0]["Category"].ToString() != "OPEN" && ds.Tables[0].Rows[0]["Category"].ToString() != "EWS" && ds.Tables[0].Rows[0]["Category"].ToString() != "EBC")
            {
                if (ds_qr.Tables[0].Rows[0]["Certificate_No"].ToString().Trim() != "")
                {
                    if (ds_qr.Tables[0].Rows[0]["Certificate_No"].ToString().Contains("|"))
                    {
                        String[] arrcert = new String[5];
                        arrcert = ds_qr.Tables[0].Rows[0]["Certificate_No"].ToString().Split('|');
                        lblcerrec.Text = arrcert[1];
                        if (arrcert[2].ToString().Contains("Day") || arrcert[2].ToString().Contains("Month") || arrcert[2].ToString().Contains("Year"))
                        {
                            lblcerdt.Text = "--";
                        }
                        else
                        {
                            lblcerdt.Text = arrcert[2];
                        }
                       lblincrec.Text = arrcert[3];
                        if (arrcert[1].ToString().Contains("Day") || arrcert[1].ToString().Contains("Month") || arrcert[1].ToString().Contains("Year"))
                        {
                            lblincdt.Text = "--";
                        }
                        else
                        {
                            lblincdt.Text = arrcert[4];
                        }
                    }
                    else
                    {
                        lblincdt.Text = "--";
                        lblincrec.Text = "--";
                        lblcerdt.Text = "--";
                        lblcerrec.Text = "--";
                    }
                }
                else
                {
                    lblincdt.Text = "--";
                    lblincrec.Text = "--";
                    lblcerdt.Text = "--";
                    lblcerrec.Text = "--";
                }
            }
            else
            {
                lblincdt.Text = "--";
                lblincrec.Text = "--";
                lblcerdt.Text = "--";
                lblcerrec.Text = "--";
            }

            if (ds.Tables[0].Rows[0]["Category"].ToString() == "EBC")
            {
                if (ds_qr.Tables[0].Rows[0]["Certificate_No"].ToString() != "")
                {
                    if (ds_qr.Tables[0].Rows[0]["Certificate_No"].ToString().Contains("|"))
                    {
                        String[] arrcert1 = new String[3];
                        arrcert1 = ds_qr.Tables[0].Rows[0]["Certificate_No"].ToString().Split('|');
                        lblincrec.Text = arrcert1[1];
                        if (arrcert1[2].ToString().Contains("Day") || arrcert1[2].ToString().Contains("Month") || arrcert1[2].ToString().Contains("Year"))
                        {
                            lblincdt.Text = "--";
                        }
                        else
                        {
                            lblincdt.Text = arrcert1[2];
                        }
                        lblcerdt.Text = "--";
                        lblcerrec.Text = "--";
                    }
                    else
                    {
                        lblincdt.Text = "--";
                        lblincrec.Text = "--";
                        lblcerdt.Text = "--";
                        lblcerrec.Text = "--";
                    }
                }
                else
                {
                    lblincdt.Text = "--";
                    lblincrec.Text = "--";
                    lblcerdt.Text = "--";
                    lblcerrec.Text = "--";
                }
            }

            lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString().Trim();

            lblcategory.Text = ds.Tables[0].Rows[0]["Category"].ToString().Trim();
            lblreligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString().Trim();
            lblBlood.Text = ds.Tables[0].Rows[0]["blood_group"].ToString().Trim();
            lblDob.Text = ds.Tables[0].Rows[0]["DOB"].ToString().Trim();
            lblBirthPlace.Text = ds.Tables[0].Rows[0]["birth_place"].ToString().Trim();

            string str2 = ds.Tables[0].Rows[0]["Marital_status"].ToString().Trim();

            lblmarital.Text = str2;

            string sgrp = ds.Tables[0].Rows[0]["group_id"].ToString().Trim(); ;

            string grp_id = sgrp.Substring(3, 3);
            string barcode_data = lblform.Text + grp_id;
            lblform.Text = "";
            lblform.Text = barcode_data;

            barcode(barcode_data);
            lblform1.Text = "";
            lblform1.Text = barcode_data;
            barcode1(barcode_data);


            lblphy.Text = ds.Tables[0].Rows[0]["Phy_handicap_Description"].ToString().Trim();
            lblboard.Text = ds.Tables[0].Rows[0]["S_Board_name"].ToString().Trim();
            lblschool.Text = ds.Tables[0].Rows[0]["S_Ins_Name"].ToString().Trim();
            lblMonthYear.Text = ds.Tables[0].Rows[0]["S_Month"].ToString().Trim() + "-" + ds.Tables[0].Rows[0]["S_Year"].ToString().Trim();
            lblseatNo.Text = ds.Tables[0].Rows[0]["S_seat_no"].ToString().Trim();
            lblmarksobtain.Text = ds.Tables[0].Rows[0]["S_Mks_Obtained"].ToString().Trim();
            lblmarksoutoff.Text = ds.Tables[0].Rows[0]["S_Mks_OutOf"].ToString().Trim();
            //string lblfirs = ds.Tables[0].Rows[0]["firstAttempt"].ToString().Trim();

            grp_name.Text = ds.Tables[0].Rows[0]["group_name"].ToString().Trim();

            lbladmissioncourse.Text = ds.Tables[0].Rows[0]["group_name"].ToString().Trim();

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["firstAttempt"]))
            {
                lblfirst1.Text = "Yes";
            }
            else
            {
                lblfirst1.Text = "No";
            }


            lblBoard1.Text = ds.Tables[0].Rows[0]["Board_name"].ToString().Trim();
            lblcolgname1.Text = ds.Tables[0].Rows[0]["Ins_name"].ToString().Trim();
            lblMonthYear_1.Text = ds.Tables[0].Rows[0]["Month"].ToString().Trim() + "-" + ds.Tables[0].Rows[0]["Year"].ToString().Trim();
            lblseatNo_1.Text = ds.Tables[0].Rows[0]["Seat_No"].ToString().Trim();
            lblmarksobtain_1.Text = ds.Tables[0].Rows[0]["Mks_Obtained"].ToString().Trim();
            lblmarksoutoff_1.Text = ds.Tables[0].Rows[0]["Mks_Outof"].ToString().Trim();
            lblrecieved.Text = ds.Tables[0].Rows[0]["Name"].ToString().Trim();

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["S_first_Attempt"]))
            {
                lblfirst.Text = "Yes";
            }
            else
            {
                lblfirst.Text = "No";
            }

            string base64String = Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Stud_photo"]);
            img1.ImageUrl = "data:image/png;base64," + base64String;

            lblcaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString().Trim();

            lbl_specialcategory.Text = ds.Tables[0].Rows[0]["Other_criteria"].ToString().Trim();

            lbl_is_Scholarship.Text = ds.Tables[0].Rows[0]["is_Scholarship"].ToString().Trim();

            //Graduation detail
            lblGradBoard.Text = "(" + ds.Tables[0].Rows[0]["ty_course"].ToString() + ") " + ds.Tables[0].Rows[0]["ty_board"].ToString();
            lblGradInstitute.Text = ds.Tables[0].Rows[0]["ty_Institute_name"].ToString();

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ty_first_attempt"]))
            {
                lblGradFirst.Text = "Yes";
            }
            else
            {
                lblGradFirst.Text = "No";
            }

            lblGradPassMonth.Text = ds.Tables[0].Rows[0]["ty_pass_month"].ToString() + "-" + ds.Tables[0].Rows[0]["ty_pass_year"].ToString();
            lblGradSeat.Text = ds.Tables[0].Rows[0]["ty_seat_no"].ToString();
            lblGradMrksObt.Text = ds.Tables[0].Rows[0]["ty_marks_obt"].ToString();
            lblGradMrksOut.Text = ds.Tables[0].Rows[0]["ty_out_of"].ToString();

            //exam type
            //string exam_typeper = Convert.ToString(Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[0]["jee_obt"]) / Convert.ToDouble(ds.Tables[0].Rows[0]["jee_outof"])) * 100), 5));
            lbl_exam_type.Text = "Exam Type: " + ds.Tables[0].Rows[0]["exam_type"].ToString() + ", Marks Obt: " + ds.Tables[0].Rows[0]["jee_obt"].ToString() + ", Marks Out Of: " + ds.Tables[0].Rows[0]["jee_outof"].ToString() + "";

            //PG Detail
            if (string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["pg_inst_name"].ToString())))
            {
                pgDetail.Visible = false;
            }
            else
            {
                pgDetail.Visible = true;

                lblPGBosrd.Text = "(" + ds.Tables[0].Rows[0]["pg_course"].ToString() + ") " + ds.Tables[0].Rows[0]["pg_board"].ToString();
                lblPGInst.Text = ds.Tables[0].Rows[0]["pg_inst_name"].ToString();

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["pg_first_attempt"]))
                {
                    lblPGFirst.Text = "Yes";
                }
                else
                {
                    lblPGFirst.Text = "No";
                }

                lblPGpassMnt.Text = ds.Tables[0].Rows[0]["pg_passing_month"].ToString() + "-" + ds.Tables[0].Rows[0]["pg_passing_tear"].ToString();
                lblPGSeat.Text = ds.Tables[0].Rows[0]["pg_seat_no"].ToString();
                lblPGMrksObt.Text = ds.Tables[0].Rows[0]["pg_total_mks"].ToString();
                lblPGMrksOut.Text = ds.Tables[0].Rows[0]["pg_out_of_mks"].ToString();
            }

            //FY details
            if (Session["applicant_type"].ToString() == "SY")
            {
                FYTable.Visible = true;
                lbl_univers.Text = "FY MMS/" + ds.Tables[0].Rows[0]["fy_university_name"].ToString();
                lbl_colg_name.Text = ds.Tables[0].Rows[0]["fyi_Institute_name"].ToString();

                lbl_sem1_Sgpi.Text = ds.Tables[0].Rows[0]["fy_sem1_sgpi"].ToString();
                lbl_sem2_sgpi.Text = ds.Tables[0].Rows[0]["fy_sem2_sgpi"].ToString();
                //lbl_sem1_cr.Text = ds.Tables[0].Rows[0]["fy_sem1_CR"].ToString();
                //lbl_sem2_cr.Text = ds.Tables[0].Rows[0]["fy_sem2_CR"].ToString();
                //lbl_sem1_cg.Text = ds.Tables[0].Rows[0]["fy_sem1_cg"].ToString();
                //lbl_sem2_cg.Text = ds.Tables[0].Rows[0]["fy_sem2_cg"].ToString();
            }
            else
            {
                FYTable.Visible = false;
            }

            if (ds_qr.Tables[0].Rows.Count > 0)
            {
                //QRCodeEncoder encoder = new QRCodeEncoder();
                // encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H; // 30%

                // encoder.QRCodeScale = 5;

                string s = "";
                s = "FORM NUMBER : " + ds_qr.Tables[0].Rows[0]["Form_no"].ToString() + Environment.NewLine;
                s = s + "STUDENT NAME : " + ds_qr.Tables[0].Rows[0]["STUDENT NAME"].ToString() + Environment.NewLine;
                s = s + "GROUP TITLE : " + ds_qr.Tables[0].Rows[0]["group_title"].ToString() + Environment.NewLine;
                s = s + "DTE/INSTITUTE : " + ds_qr.Tables[0].Rows[0]["dte_insti"].ToString() + Environment.NewLine;
                s = s + "SPECIAL CATEGORY : " + ds_qr.Tables[0].Rows[0]["SPECIAL CATEGORY"].ToString() + Environment.NewLine;
                s = s + "ELIGIBLE : " + "YES" + Environment.NewLine;

                qr(s);
                qr1(s);

            }
            //lbluniversity_appno.Text = ds.Tables[0].Rows[0]["Univ_Enrol_no"].ToString().Trim();
        }
        catch (Exception ex)
        {
            ex.ToString();
            Session.Clear();
            Response.Redirect("Login.aspx", false);

        }
    }
    public void qr(string s)
    {
        string code = s;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 60;
        //imgBarCode.Width = 150;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            qr_code.Controls.Add(imgBarCode);
            //qr_code.Controls.Add(imgBarCode);
            //qr_code1.Controls.Add(imgBarCode);

        }
    }

    public void qr1(string s)
    {
        string code = s;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 150;
        imgBarCode.Width = 150;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            //qr_code.Controls.Add(imgBarCode);
            qr_code1.Controls.Add(imgBarCode);

        }
    }
    public void barcode(string id)
    {
        string barCode = id;
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
        {
            using (Graphics graphics = Graphics.FromImage(bitMap))
            {

                Font oFont = new Font("IDAutomationHC39M", 16);
                //Font oFont = new Font("IDAutomationHC39M", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();

                Convert.ToBase64String(byteImage);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
           // plBarCode.Controls.Add(imgBarCode);
           
        }
    }
    public static byte[] ImageToByte2(System.Drawing.Image img)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();

            byteArray = stream.ToArray();
        }
        return byteArray;
    }

    public void barcode1(string id)
    {
        string barCode = id;
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
        {
            using (Graphics graphics = Graphics.FromImage(bitMap))
            {

                Font oFont = new Font("IDAutomationHC39M", 16);
                //Font oFont = new Font("IDAutomationHC39M", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();

                Convert.ToBase64String(byteImage);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
           // plBarCode1.Controls.Add(imgBarCode);

        }
    }

    public String checkNullnew(string s1)
    {
        // string stra = "select field_type ,value from dbo.www_m_std_personaldetails_tbl where field_type = '" + s1 + "' and stud_id = '" + Session["UserName"] + "'";
        //  DataSet dsnew = C1.fill_dataset(stra);
        if (s1 == "")
        {
            return "-";
        }
        else
        {

            return s1;
        }


    }
}