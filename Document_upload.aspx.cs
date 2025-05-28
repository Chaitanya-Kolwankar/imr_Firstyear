using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Document_upload : System.Web.UI.Page
{

    FileUpload fup_Photo, fup_sign;
    Class1 cls = new Class1();
    DataSet ds;
    DataSet ds_photo_new;
    string sql1;
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
                    lblimp.Attributes.Add("style", "display:none");
                    div_image.Attributes.Add("style", "display:none");
                    div_pdf.Attributes.Add("style", "display:none");
                    DataSet ds1 = cls.fill_dataset("select * from d_adm_applicant WHERE  Form_no='" + Session["formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");
                    if (ds1.Tables[0].Rows[0]["Category"].ToString() != "OPEN")
                    {
                        ddl_doc.Items.Add(new ListItem("STUDENT_CASTE_CERTIFICATE"));
                        ddl_doc.Items.Add(new ListItem("STUDENT_CASTE_VALIDITY_CERTIFICATE"));
                        ddl_doc.Items.Add(new ListItem("STUDENT_NON-CREAMY_LAYER"));
                        ddl_doc.Items.Add(new ListItem("STUDENT_INCOME_CERTIFICATE"));
                    }


                    if ((ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("EBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SEBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("OBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("ST") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("NT") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("VJ") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SBC"))
                    {
                        ddl_doc.Items.Add(new ListItem("STUDENT_RATIONCARD"));
                    }


                    if (Convert.ToBoolean(ds1.Tables[0].Rows[0]["diploma_holder"].ToString()) == true)
                    {
                        ddl_doc.Items.Add(new ListItem("STUDENT_DIPLOMA_6_SEM"));
                    }


                    ds = (DataSet)Session["App_data"];
                    if (Session["step5_flag"].ToString() == "True")
                    {

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
    public bool Assign_data()
    {
        ds = (DataSet)Session["App_data"];
        string final_sql_query = "update [d_adm_applicant] set step6_flag=1,step6_dt=getdate() where Form_no='" + Session["formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "'";

        return cls.insert_data_app(final_sql_query);
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


        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file extension " + ext.ToUpper() + " is not allowed!Allowed Extensions are jpg,jpeg,bmp,png,gif,tif,tiff');", true);
        return false;
    }
    public bool checkFileExtension1(string filename)
    {


        if (filename.Contains(".") != true)
            return false;


        string[] validExtensions = new string[7];
        string ext = filename.Substring(filename.LastIndexOf('.') + 1).ToLower();


        validExtensions[0] = "pdf";




        for (int i = 0; i < validExtensions.Length - 1; i++)
        {
            if (ext == validExtensions[i])
                return true;
        }


        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The file extension " + ext.ToUpper() + " is not allowed!Allowed Extensions are pdf');", true);
        return false;
    }

    protected void btnuploadphoto_Click(object sender, EventArgs e)
    {
        if (ddl_doc.SelectedItem.Text == "STUDENT_MUMBAI_UNIVERSITY_FORM")
        {
            hdn_isSpecialForm.Value = "true";
            if (filephoto.HasFile == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select an PDF to upload');", true);

            }
            else
            {
                Session["FileUploadPhoto"] = filephoto;
                if (checkFileExtension1(filephoto.FileName) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select an PDF to upload');", true);
                }
                else
                {
                    try
                    {
                        fup_Photo = (FileUpload)Session["FileUploadPhoto"];
                        int size1 = fup_Photo.PostedFile.ContentLength;
                        if (size1 > 200000)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('File size not be exceed than 200 KB');", true);

                        }
                        else
                        {
                            string root = Session["Formno"].ToString();
                            string uploadFolder = Request.PhysicalApplicationPath + "2022_2023_DOC\\" + Session["Formno"].ToString() + "\\";
                            if (!Directory.Exists(root))
                            {

                                Directory.CreateDirectory(uploadFolder.Replace("\\", "/"));
                            }

                            string extension = Path.GetExtension(fup_Photo.PostedFile.FileName);
                            fup_Photo.SaveAs(uploadFolder.Replace("\\", "/") + "" + ddl_doc.SelectedItem.Text + ".pdf");
                              
                           

                            this.imgphoto.ImageUrl = ("~/images/fileuploaded_success.png").Replace("\\", "/");

                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ddl_doc.SelectedItem.Text + " Submitted Sucessfully');", true);

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
        else
        {
            hdn_isSpecialForm.Value = "false";
            if (filephoto.HasFile == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select an Photo to upload');", true);

            }
            else
            {
                Session["FileUploadPhoto"] = filephoto;
                if (checkFileExtension(filephoto.FileName) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select an Photo to upload');", true);
                }
                else
                {
                    try
                    {
                        fup_Photo = (FileUpload)Session["FileUploadPhoto"];
                        int size1 = fup_Photo.PostedFile.ContentLength;
                        if (size1 > 100000)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('File size not be exceed than 100 KB');", true);

                        }
                        else
                        {

                            string root = Session["Formno"].ToString();
                            string uploadFolder = Request.PhysicalApplicationPath + "2022_2023_DOC\\" + Session["Formno"].ToString() + "\\";
                            if (!Directory.Exists(root))
                            {

                                Directory.CreateDirectory(uploadFolder.Replace("\\", "/"));
                            }

                            string extension = Path.GetExtension(fup_Photo.PostedFile.FileName);
                            fup_Photo.SaveAs(uploadFolder.Replace("\\", "/") + "" + ddl_doc.SelectedItem.Text.Trim() + ".jpg");

                             DataSet ds_photo = cls.fill_dataset("select * from dbo.d_adm_applicant_photo where form_no='" + Session["Formno"].ToString() + "'");

                             if (ddl_doc.SelectedItem.Text == "STUDENT_PHOTO" || ddl_doc.SelectedItem.Text == "STUDENT_SIGNATURE")
                             { 
                                 byte[] theImage_photo = new byte[fup_Photo.PostedFile.ContentLength];
                                 // clsImageUpload img = new clsImageUpload();
                                 // theImage_sign = img.HandleUploadedFile(fup_sign.PostedFile);
                                 HttpPostedFile Image1 = fup_Photo.PostedFile;

                                 Image1.InputStream.Read(theImage_photo, 0, (int)fup_Photo.PostedFile.ContentLength);
                                 int length1 = theImage_photo.Length;
                                 string fileName1 = fup_Photo.FileName.ToString();
                                 //string type = FileUpload1.PostedFile.ContentType; 




                                 if (fup_Photo.PostedFile != null && fup_Photo.PostedFile.FileName != "")
                                 {
                                    
                                     if (ds_photo.Tables.Count > 0 && ds_photo.Tables[0].Rows.Count > 0)
                                     {

                                         if (ddl_doc.SelectedItem.Text == "STUDENT_SIGNATURE")
                                         {
                                         sql1 = "update d_adm_applicant_photo set Stud_Sign=@sign,mod_dt=getdate() where form_no='" + Session["Formno"].ToString() + "'and ayid='" + Session["ayid"].ToString() + "' and del_flag=0";
                                         }
                                         else if (ddl_doc.SelectedItem.Text == "STUDENT_PHOTO")
                                         {
                                             sql1 = "update d_adm_applicant_photo set Stud_photo=@img,mod_dt=getdate() where form_no='" + Session["Formno"].ToString() + "'and ayid='" + Session["ayid"].ToString() + "' and del_flag=0";
                                         }
                                     }
                                     else
                                     {
                                         if (ddl_doc.SelectedItem.Text == "STUDENT_PHOTO")
                                         {
                                             sql1 = "insert into d_adm_applicant_photo values('" + Session["ayid"].ToString() + "','" + Session["Formno"].ToString() + "',@img,null,getdate(),null,0,null)";
                                         }
                                         else if (ddl_doc.SelectedItem.Text == "STUDENT_SIGNATURE")
                                         {
                                             sql1 = "insert into d_adm_applicant_photo values('" + Session["ayid"].ToString() + "','" + Session["Formno"].ToString() + "',null,@sign,getdate(),null,0,null)";
                                         }
                                         else
                                         {

                                         }
                                        
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
                                     //SqlParameter[] param = new SqlParameter[2];

                                    //param[0] = new SqlParameter("@img", SqlDbType.Image, length);
                                    //param[0].Value = theImage_pic;


                                    if (ddl_doc.SelectedItem.Text == "STUDENT_SIGNATURE")
                                    {
                                        cmd.Parameters.Add("@sign", SqlDbType.Image, length1).Value = theImage_photo;
                                    }
                                    else if (ddl_doc.SelectedItem.Text == "STUDENT_PHOTO")
                                    {
                                        cmd.Parameters.Add("@img", SqlDbType.Image, length1).Value = theImage_photo;
                                    }


                                    //if(ddl_doc.SelectedItem.Text=="STUDENT_SIGNATURE")
                                    //{
                                    //   param[0] = new SqlParameter("@sign", SqlDbType.Image, length1);
                                    //   param[0].Value = theImage_photo;
                                    //   cmd.Parameters.Add(param[0]);
                                    //// cmd.Parameters.Add(param[1]);
                                    //   cmd.ExecuteNonQuery();
                                    //}
                                    //else if (ddl_doc.SelectedItem.Text == "STUDENT_PHOTO")
                                    //{
                                    //    param[0] = new SqlParameter("@img", SqlDbType.Image, length1);
                                    //    param[0].Value = theImage_photo;
                                    //   cmd.Parameters.Add(param[0]);
                                    //// cmd.Parameters.Add(param[1]);
                                    //   cmd.ExecuteNonQuery();
                                    //}
                                    else
                                     {

                                     }

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Success Message
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Image/Signature updated successfully!');", true);
                                    }
                                    else
                                    {
                                        // Failure Message
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No update done! Check form number and ayid.');", true);
                                    }


                                }
                             }





                            this.imgphoto.ImageUrl = ("~/2022_2023_DOC/" + Session["Formno"].ToString() + "/" + ddl_doc.SelectedItem.Text.Trim() + ".jpg").Replace("\\", "/");

                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ddl_doc.SelectedItem.Text + " Submitted Sucessfully');", true);


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





    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string strdata = "";
        string ext = "";
        string[] arrItems = new string[ddl_doc.Items.Count];
        if (ddl_doc.Items.Count > 0)
        {
            DataSet ds1 = cls.fill_dataset("select * from d_adm_applicant WHERE  Form_no='" + Session["formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");

            for (int i = 1; i < ddl_doc.Items.Count; i++)
            {
                arrItems[i] = ddl_doc.Items[i].ToString();

                if (ddl_doc.Items[i].ToString() == "STUDENT_MUMBAI_UNIVERSITY_FORM")
                {
                    ext = "pdf";
                }
                else
                {
                    ext = "jpg";
                }
                string imgpho = "~/2022_2023_DOC/" + Session["Formno"].ToString() + "/" + ddl_doc.Items[i].ToString() + "." + ext + "";
                if ((File.Exists(Server.MapPath(imgpho))) == false)
                {
                    //if (ddl_doc.Items[i].ToString() == "STUDENT_RATIONCARD")
                    //{
                    //    if ((ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("EBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SEBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("OBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("ST") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("NT") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("VJ") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SBC"))
                    //    {
                    //    }
                    //    else
                    //    {
                    //        if (strdata == "")
                    //        {
                    //            strdata = ddl_doc.Items[i].ToString();
                    //        }
                    //        else
                    //        {
                    //            strdata = strdata + "," + ddl_doc.Items[i].ToString();
                    //        }
                    //    }
                    //}
                    //else if (ddl_doc.Items[i].ToString() == "STUDENT_GAP_CERTIFICATE")
                    //{

                    //}
                    //else if (ddl_doc.Items[i].ToString() == "STUDENT_MIGRATION_CERTIFICATE")
                    //{

                    //}
                    //else
                    //{
                    //    if (strdata == "")
                    //    {
                    //        strdata = ddl_doc.Items[i].ToString();
                    //    }
                    //    else
                    //    {
                    //        strdata = strdata + "," + ddl_doc.Items[i].ToString();
                    //    }
                    //}
                    if (ddl_doc.Items[i].ToString() == "STUDENT_PHOTO" || ddl_doc.Items[i].ToString() == "STUDENT_SIGNATURE")
                    {
                        if (strdata == "")
                        {
                            strdata = ddl_doc.Items[i].ToString();
                        }
                        else
                        {
                            strdata = strdata + "," + ddl_doc.Items[i].ToString();
                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }


            }
        }


        if (strdata != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + strdata + "are not  Submitted ');", true);
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

    protected void ddl_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = cls.fill_dataset("select * from d_adm_applicant WHERE  Form_no='" + Session["formno"].ToString() + "' and ACDID='" + Session["ayid"].ToString() + "' and del_flag=0");

        if (ddl_doc.SelectedItem.Text == "STUDENT_MUMBAI_UNIVERSITY_FORM")
        {
            hdn_isSpecialForm.Value = "true";
            lbldocname.Text = "Upload " +ddl_doc.SelectedItem.Text;
            lblimp.Attributes.Add("style", "display:block;color:red");
            div_image.Attributes.Add("style", "display:none");
            div_pdf.Attributes.Add("style", "display:block");
            string imgpho = "~/2022_2023_DOC/" + Session["Formno"].ToString() + "/" + ddl_doc.SelectedItem.Text + ".jpg";
            if ((File.Exists(Server.MapPath(imgpho))) == false)
            {
                imgphoto.ImageUrl = ("~/images/fileuploaded_success.png").Replace("\\", "/");
            }
            else
            {

                imgphoto.ImageUrl = "";
            }
        }
        else if (ddl_doc.SelectedItem.Text == "--SELECT--")
        {
            hdn_isSpecialForm.Value = "false";
            lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
            lblimp.Attributes.Add("style", "display:none;color:red");
            div_image.Attributes.Add("style", "display:none");
            div_pdf.Attributes.Add("style", "display:none");
            imgphoto.ImageUrl = "";

        }
        else
        {
            hdn_isSpecialForm.Value = "false";
            div_image.Attributes.Add("style", "display:block");
            div_pdf.Attributes.Add("style", "display:none");
            string imgpho = "~/2022_2023_DOC/" + Session["Formno"].ToString() + "/" + ddl_doc.SelectedItem.Text + ".jpg";
            if ((File.Exists(Server.MapPath(imgpho))) == false)
            {
                imgphoto.ImageUrl = "";
            }
            else
            {
                imgphoto.ImageUrl = ("~/2022_2023_DOC/" + Session["Formno"].ToString() + "/" + ddl_doc.SelectedItem.Text + ".jpg").Replace("\\", "/");
            }










            //if (ddl_doc.SelectedItem.Text == "STUDENT_RATIONCARD")
            //{
            //    if ((ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("EBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SEBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("OBC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("ST") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SC") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("NT") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("VJ") || (ds1.Tables[0].Rows[0]["Category"].ToString()).Contains("SBC"))
            //    {
            //        lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
            //        lblimp.Attributes.Add("style", "display:block;color:red");
            //    }
            //    else
            //    {
            //        lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
            //        lblimp.Attributes.Add("style", "display:none;color:red");
            //    }
            //}
            //else if (ddl_doc.SelectedItem.Text == "STUDENT_GAP_CERTIFICATE" || ddl_doc.SelectedItem.Text == "STUDENT_MIGRATION_CERTIFICATE")
            //{
            //    lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
            //    lblimp.Attributes.Add("style", "display:none;color:red");
            //}
            //else
            //{
            //    lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
            //    lblimp.Attributes.Add("style", "display:block;color:red");
            //}


























            if (ddl_doc.SelectedItem.Text == "STUDENT_PHOTO" || ddl_doc.SelectedItem.Text == "STUDENT_SIGNATURE")
            {
                hdn_isSpecialForm.Value = "false";
                lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
                lblimp.Attributes.Add("style", "display:block;color:red");
            }
            else
            {
                lbldocname.Text = "Upload " + ddl_doc.SelectedItem.Text;
                lblimp.Attributes.Add("style", "display:NONE;color:red");
            }
        }

    }
}