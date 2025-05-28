using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Configuration;
using System.IO;

public partial class web_form : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

    Class1 C1 = new Class1();
    SqlCommand cmd;
    SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("sy_ty_outsider_new");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = C1.con;
            cmd.Parameters.Add("@form_no", SqlDbType.VarChar, 8).Value = Session["Formno"].ToString();
            cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 8).Value = Session["AYID"].ToString();
            cmd.Parameters.Add("@grpid", SqlDbType.VarChar, 8).Value = Session["group_id"].ToString();

            //cmd.Parameters.Add("@form_no", SqlDbType.VarChar, 8).Value = Session["Formno"].ToString().ToUpper().Trim();
            //cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 8).Value = Session["ayid"].ToString().ToUpper().Trim();
            //cmd.Parameters.Add("@grpid", SqlDbType.VarChar, 8).Value = Session["group_id"].ToString().ToUpper().Trim();

            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            C1.con_close();

            
            //string qr_qry = "select a.Form_no ,isnull(F_name,' ')+' '+isnull(M_name,' ')+' '+isnull(L_name,' ')+' '+isnull(Mo_name,' ') as [STUDENT NAME], c.Group_title, case Is_inhouse when 0 then 'Inhouse' else 'Outsider' end as [inhouse], isnull(Other_criteria,' ') as [SPECIAL CATEGORY] from dbo.d_adm_applicant as a , OLA_FY_adm_CourseSelection as b , m_crs_subjectgroup_tbl as c where a.Form_no = b.formno and b.Group_id = c.Group_id and a.form_no= '" + Session["Formno"].ToString() + "' and b.Group_id = '" + Session["group_id"].ToString() + "'";
            string qr_qry = "select a.Form_no, isnull(a.F_name,' ')+' '+isnull(a.M_name,' ')+' '+isnull(a.L_name,' ')+' '+isnull(a.Mo_name,' ') as [STUDENT NAME], c.Group_title, case Is_inhouse when 0 then 'Inhouse' else 'Outsider' end as [inhouse], isnull(Other_criteria,' ') as [SPECIAL CATEGORY] from dbo.d_adm_applicant as a , adm_applicant_entry as b , m_crs_subjectgroup_tbl as c where a.Form_no = b.formno and b.Group_id = c.Group_id and a.form_no= '" + Session["Formno"].ToString() + "' and b.Group_id = '" + Session["group_id"].ToString() + "' and a.acdid='" + Session["AYID"].ToString() + "'";
            cmd = new SqlCommand(qr_qry);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = C1.con;
            da = new SqlDataAdapter(cmd);
            DataSet ds_qr = new DataSet();
            da.Fill(ds_qr);
            C1.con_close();

            if (ds_qr.Tables[0].Rows.Count > 0)
            {
                QRCodeEncoder encoder = new QRCodeEncoder();
                // encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H; // 30%

                encoder.QRCodeScale = 5;
                string path = "C:\\inetpub\\wwwroot\\syoutsider\\images\\";
                string img_path = "C:\\inetpub\\wwwroot\\syoutsider\\";
                //string path = "C:\\Users\\amy\\Desktop\\syoutsider\\images\\";
                //string img_path = "C:\\Users\\amy\\Desktop\\syoutsider\\";
                string s = "FORM NUMBER : " + ds_qr.Tables[0].Rows[0]["Form_no"].ToString() + Environment.NewLine;
                s = s + "STUDENT NAME : " + ds_qr.Tables[0].Rows[0]["STUDENT NAME"].ToString() + Environment.NewLine;
                s = s + "GROUP TITLE : " + ds_qr.Tables[0].Rows[0]["group_title"].ToString() + Environment.NewLine;
               
                s = s + "SPECIAL CATEGORY : " + ds_qr.Tables[0].Rows[0]["SPECIAL CATEGORY"].ToString() + Environment.NewLine;
                Bitmap img = encoder.Encode(s);


                System.Drawing.Image logo = System.Drawing.Image.FromFile(path + "viva1.gif");
                int left = (img.Width / 2) - (logo.Width / 2);

                int top = (img.Height / 2) - (logo.Height / 2);
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(logo, new Point(left, top));
                img.Save(img_path + "img.jpg", ImageFormat.Jpeg);
                qr_code.ImageUrl = "img.jpg";
                qr_code1.ImageUrl = "img.jpg";

            }

            lblrecivedform.Text = ds.Tables[0].Rows[0]["Form_no"].ToString().Trim();
             
            lblvivaform.Text = ds.Tables[0].Rows[0]["Form_no"].ToString().Trim();
            lblfname.Text = ds.Tables[0].Rows[0]["Name"].ToString().Trim();
            lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString().Trim();
            lblmobile.Text = ds.Tables[0].Rows[0]["Mob_No"].ToString().Trim();
            lblphone.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString().Trim();
            lblemail.Text = ds.Tables[0].Rows[0]["Email_id"].ToString().Trim();
            //lblinhouse.Text = ds.Tables[0].Rows[0]["Is_Inhouse"].ToString().Trim();
            lblcaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString().Trim();


            lblspecialcategory.Text = ds.Tables[0].Rows[0]["Other_criteria"].ToString().Trim();
            lblfreeship.Text = ds.Tables[0].Rows[0]["is_Scholarship"].ToString().Trim();



            lblgender.Text = ds.Tables[0].Rows[0]["Gender"].ToString().Trim();

            lblcategory.Text = ds.Tables[0].Rows[0]["Category"].ToString().Trim();
            lblreligion.Text = ds.Tables[0].Rows[0]["Religion"].ToString().Trim();
            lblbloodgrup.Text = ds.Tables[0].Rows[0]["blood_group"].ToString().Trim();
            lbldob.Text = ds.Tables[0].Rows[0]["DOB"].ToString().Trim();
            lblbirthplce.Text = ds.Tables[0].Rows[0]["birth_place"].ToString().Trim();

            string str2 = ds.Tables[0].Rows[0]["Marital_status"].ToString().Trim();

            lblmaritalstatus.Text = str2;

            string sgrp = ds.Tables[0].Rows[0]["group_id"].ToString().Trim(); ;

            string grp_id = sgrp.Substring(3, 3);
            string barcode_data = lblvivaform.Text + grp_id;
            lblvivaform.Text = "";
            lblvivaform.Text = barcode_data;

            barcode(barcode_data);
            lblrecivedform.Text = "";
            lblrecivedform.Text = barcode_data;
            barcode1(barcode_data);

            //string sgrp1 = ds.Tables[1].Rows[0]["group_id"].ToString().Trim(); ;

            //string grp_id1 = sgrp.Substring(3, 3);

            //string barcode_data1 = lblform.Text + grp_id;
            //lblform1.Text = "";
            //lblform1.Text = barcode_data1;
            //barcode1(barcode_data1);
            lblexam.Text = ds.Tables[0].Rows[0]["Exam"].ToString().Trim();
            lblphysicallychallngd.Text = ds.Tables[0].Rows[0]["Phy_handicap_Description"].ToString().Trim();
            lblboard.Text = ds.Tables[0].Rows[0]["S_Board_name"].ToString().Trim();
            lblclg.Text = ds.Tables[0].Rows[0]["S_Ins_Name"].ToString().Trim();
            lblmnth.Text = ds.Tables[0].Rows[0]["S_Month"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["S_Year"].ToString().Trim();
            //lblseat.Text = ds.Tables[0].Rows[0]["S_seat_no"].ToString().Trim();
            lblmrksobt.Text = ds.Tables[0].Rows[0]["S_Mks_Obtained"].ToString().Trim();
            lblmrkscout.Text = ds.Tables[0].Rows[0]["S_Mks_OutOf"].ToString().Trim();
            string lblfirs = ds.Tables[0].Rows[0]["firstAttempt"].ToString().Trim();

            grp_name.Text = ds.Tables[0].Rows[0]["group_name"].ToString().Trim();
            lbladmissioncourse.Text = ds.Tables[0].Rows[0]["group_name"].ToString().Trim();
            //if (lblfirs == "0")
            //{
            //    lblsscfirstattmt.Text = "yes";
            //}
            //else
            //{
            //    lblsscfirstattmt.Text = "no";
            //}

            string fy_query = "select * from adm_applicant_entry a,d_adm_applicant b where a.formno= '" + Session["Formno"].ToString() + "' and a.Group_id = '" + Session["group_id"].ToString() + "' and a.ayid='" + Session["AYID"].ToString() + "' and b.Form_no= '" + Session["Formno"].ToString() + "' and b.ACDID='" + Session["AYID"].ToString() + "'";
            
            DataSet ds1 = C1.fill_dataset(fy_query);
            Session["sem3"] = ds1.Tables[0].Rows[0]["SEM_3"].ToString();
            Session["sem4"] = ds1.Tables[0].Rows[0]["SEM_4"].ToString();
           //if (Session["sem3"] == null&&Session["SEM_4"]=="")
            if (string.IsNullOrEmpty(Convert.ToString(Session["sem3"])) && string.IsNullOrEmpty(Convert.ToString(Session["sem"])))
            {
                lbl_cource.Text = "FY";
                lbl_univers.Text = ds1.Tables[0].Rows[0]["Board_name"].ToString();
                lbl_colg_name.Text = ds1.Tables[0].Rows[0]["Ins_name"].ToString();
                lbl_sem1.Text = ds1.Tables[0].Rows[0]["SEM_1"].ToString();
                lbl_sem2.Text = ds1.Tables[0].Rows[0]["SEM_2"].ToString();
                lbl_sem3.Text = "-";
                lbl_sem4.Text = "-";
            }

            else
            {
                lbl_cource.Text = "FY/SY";
                lbl_univers.Text = ds1.Tables[0].Rows[0]["Board_name"].ToString();
                lbl_colg_name.Text = ds1.Tables[0].Rows[0]["Ins_name"].ToString();
                lbl_sem1.Text = ds1.Tables[0].Rows[0]["SEM_1"].ToString();
                lbl_sem2.Text = ds1.Tables[0].Rows[0]["SEM_2"].ToString();
                lbl_sem3.Text = ds1.Tables[0].Rows[0]["SEM_3"].ToString(); ;
                lbl_sem4.Text = ds1.Tables[0].Rows[0]["SEM_4"].ToString(); ;

            }
            //lblExam1.Text = ds.Tables[0].Rows[0]["S_Exam"].ToString().Trim();
            //lblboard1.Text = ds.Tables[0].Rows[0]["Board_name"].ToString().Trim();
            //lblclg1.Text = ds.Tables[0].Rows[0]["Ins_name"].ToString().Trim();
            //lblmnth1.Text = ds.Tables[0].Rows[0]["Month"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["Year"].ToString().Trim();
            ////lblseat1.Text = ds.Tables[0].Rows[0]["Seat_No"].ToString().Trim();
            //lblmarksobt1.Text = ds.Tables[0].Rows[0]["Mks_Obtained"].ToString().Trim();
            //lblmrksout1.Text = ds.Tables[0].Rows[0]["Mks_Outof"].ToString().Trim();
            lblrecieved.Text = ds.Tables[0].Rows[0]["Name"].ToString().Trim();

            string lblfirs1 = ds.Tables[0].Rows[0]["firstAttempt"].ToString().Trim();
            string base64String = Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Stud_photo"]);
            img1.ImageUrl = "data:image/png;base64," + base64String;


            //if (lblfirs1 == "0")
            //{
            //    lblhscfirstattmt.Text = "YES";
            //}
            //else
            //{
            //    lblhscfirstattmt.Text = "NO";
            //}


            //lblrecivedform.Text = ds.Tables[0].Rows[0]["Form_no"].ToString().Trim();

        }
        catch (Exception ex)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
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
            plBarCode.Controls.Add(imgBarCode);

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
            plBarCode1.Controls.Add(imgBarCode);

        }
    }

}
