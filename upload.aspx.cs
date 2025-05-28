using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FY_upload : System.Web.UI.Page
{
    FileUpload fup_Photo, fup_sign, fuppic;
    Class1 cls = new Class1();
    DataSet ds;
    DataSet ds_photo_new;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //errorMessage.Visible = false;
                if (Session["submit"].ToString() == "True")
                {
                    Response.Redirect("Apply_Courses.aspx", false);
                }
                else if (Session["step5_flag"] != null)
                {
                    ds = (DataSet)Session["App_data"];
                    if (Session["step5_flag"].ToString() == "True")
                    {
                        ds_photo_new = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");
                        if (ds_photo_new.Tables[0].Rows.Count > 0)
                        {
                            //Session["hasfile"] = 1;

                            if (!Convert.IsDBNull(ds_photo_new.Tables[0].Rows[0]["Stud_photo"]))
                            {
                                Byte[] byte_photo = (Byte[])ds_photo_new.Tables[0].Rows[0]["Stud_photo"];
                                string str_photo = Convert.ToBase64String(byte_photo, 0, byte_photo.Length);
                                imgphoto.ImageUrl = "data:image/png;base64," + str_photo;
                            }
                            if (!Convert.IsDBNull(ds_photo_new.Tables[0].Rows[0]["Stud_Sign"]))
                            {
                                Byte[] byte_sign = (Byte[])ds_photo_new.Tables[0].Rows[0]["Stud_Sign"];
                                string str_sign = Convert.ToBase64String(byte_sign, 0, byte_sign.Length);
                                imgsign.ImageUrl = "data:image/png;base64," + str_sign;
                            }
                            Session["sign"] = 1;
                            Session["pic"] = 1;
                        }
                        else
                        {
                            Session["hasfile"] = 0;
                        }
                    }
                    else
                    {
                        Response.Redirect("Other_Information.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Other_Information.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    public bool checkFileExtension(string filename)
    {
        if (filename.Contains(".") != true)
            return false;

        string[] validExtensions = new string[7];
        string ext = filename.Substring(filename.LastIndexOf('.') + 1).ToLower();


        validExtensions[0] = "jpg";
        validExtensions[1] = "jpeg";
        validExtensions[2] = "bmp";
        validExtensions[3] = "png";
        validExtensions[4] = "gif";
        validExtensions[5] = "tif";
        validExtensions[6] = "tiff";



        for (int i = 0; i < validExtensions.Length - 1; i++)
        {
            if (ext == validExtensions[i])
                return true;
        }

        return false;
    }

    public bool Assign_data()
    {
        ds = (DataSet)Session["App_data"];
        string final_sql_query = "update [d_adm_applicant] set step6_flag=1,step6_dt=getdate() where Form_no='" + Session["formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "'";

        return cls.insert_data_app(final_sql_query);
    }

    protected void btnuploadphoto_Click(object sender, EventArgs e)
    {
        if (filephoto.HasFile == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo To Continue');", true);
        }
        else
        {
            //lblErrMsgPhoto.Text = "";
            //lblErrMsgPhoto.Visible = false;
            Session["FileUploadPhoto"] = filephoto;
            if (checkFileExtension(filephoto.FileName) == true)
            {

                try
                {
                    //For PHOTO
                    ds = (DataSet)Session["App_data"];
                    fup_Photo = (FileUpload)Session["FileUploadPhoto"];
                    fuppic = (FileUpload)Session["FileUploadPhoto"];


                    int size = (fup_Photo.PostedFile.ContentLength);
                    if (size > 512000)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('File size not be exceed than 500 KB,500x500 px');", true);
                    }
                    else
                    {

                        byte[] theImage_pic = new byte[fuppic.PostedFile.ContentLength];
                        HttpPostedFile Image = fuppic.PostedFile;

                        Image.InputStream.Read(theImage_pic, 0, (int)fuppic.PostedFile.ContentLength);
                        int length = theImage_pic.Length;
                        string fileName = fuppic.FileName.ToString();


                        DataSet ds_photo = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");
                        if (fup_Photo.PostedFile != null && fup_Photo.PostedFile.FileName != "")
                        {
                            string sql1;
                            if (ds_photo.Tables.Count > 0 && ds_photo.Tables[0].Rows.Count > 0)
                            {
                                sql1 = "update d_adm_applicant_photo set Stud_photo=@img,mod_dt=getdate() where form_no='" + Session["Formno"].ToString() + "' and ayid='" + Session["ayid"].ToString() + "' and del_flag=0";

                            }
                            else
                            {
                                sql1 = "insert into d_adm_applicant_photo values('" + Session["ayid"].ToString() + "','" + Session["Formno"].ToString() + "',@img,null,getdate(),null,0,null)";

                            }

                            cls.Conn();
                            SqlCommand cmd = new SqlCommand(sql1, cls.con);
                            SqlParameter[] param = new SqlParameter[2];

                            param[0] = new SqlParameter("@img", SqlDbType.Image, length);
                            param[0].Value = theImage_pic;


                            //param[1] = new SqlParameter("@sign", SqlDbType.Image, length1);
                            //param[1].Value = theImage_sign;


                            cmd.Parameters.Add(param[0]);
                            // cmd.Parameters.Add(param[1]);
                            cmd.ExecuteNonQuery();
                            Session["step6_flag"] = "True";
                            Session["pic"] = 1;
                            string msg = "Photo Uploaded Successfully";
                            string alrt = "alert('" + msg + "'" + ");";
                            ClientScript.RegisterStartupScript(this.GetType(), "", alrt, true);
                            ds_photo_new = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");
                            if (ds_photo_new.Tables[0].Rows.Count > 0)
                            {
                                if (!Convert.IsDBNull(ds_photo_new.Tables[0].Rows[0]["Stud_photo"]))
                                {
                                    Byte[] byte_photo = (Byte[])ds_photo_new.Tables[0].Rows[0]["Stud_photo"];
                                    string str_photo = Convert.ToBase64String(byte_photo, 0, byte_photo.Length);
                                    imgphoto.ImageUrl = "data:image/png;base64," + str_photo;
                                }
                            }


                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                    throw new Exception(msg);
                }
                finally
                {
                    cls.con.Close();
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo To Continue');", true);
            }

        }
    }

    protected void btnsign_Click(object sender, EventArgs e)
    {
        if (filesign.HasFile == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo To Continue');", true);
        }
        else
        {
            Session["FileUploadSign"] = filesign;
            if (checkFileExtension(filesign.FileName) != true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo To Continue');", true);
            }
            else
            {
                try
                {
                    ds = (DataSet)Session["App_data"];
                    DataSet ds_photo = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");


                    fup_sign = (FileUpload)Session["FileUploadSign"];
                    int size1 = fup_sign.PostedFile.ContentLength;
                    if (size1 > 512000)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('File size not be exceed than 500 KB,500x500 px');", true);
                    }
                    else
                    {
                        byte[] theImage_sign = new byte[fup_sign.PostedFile.ContentLength];
                        // clsImageUpload img = new clsImageUpload();
                        // theImage_sign = img.HandleUploadedFile(fup_sign.PostedFile);
                        HttpPostedFile Image1 = fup_sign.PostedFile;

                        Image1.InputStream.Read(theImage_sign, 0, (int)fup_sign.PostedFile.ContentLength);
                        int length1 = theImage_sign.Length;
                        string fileName1 = fup_sign.FileName.ToString();
                        //string type = FileUpload1.PostedFile.ContentType; 




                        if (fup_sign.PostedFile != null && fup_sign.PostedFile.FileName != "")
                        {
                            string sql1;
                            if (ds_photo.Tables.Count > 0 && ds_photo.Tables[0].Rows.Count > 0)
                            {
                                sql1 = "update d_adm_applicant_photo set Stud_Sign=@sign,mod_dt=getdate() where form_no='" + Session["Formno"].ToString() + "'and ayid='" + Session["ayid"].ToString() + "' and del_flag=0";

                            }
                            else
                            {
                                sql1 = "insert into d_adm_applicant_photo values('" + Session["ayid"].ToString() + "','" + Session["Formno"].ToString() + "',null,@sign,getdate(),null,0,null)";
                            }

                            if (cls.con.State == ConnectionState.Open)
                            {
                                cls.con.Close();
                                cls.con.Open();
                            }
                            else
                            {
                                cls.con.Open();

                            }
                            SqlCommand cmd = new SqlCommand(sql1, cls.con);
                            SqlParameter[] param = new SqlParameter[2];

                            //param[0] = new SqlParameter("@img", SqlDbType.Image, length);
                            //param[0].Value = theImage_pic;


                            param[0] = new SqlParameter("@sign", SqlDbType.Image, length1);
                            param[0].Value = theImage_sign;


                            cmd.Parameters.Add(param[0]);
                            // cmd.Parameters.Add(param[1]);
                            cmd.ExecuteNonQuery();
                            Session["step6_flag"] = "True";

                            Session["sign"] = 1;
                            string msg = "Sign Uploaded Successfully";
                            string alrt = "alert('" + msg + "'" + ");";
                            ClientScript.RegisterStartupScript(this.GetType(), "", alrt, true);
                            ds_photo_new = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");
                            if (ds_photo_new.Tables[0].Rows.Count > 0)
                            {
                                if (!Convert.IsDBNull(ds_photo_new.Tables[0].Rows[0]["Stud_Sign"]))
                                {
                                    Byte[] byte_sign = (Byte[])ds_photo_new.Tables[0].Rows[0]["Stud_Sign"];
                                    string str_sign = Convert.ToBase64String(byte_sign, 0, byte_sign.Length);
                                    imgsign.ImageUrl = "data:image/png;base64," + str_sign;
                                }
                            }

                        }

                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                    throw new Exception(msg);
                }
                finally
                {
                    cls.con.Close();
                }
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ds_photo_new = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");
        if (ds_photo_new.Tables[0].Rows.Count > 0)
        {
            if (Convert.IsDBNull(ds_photo_new.Tables[0].Rows[0]["Stud_photo"]))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo To Continue');", true);
                return;
            }
            else if (Convert.IsDBNull(ds_photo_new.Tables[0].Rows[0]["Stud_sign"]))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo To Continue');", true);
                return;
            }
            else
            {
                if (Assign_data())
                {
                    Session["step6_flag"] = true;
                    Response.Redirect("Apply_Course.aspx");
                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Upload Your Photo And Sign To Continue');", true);

        }
    }
}