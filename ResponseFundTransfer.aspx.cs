using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Configuration;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


public partial class ResponseFundTransfer : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            if (!IsPostBack)
            {
                NameValueCollection nvc = Request.Form;

                if (Request.Params["mmp_txn"] != null)
                {
                    string postingmmp_txn = Request.Params["mmp_txn"].ToString();
                    string postingmer_txn = Request.Params["mer_txn"];
                    string postinamount = Request.Params["amt"].ToString();
                    string postingprod = Request.Params["prod"].ToString();
                    string postingdate = Request.Params["date"].ToString();
                    string postingbank_txn = Request.Params["bank_txn"].ToString();
                    string postingf_code = Request.Params["f_code"].ToString();
                    string postingbank_name = Request.Params["bank_name"].ToString();
                    string signature = Request.Params["signature"].ToString();
                    string postingdiscriminator = Request.Params["discriminator"].ToString();
                    //string customername = Request.Params["udf1"].ToString();
                    //string customermail = Request.Params["udf2 "].ToString();
                    //string customerno = Request.Params["udf3 "].ToString();
                    string customername = "";
                    string customermail = "";
                    string customerno = "";

                  
                 //string respHashKey = "KEYRESP123657234";
                    string respHashKey = "ffaf3be9d434b054e3";
                    string ressignature = "";
                    string strsignature = postingmmp_txn + postingmer_txn + postingf_code + postingprod + postingdiscriminator + postinamount + postingbank_txn;
                    //string strsignature = postingmmp_txn + postingmer_txn1 + postingf_code + postingprod + discriminator + postinamount + postingbank_txn;
                    byte[] bytes = Encoding.UTF8.GetBytes(respHashKey);
                    byte[] b = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
                    ressignature = byteToHexString(b).ToLower();

                    if (signature == ressignature)
                    {
                        if (postingf_code == "F")
                        {
                           // Response.Redirect("http://localhost:2394/student/form_final.aspx");
                            lblStatus.Text = "Signature matched..." + postinamount + " " + postingbank_txn + " " + postingdate + " " + postingprod + " " + postingf_code + " " + postingbank_name + " " + signature + " " + postingdiscriminator;
                        }
                        else if (postingf_code == "C")
                        {
                            //Response.Redirect("http://localhost:2394/student/form_final.aspx");
                            lblStatus.Text = "Signature matched..." + postinamount + " " + postingbank_txn + " " + postingdate + " " + postingprod + " " + postingf_code + " " + postingbank_name + " " + signature + " " + postingdiscriminator;
                        }
                        else if (postingf_code == "S")
                        {
                            lblStatus.Text = "Signature matched..." + postinamount + " " + postingbank_txn + " " + postingdate + " " + postingprod + " " + postingf_code + " " + postingbank_name + " " + signature + " " + postingdiscriminator;
                        }
                        else if (postingf_code == "Ok")
                        {
                            lblStatus.Text = "Signature matched..." + postinamount + " " + postingbank_txn + " " + postingdate + " " + postingprod + " " + postingf_code + " " + postingbank_name + " " + signature + " " + postingdiscriminator;
                        }
                    }
                    else
                    {
//                        lblStatus.Text = "Signature Mismatched...";Response.Redirect("http://203.192.254.34/STUDENT_ERP/FEE_RECIEPT_COPY.ASPX");
                        //lblStatus.Text = "Signature Mismatched..."; Response.Redirect("http://localhost:2394/student/form_final.aspx");

                    }
                   //Response.Redirect("http://203.192.254.34/STUDENT_ERP/FEE_RECIEPT_COPY.ASPX?postingmmp_txn="+postingmmp_txn+"&postingmer_txn="+postingmer_txn+"&postinamount="+postinamount+"&postingprod="+postingprod+"&postingdate="+postingdate+"&postingbank_txn="+postingbank_txn+"&postingf_code="+postingf_code+"&postingbank_name="+postingbank_name+"&postingdiscriminator="+postingdiscriminator+"&customername="+customername+"&customermail="+customermail+"&customerno="+customerno);
                   // Response.Redirect("http://vivacollege.in/student/fee_reciept_copy_pay.ASPX?postingmmp_txn=" + postingmmp_txn + "&postingmer_txn=" + postingmer_txn + "&postinamount=" + postinamount + "&postingprod=" + postingprod + "&postingdate=" + postingdate + "&postingbank_txn=" + postingbank_txn + "&postingf_code=" + postingf_code + "&postingbank_name=" + postingbank_name + "&postingdiscriminator=" + postingdiscriminator + "&customername=" + customername + "&customermail=" + customermail + "&customerno=" + customerno);


                    //try
                    //{
                        String[] val = new String[0];
                        string id = "";

                        id = postingmer_txn.Substring(0, 8);
                        //if (postingmer_txn.Contains("2018"))
                        //{
                        //    val = postingmer_txn.Split('2018');
                        //    id = val[0] + "A";
                        //}
                        //else if (postingmer_txn.Contains("J")) { val = postingmer_txn.Split('A'); id = val[0] + "J"; }
                        string str = "    update processing_fees set name='" + customername + "',mobile_no='" + customerno + "',email='" + customermail + "',postinamount='" + postinamount + "',postingmmp_txn='" + postingmmp_txn + "',postingprod='" + postingprod + "',postingdate='" + postingdate + "',postingbank_txn='" + postingbank_txn + "',postingf_code='" + postingf_code + "',postingbank_name='" + postingbank_name + "',signature='Matched',postingdiscriminator='" + postingdiscriminator + "',curr_dt=getdate() where form_no='" + postingmer_txn.Substring(0, 5) + "' and postingmer_txn='" + postingmer_txn + "'";
                        //  string str = "insert into processing_fees values('" + id + "','" + customername + "','" + customerno + "','" + customermail + "','" + postinamount + "','" + postingmmp_txn + "','" + postingmer_txn + "','" + postingprod + "','" + postingdate + "','" + postingbank_txn + "','" + postingf_code + "','" + postingbank_name + "','Matched','" + postingdiscriminator + "','Fees','" + Session["ayid"].ToString() + "',getdate())";



                        c1.update_data(str);
                        //DataSet newds = apivalues(id);
                        string trans_id = "";
                        if (postingf_code == "S" || postingf_code == "Ok")
                        {
                            string str123 = "select * from d_adm_applicant where form_no='" + id.Substring(0,5) + "' and acdid=(select ayid from m_academic where iscurrent=1) and stud_id is null or stud_id=''";
                            DataSet dt123 = c1.fill_dataset(str123);
                            if(dt123.Tables[0].Rows.Count>0)
                            {
                           
                            string str11 = "select Duration,ayid from m_academic where iscurrent='1'";
                            DataSet dt11 = c1.fill_dataset(str11);

                            Session["ayid"] = dt11.Tables[0].Rows[0]["ayid"].ToString();

                            string sum = Convert.ToString(Convert.ToUInt32(dt11.Tables[0].Rows[0]["ayid"].ToString().Substring(5, 2)) + 1);

                            string str1 = "select MAX(Recpt_no) as rec_no from m_FeeEntry where ayid=(select ayid from m_academic where IsCurrent=1)";
                            
                            DataSet dt2 = c1.fill_dataset(str1);
                            trans_id = "";
                            if (dt2.Tables[0].Rows.Count > 0)
                            {
                                if (dt2.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    string count = Convert.ToString((Convert.ToInt32(dt2.Tables[0].Rows[0][0].ToString()) + 1));
                                    trans_id = count;
                                }
                                else
                                {
                                    trans_id = "1";
                                }
                            }
                            else
                            {
                                trans_id = "1";

                            }
                            //string update = "update  www_m_std_personaldetails_tbl set flag=1 where  stud_id='" + id + "' and ayid='" + Session["ayid"].ToString() + "'";

                            //c1.update_data(update);
                            //string subcourse = "select * from m_crs_subcourse_tbl where subcourse_name='" + newds.Tables[3].Rows[0]["subcourse_name"].ToString() + "'";
                            //DataSet dt = c1.fill_dataset(subcourse);
                            //string str123 = "select * from m_std_studentacademic_tbl where stud_id='" + id + "' and ayid=(select ayid from m_academic where iscurrent=1)";
                            //DataSet dt123 = c1.fill_dataset(str123);
                            //string str1234 = "select * from www_eligibility where stud_id='" + id + "' and to_year='" + Session["ayid"].ToString() + "'";
                            //DataSet dt1234 = c1.fill_dataset(str1234);
                           
                            //Session["groupid"] = dt1234.Tables[0].Rows[0]["to_group_id"].ToString();
                            //if (dt123.Tables[0].Rows.Count == 0)
                            //{
                            //    string temp_str = "if exists (select * from Temp_Student_data where stud_id='" + id + "' and ayid= '" + Session["ayid"].ToString() + "') update Temp_Student_data set from_Subcourse_id='" + frm_sub1.Tables[0].Rows[0]["subcourse_id"].ToString() + "',Group_Id='" + Session["groupid"] + "',Ayid='" + Session["ayid"].ToString() + "',To_Subcourse_id='" + dt.Tables[0].Rows[0]["subcourse_id"].ToString() + "',Div='',Roll_no='',Marks_Obtained='100',Out_Of_Mks='100',Remark=''  where Stud_Id ='" + id + " ' and ayid= '" + Session["ayid"].ToString() + "' else insert into Temp_Student_data values('" + id + "','" + frm_sub1.Tables[0].Rows[0]["subcourse_id"].ToString() + "','" + Session["groupid"] + "','" + Session["ayid"].ToString() + "','" + dt.Tables[0].Rows[0]["subcourse_id"].ToString() + "','','','100','100','','0')";
                            //    c1.update_data(temp_str);
                            //    string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
                            //    using (SqlConnection con = new SqlConnection(cs))
                            //    {
                            //        using (SqlCommand cmd = new SqlCommand("insert_update_admission_fees1", con))
                            //        {
                            //            con.Open();
                            //            cmd.CommandType = CommandType.StoredProcedure;

                            //            cmd.Parameters.AddWithValue("@stud_id", id);
                            //            cmd.Parameters.AddWithValue("@subcourse_Id", dt.Tables[0].Rows[0]["subcourse_id"].ToString());
                            //            cmd.Parameters.AddWithValue("@group_id", Session["groupid"]);
                            //            cmd.Parameters.AddWithValue("@Course_tot_fees", 0);
                            //            cmd.Parameters.AddWithValue("@Course_Fee_Paid", 0);


                            //            cmd.Parameters.AddWithValue("@Course_fee_Bal", 0);

                            //            cmd.Parameters.AddWithValue("@Ayid", Session["ayid"].ToString());
                            //            cmd.Parameters.AddWithValue("@user_id", "Admin");
                            //            string message = Convert.ToString(cmd.ExecuteScalar());

                                       // string st = "select * from online_payment_grant where stud_id='" + id + "'";
                             string frm_sub = "select * from m_crs_subjectgroup_tbl where group_id='GRP" + id.Substring(5, 3) + "'";
                            DataSet frm_sub1 = c1.fill_dataset(frm_sub);
                            string insert = "Exec proc_autoid_LMS_FY '" + id.Substring(0, 5) + "','FIN0045','" + Session["ayid"].ToString() + "','GRP" + id.Substring(5, 3) + "'";
                                 
                                string formno = id;
                               SqlDataReader resultset = c1.RetriveQuery(insert);
                                    if (resultset.HasRows == true)
                                    {
                                        while (resultset.Read())
                                        {
                                            id = (resultset[0].ToString());
                                        }
                                    }
                                        int amt = 0;
                                        int other_fees=0;
                                        int dev_fees=0;
                                        int tut_fees=0;
                                        string remark = "";
                               //         string st = "select struct_name as parti,SUM(amount) as fee,(SUM(amount)-(select isnull(SUM(Amount),'0') from m_FeeEntry where Ayid='" + Session["ayid"].ToString() + "' and struct_name=a.struct_name and stud_id='" + id + "' and del_flag=0)) as Amount from m_FeeMaster as a where Ayid='" + Session["ayid"].ToString() + "' and Group_id='" + Session["groupid"] + "' and Struct_name not like 'tut%' and Struct_name not like 'tui%' and Struct_name not like 'dev%' and del_flag=0"
                               //+ " union all select 'Devlopment Fees',SUM(amount) as fee,(SUM(amount)-(select isnull(SUM(Amount),'0') from m_FeeEntry where Ayid='" + Session["ayid"].ToString() + "' and struct_name=a.struct_name  and stud_id='" + id + "' and del_flag=0)) as Amount from m_FeeMaster as a where Ayid='" + Session["ayid"].ToString() + "' and Group_id='" + Session["groupid"] + "' and Struct_name  like 'dev%' and del_flag=0"
                               //+ " union all select 'Tution Fees',SUM(amount) as fee,(SUM(amount)-(select isnull(SUM(Amount),'0') from m_FeeEntry where Ayid='" + Session["ayid"].ToString() + "' and struct_name=a.struct_name  and stud_id='" + id + "' and del_flag=0)) as Amount from m_FeeMaster as a where Ayid='" + Session["ayid"].ToString() + "' and Group_id='" + Session["groupid"] + "' and (Struct_name  like 'tut%' or Struct_name  like 'tui%')  and del_flag=0";
                            string st_fee_str="select * from (select struct_name as parti,SUM(amount) as fee,(SUM(amount)-(select isnull(SUM(Amount),'0') from m_FeeEntry where Ayid='" + Session["ayid"].ToString() + "' and "
+" struct_name=a.struct_name and stud_id='" + id + "' and del_flag=0)) as Amount from m_FeeMaster as a where Ayid='" + Session["ayid"].ToString() + "' and "
+ " Group_id='GRP" + formno.Substring(5, 3) + "' and Struct_name not like 'tut%' and Struct_name not like 'tui%' and Struct_name not like 'dev%' and del_flag=0 group by Struct_name ) ab where amount not like '0'"
+" union all select * from (select struct_name as parti,SUM(amount) as fee,(SUM(amount)-(select isnull(SUM(Amount),'0') from m_FeeEntry where Ayid='" + Session["ayid"].ToString() + "' "
+" and struct_name=a.struct_name  and stud_id='" + id + "' and del_flag=0)) as Amount from m_FeeMaster as a where Ayid='" + Session["ayid"].ToString() + "' and "
+ " Group_id='GRP" + formno.Substring(5, 3) + "' and Struct_name  like 'dev%' and del_flag=0 group by Struct_name ) ab where amount not like '0'"
 +" union all select * from (select struct_name as parti,SUM(amount) as fee,(SUM(amount)-(select isnull(SUM(Amount),'0') from m_FeeEntry where Ayid='" + Session["ayid"].ToString() + "' and struct_name=a.struct_name  and "
 +" stud_id='" + id + "' and del_flag=0)) as Amount from m_FeeMaster as a where Ayid='" + Session["ayid"].ToString() + "' and "
 + " Group_id='GRP" + formno.Substring(5, 3) + "' and (Struct_name  like 'tut%' or Struct_name  like 'tui%')  and del_flag=0 group by Struct_name ) ab where amount not like '0'";
                            DataSet ds = c1.fill_dataset(st_fee_str);
                            int k_amt=Convert.ToInt32(postinamount.Split('.')[0]);
                            int act_fee=0;
                            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
                            {
                                 k_amt=k_amt- Convert.ToInt32(ds.Tables[0].Rows[i]["Amount"].ToString());
                                if(k_amt<0)
                                {
                                    act_fee=Convert.ToInt32(ds.Tables[0].Rows[i]["Amount"].ToString())-Convert.ToInt32( k_amt.ToString().Replace("-",""));
                                }
                                else{
                                    act_fee=Convert.ToInt32(ds.Tables[0].Rows[i]["Amount"].ToString());

                                }
                            if (!act_fee.ToString().Contains("-"))
                            {


                                //act_fee =Convert.ToInt32(act_fee.ToString().Replace("-",""));
                                //  string   ins_fee = "insert into m_FeeEntry select stud_id,'"+act_fee+"',a.ayid,GETDATE(),'"+ds.Tables[0].Rows[i]["parti"].ToString()+"','Online Pay','" + trans_id + "',null,null,null,null,'Clear','Fee','" + ds.Tables[0].Rows[0]["category"] + "','freeship/scholarship','Admin',GETDATE(),null,'0',null from m_std_studentacademic_tbl as a,m_FeeMaster as b where stud_id='" + id + "' and a.group_id=b.Group_id and a.ayid=(select ayid from m_academic where IsCurrent=1) and a.ayid=b.Ayid and  Struct_name not like 'TUT%' union all select a.stud_id,case when stud_Category='OBC' then (cast(Amount as int)/2) else '0' end,a.ayid,GETDATE(),Struct_name,'Online Pay','',null,null,null,null,'Clear','Fee','" + ds.Tables[0].Rows[0]["category"] + "','freeship/scholarship','Admin',GETDATE(),null,'0',null from m_std_studentacademic_tbl as a,m_FeeMaster as b,m_std_personaldetails_tbl as c where a.stud_id=c.stud_id and c.stud_id='" + id + "' and a.group_id=b.Group_id and a.ayid=(select ayid from m_academic where IsCurrent=1) and a.ayid=b.Ayid and  Struct_name like 'TUT%'";
                                string ins_fee = " insert into m_FeeEntry select stud_id,'" + act_fee + "','" + Session["ayid"].ToString() + "',GETDATE(),'" + ds.Tables[0].Rows[i]["parti"].ToString() + "','Online Pay','" + trans_id + "',null,null,null,null,'Clear','Fee',case when stud_Category='OPEN' then '' else stud_Category end , case when stud_Category='OPEN' then '' else 'freeship/scholarship' end ,'Admin',GETDATE(),null,'0',null from m_std_personaldetails_tbl as a where stud_id='" + id + "' ";



                                c1.update_data(ins_fee);
                            }
                            }
                                      
                        string ss = id + "|" + trans_id;
                        //string ss = id + "|16020015A/17-18/1";
                        if (ss.Contains("|") == true)
                        {
                            if (ss.Contains("duplicate") == true)
                            {
                                //lbl_cc.Visible = true;
                                //lbl_sc.Visible = true;
                            }
                            string[] arr = ss.Split('|');
                            Session["id"] = arr[0].ToUpper().ToString();
                            ss = arr[0].ToUpper().ToString();
                            if (arr.Length == 2)
                            {
                                Session["Recpt_no"] = arr[1].ToUpper().ToString().Trim();
                            }
                            else
                            {
                                Session["Recpt_no"] = "";
                            }


                        }

                        else
                        {
                            Session["Recpt_no"] = "";
                        }

                        lblstudentid.Text = id;
                        DataSet dsGrpID = c1.fill_dataset("select a.group_id,g.Group_title from dbo.m_std_studentacademic_tbl a,dbo.m_crs_subjectgroup_tbl g where a.group_id=g.Group_id and  stud_id='" + id + "' and a.del_flag=0 and a.ayid=(select MAX(ayid) from dbo.m_academic)");

                        if (dsGrpID.Tables[0].Rows.Count > 0)
                        {

                         

                            string st = "select  a.stud_id,(stud_F_Name+' '+stud_M_Name+' '+stud_L_Name) as Name,d.Group_title as course,stud_Category as category,SUM(amount) as fees,b.Ayid from m_std_personaldetails_tbl as a,m_std_studentacademic_tbl as c,m_FeeEntry as b,m_crs_subjectgroup_tbl as d where a.stud_id='" + id + "' and a.stud_id=b.Stud_id and b.Ayid=(select Ayid from m_academic where IsCurrent=1) and b.Stud_id=c.stud_id and c.ayid=b.Ayid and c.group_id=d.group_id group by a.stud_id,stud_F_Name,stud_M_Name,stud_L_Name,Group_title,stud_Category,b.Ayid";
                            DataSet ds5 = c1.fill_dataset(st);

                            if (ds5.Tables[0].Rows.Count > 0)
                            {
                                //tab_category.Visible = true;
                                //tab_category2.Visible = true;
                                lbl_category_1.Text = ds5.Tables[0].Rows[0]["category"].ToString();
                                // tab_other_desc.Visible = true;
                                //tab_other_desc2.Visible = true;
                                //if (ds.Tables[0].Rows[0]["STUD_CATEGORY"].ToString() == "OPEN")
                                //{
                                //    tab_category.Visible = false;
                                //    tab_category2.Visible = false;
                                //}

                            }
                            else
                            {
                                // tab_other_desc2.Visible = false;
                                //tab_other_desc.Visible = false;
                                //tab_category.Visible = false;
                                //tab_category2.Visible = false;
                                lbl_category_1.Text = "OPEN";
                            }


                            
                            QRCodeEncoder encoder = new QRCodeEncoder();

                            encoder.QRCodeScale = 5;
                            //string path = "E:\\website\\staff\\images\\";
                            //string img_path = "E:\\website\\staff\\images\\";
                            //string path = "E:\\inetpub\\wwwroot\\student_appliedart\\images\\";
                            //string img_path = "E:\\inetpub\\wwwroot\\student_appliedart\\images\\";
                            string s = "";

                            s = "Student ID : " + id + Environment.NewLine;
                            s = s + "STUDENT NAME : " + ds5.Tables[0].Rows[0]["name"].ToString() + Environment.NewLine;



                            //Bitmap img = encoder.Encode(s);
                            //System.Drawing.Image logo = System.Drawing.Image.FromFile(path + "vivalogo.png");

                            //int left = (img.Width / 2) - (logo.Width / 2);

                            //int top = (img.Height / 2) - (logo.Height / 2);
                            //Graphics g = Graphics.FromImage(img);
                            //g.DrawImage(logo, new Point(left, top));
                            //img.Save(img_path + "img_" + ss.ToString() + ".jpg", ImageFormat.Jpeg);


                            //qr_code.ImageUrl = "img.jpg";
                            //qr_code1.ImageUrl = "img.jpg";


                          
                            long total1 = Convert.ToInt32(ds5.Tables[0].Rows[0]["fees"].ToString());
                           // total1 = total1 + 100;
                            // lbl_date1.Text = ds.Tables[0].Rows[0]["max_pay"].ToString();
                            lbl_date1.Text = postingdate;
                            long total2 = Convert.ToInt32(ds5.Tables[0].Rows[0]["fees"].ToString());
                          //  total2 = total2 + 100;
                            //lbl_no_1.Text = Session["UserName"].ToString();
                            lbl_amount_1.Text = ConvertNumbertoWords(total2) + " ONLY";
                            lbl_name_1.Text = ds5.Tables[0].Rows[0]["name"].ToString();
                            // lbl_course_1.Text = ds.Tables[0].Rows[0]["Group_title"].ToString();
                            lbl_no_1.Text = trans_id;
                            //lbl_stud_id_1.Text = ds.Tables[0].Rows[0]["id"].ToString();
                       
                            lbltransaction_id.Text = postingmmp_txn;
                            lblstatus1.Text = "Payment Successful";
                            lblcourse.Text = dsGrpID.Tables[0].Rows[0]["Group_title"].ToString();

                            if (postingdiscriminator == "NB")
                            {
                                lblmode.Text = "Net Banking";
                            }
                            else if (postingdiscriminator == "CC")
                            {
                                lblmode.Text = "Credit Cards";
                            }
                            else if (postingdiscriminator == "DC")
                            {
                                lblmode.Text = "Debit Cards";
                            }
                            else if (postingdiscriminator == "IM")
                            {
                                lblmode.Text = "IMPS";
                            }
                            else if (postingdiscriminator == "MX")
                            {
                                lblmode.Text = "AMERICAN EXPRESS CARDS";
                            }
                            else if (postingdiscriminator == "BQ")
                            {
                                lblmode.Text = "BHARAT QR";
                            }
                            lblamountdigits.Text = total2.ToString();
                            lblvivatransction.Text = postingmer_txn;
                            lblbank.Text = postingbank_name;
                        
                        }
                            }
            }
                          
                        

                        else
                        {
                            //if (postingf_code == "C" || postingf_code == "F")
                            //{
                            //    lblstatus1.Text = "Payment Unsuccessful";
                            //}
                            //lbltransaction_id.Text = postingmmp_txn;
                            //lblvivatransction.Text = postingmer_txn;
                            //lbl_date1.Text = postingdate;
                            ////receipt.Visible = false;
                            ////tab_category2.Visible = false;
                            ////received_date.Visible = false;
                            ////amount.Visible = false;
                            ////words.Visible = false;
                            ////mode.Visible = false;
                            ////bankname.Visible = false;
                            ////group.Visible = false;
                            ////lblstudentid.Visible = false;
                            ////qrcode.Visible = false;
                            //// divmsg.InnerHtml = "Details not found";
                            string subcourse = "select * from m_crs_subjectgroup_tbl where group_id='GRP" + id.Substring(5, 3) + "'";
                            DataSet dt = c1.fill_dataset(subcourse);
                            string group_id = dt.Tables[0].Rows[0]["group_id"].ToString();
                            string formno = id;
    //                        string str1 = "select ISNULL(f_name,'')+' '+ISNULL(M_name,'')+' '+ISNULL(L_name,'') as name,Category, Group_title as course,f.faculty_name,b.group_id,Group_title,status,acdid,(select sum(cast(term1 as int)) from Fee_structure_master where ayid=a.ACDID"
    //+ " and group_id=b.group_id) as Amount,(select sum(cast(term1 as int)) from Fee_structure_master where ayid=a.ACDID"
    //+ " and group_id=b.group_id) - (select sum(paid_amt) from Fee_details where ayid=a.ACDID and stud_id=a.stud_id and del_flag is null) as balance_amt "
    //                    + "    from d_adm_applicant_online a,OLA_FY_adm_CourseSelection b,m_crs_subcourse_tbl c,m_crs_course_tbl d,m_crs_subjectgroup_tbl e,dbo.m_crs_faculty f where a.Form_no=b.formno and  "
    //                      + "      f.faculty_id=d.faculty_id and b.group_id=e.Group_id and c.course_id=d.course_id and c.subcourse_id=e.Subcourse_id and a.Form_no='" + formno + "' and a.acdid='" + Session["ayid"] + "' and b.group_id='" + group_id + "'";
                            string str1="SELECT A.Category,A.F_name+' '+A.M_name+' '+A.L_name AS NAME,b.group_id,d.course_name Course FROM d_adm_applicant A,OLA_FY_adm_CourseSelection b,m_crs_subjectgroup_tbl C ,m_crs_course_tbl d,m_crs_subcourse_tbl e WHERE Form_no='"+formno.Substring(0,5).ToString()+"' AND A.Form_no=B.formno AND B.group_id=C.Group_id and c.Subcourse_id=e.subcourse_id and e.course_id=d.course_id ";
                            DataSet ds = c1.fill_dataset(str1);
                            lblstudentid.Text = id.ToUpper();
                            lbl_name_1.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
                            lblcourse.Text = ds.Tables[0].Rows[0]["Course"].ToString();
                            
                            lbl_category_1.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                            long total1 = Convert.ToInt32(postinamount.ToString().Split('.')[0]);
                            lbl_date1.Text = postingdate;
                            long total2 = Convert.ToInt32(postinamount.ToString().Split('.')[0]);
                            lbl_amount_1.Text = ConvertNumbertoWords(total2) + " ONLY";
                            
                            //lbl_b.Text = ds.Tables[0].Rows[0]["balance_amt"].ToString();
                            lbltransaction_id.Text = postingmmp_txn;
                            
                            lblamountdigits.Text = total2.ToString();
                            lblvivatransction.Text = postingmer_txn.ToUpper();

                            if (postingf_code == "F")
                            {
                                if (postingdiscriminator == "NB")
                                {
                                    lblmode.Text = "NET BANKING";
                                }
                                else if (postingdiscriminator == "CC")
                                {
                                    lblmode.Text = "CREDIT CARD";
                                }
                                else if (postingdiscriminator == "DC")
                                {
                                    lblmode.Text = "DEBIT CARD";
                                }
                                else if (postingdiscriminator == "IM")
                                {
                                    lblmode.Text = "IMPS";
                                }
                                else if (postingdiscriminator == "MX")
                                {
                                    lblmode.Text = "AMERICAN EXPRESS CARD";
                                }
                                else
                                {
                                    lblmode.Text = "--";
                                }
                                lbl_no_1.Text = "--";
                                lblmode.Text = "--";
                                lblbank.Text = "--";
                                //lblbank.Text = postingbank_name.ToUpper();
                                lblstatus1.Text = "UNSUCCESSFUL";
                            }
                            else
                            {
                                lblmode.Text = "--";
                                lblbank.Text = "--";
                                lblstatus1.Text = "CANCELLED";
                            }
                        }
}
            }
    

     //   }

       // catch (Exception ex)
       // {
//Response.Redirect("http://203.192.254.34/STUDENT_ERP/FEE_RECIEPT_COPY.ASPX");
        //}
    }
  
    public static string byteToHexString(byte[] byData)
    {
        StringBuilder sb = new StringBuilder((byData.Length * 2));
        for (int i = 0; (i < byData.Length); i++)
        {
            int v = (byData[i] & 255);
            if ((v < 16))
            {
                sb.Append('0');
            }

            sb.Append(v.ToString("X"));

        }

        return sb.ToString();
    }
    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKHS ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "") words += "AND ";
            var unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
            var tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }
        return words;
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
            //plBarCode2.Controls.Add(imgBarCode);

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
            //plBarCode1.Controls.Add(imgBarCode);

        }
    }
}