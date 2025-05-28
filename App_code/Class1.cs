using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;



/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    SqlCommand cmd=new SqlCommand();
    SqlDataAdapter da;
    DataSet ds=new DataSet();
      //sy_model data = new sy_model();

 public   SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
	public Class1()
	{
		
	}
    public void Conn()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
            con.Open();
        }
        else
        {
            con.Open();
        }

    }
    public void con_close()
    {
        con.Close();
    }
    public string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }

    public DataTable fill_datatable(string qry)
    {
        cmd = new SqlCommand(qry, con);
        Conn();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds.Tables[0];
    }
 
    public string Decryptdata(string encryptpwd)
    {
        string decryptpwd = string.Empty;
        UTF8Encoding encodepwd = new UTF8Encoding();
        Decoder Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }


    public DataSet fill_dataset(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        Conn();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        
        da.Fill(ds);
       
        con.Close();
        return ds;
    }
    public bool insert_data(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insert_www_m_std_personaldetails_tbl";


        return true;


    }
    public string bulk_insert_for_applicant(string s1, string type)
    {
        SqlCommand cmd = new SqlCommand();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        else
        {
            con.Close();
            con.Open();
        }
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insert_www_d_adm_Applicant_bulk";
        string q_type = type;
        cmd.Parameters.AddWithValue("@type", q_type);
        cmd.Parameters.AddWithValue("@ins_query", s1);
        string message = cmd.ExecuteScalar().ToString();
        con.Close();
        return message;
    }
    public SqlDataReader RetriveQuery(String strQuery)
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = strQuery;
            cmd.CommandType = CommandType.Text;
            con.Close();

            con.Open();
            SqlDataReader rd;
            rd = cmd.ExecuteReader();

            
           
            return rd;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool ins_barcode_applicant(string formno, byte[] barcode, string code, string ayid)
    {
        SqlCommand cmd = new SqlCommand();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        else
        {
            con.Close();
            con.Open();
        }
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "OLA_Ins_barcode";

        cmd.Parameters.Add("@form_no", SqlDbType.VarChar, 5).Value = formno;

        cmd.Parameters.Add("@barcode", SqlDbType.Image).Value = barcode;

        cmd.Parameters.Add("@code", SqlDbType.VarChar, 3).Value = code;

        cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 5).Value = ayid;

        bool b;
        if (cmd.ExecuteNonQuery() >= 1)
        {
            b = true;
        }
        else
        {
            b = false;
        }
        //string message =
        con.Close();
        return b;
    }

    public DataTable get_barcode(string formno, string code, string ayid)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "OLA_Get_applicant_barcode_FY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        Conn();
        cmd.Parameters.Add("@formno", SqlDbType.VarChar, 5).Value = formno;
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 5).Value = code;
        cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 5).Value = ayid;

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds);

        con.Close();
        return ds.Tables[0];
    }

    public bool insert_data_app(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        if (con.State == ConnectionState.Open)
        {
            con.Close();
            con.Open();
        }
        else
        {
            con.Open();
        }
        if (cmd.ExecuteNonQuery() > 0)
        {
            con.Close();
            return true;

        }
        else
        {
            con.Close();
            return false ;
 
        }
        


    }
    public bool delete_data(string qry)
    {
        try
        {
            
            cmd = new SqlCommand();
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            Conn();
            cmd.ExecuteNonQuery();
            
            con.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //public string  ins_updt_pic_applicant(string formno,byte[] photo,byte[] sign, string type,string ayid)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    if (con.State == ConnectionState.Closed)
    //    {
    //        con.Open();
    //    }
    //    else
    //    {
    //        con.Close();
    //        con.Open();
    //    }
    //    cmd.Connection = con;
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "OLA_Ins_updt_pic";
    //    string q_type = type;
    //    cmd.Parameters.Add("@form_no", SqlDbType.VarChar, 5).Value = formno;
    //    if (photo != null)
    //    {
    //        cmd.Parameters.Add ("@stud_photo",SqlDbType.Image ).Value = photo;
    //    }
    //    else
    //    {
    //        cmd.Parameters.Add("@stud_photo", SqlDbType.Image).Value = DBNull.Value;

    //    }
    //    cmd.Parameters.Add("@Stud_Sign", SqlDbType.Image).Value = sign ;
    //    cmd.Parameters.Add("@type", SqlDbType.VarChar, 5).Value = type ;
    //    cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 5).Value = ayid ;


    //    cmd.ExecuteNonQuery();
    //       //string message =
    //    con.Close();
    //    return "hi";
    //}
  
    public void SetComboBoxForMemberConditional(DropDownList cbo, string TABLE_NAME, string DATA_COLUMN, string VALUE_COLUMN, string Condition)
    {
        try
        {
            
            SqlDataAdapter objAdapter = default(SqlDataAdapter);
            DataSet objDataSet = default(DataSet);
            string Query = "";

            if (VALUE_COLUMN.Length > 0)
            {
                VALUE_COLUMN = "," + VALUE_COLUMN;
            }



            Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME + " WHERE " + Condition;


            //MsgBox(Query)



            objAdapter = new SqlDataAdapter(Query, con );
            objDataSet = new DataSet();
            //a = objDataSet.Tables(0).NewRow()
            objAdapter.Fill(objDataSet);
            DataRow drr = objDataSet.Tables[0].NewRow();
            drr[0] = "--SELECT--";
            objDataSet.Tables[0].Rows.InsertAt(drr, 0);

            cbo.DataSource = objDataSet.Tables[0];
            cbo.DataTextField = objDataSet.Tables[0].Columns[0].ToString();

            cbo.DataValueField = objDataSet.Tables[0].Columns[1].ToString();
            cbo.SelectedIndex = -1;
            cbo.DataBind();
            //sqlcon.Close();
        }



        catch (Exception ex)
        {

        }

    }

    public void SetComboBoxForMemberConditional(DropDownList cbo, string query, string DATA_COLUMN, string VALUE_COLUMN)
    {
        try
        {

            SqlDataAdapter objAdapter = default(SqlDataAdapter);
            DataSet objDataSet = default(DataSet);
            string Query = "";

            
            Query = query ;


            //MsgBox(Query)



            objAdapter = new SqlDataAdapter(Query, con);
            objDataSet = new DataSet();
            //a = objDataSet.Tables(0).NewRow()
            objAdapter.Fill(objDataSet);
            DataRow drr = objDataSet.Tables[0].NewRow();
            drr[0] = "--SELECT--";
            objDataSet.Tables[0].Rows.InsertAt(drr, 0);
            cbo.DataTextField = DATA_COLUMN;

            cbo.DataValueField =VALUE_COLUMN;
            cbo.SelectedIndex = -1;
            cbo.DataSource = objDataSet.Tables[0];
                cbo.DataBind();
            //cbo.DataSource = objDataSet.Tables[0];
            //cbo.DataTextField = DATA_COLUMN;

            //cbo.DataValueField =VALUE_COLUMN;
            //cbo.SelectedIndex = -1;
            //cbo.DataBind();
            //sqlcon.Close();
        }



        catch (Exception ex)
        {

        }

    }


    //public string ins_register(string fname, string mname, string lname, string moname, string prefaculty, string subcoursename, string group_id, string mob, string dob, string psswd, int out_of, int marksObtain, string percent, string ayid, string emailid, string seat_no, string pass_month, string pass_year, string is_diploma, string sem1, string sem_2, string sem3, string sem4, int type)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    if (con.State == ConnectionState.Closed)
    //    {
    //        con.Open();
    //    }
    //    else
    //    {
    //        con.Close();
    //        con.Open();
    //    }
    //    cmd.Connection = con;
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "OLA_register";

    //    cmd.Parameters.Add("@fname", SqlDbType.VarChar, 25).Value = fname;

    //    cmd.Parameters.Add("@mname", SqlDbType.VarChar, 25).Value = mname;

    //    cmd.Parameters.Add("@lname", SqlDbType.VarChar, 25).Value = lname;

    //    cmd.Parameters.Add("@mo_name", SqlDbType.VarChar, 25).Value = moname;
    //    //--
    //    cmd.Parameters.Add("@prefaculty", SqlDbType.VarChar, 25).Value = prefaculty;
    //    //--
    //    cmd.Parameters.Add("@subcourse_name", SqlDbType.VarChar, 50).Value = subcoursename;
    //    //--
    //    cmd.Parameters.Add("@group_id", SqlDbType.VarChar, 6).Value = group_id;

    //    cmd.Parameters.Add("@mob", SqlDbType.VarChar, 50).Value = mob;

    //    cmd.Parameters.Add("@dob", SqlDbType.VarChar, 50).Value = dob;

    //    cmd.Parameters.Add("@passwd", SqlDbType.VarChar, 50).Value = psswd;

    //    //--
    //    cmd.Parameters.Add("@Out_of", SqlDbType.Int).Value = out_of;
    //    //--
    //    cmd.Parameters.Add("@Marks_obtained", SqlDbType.Int).Value = marksObtain;
    //    //--
    //    cmd.Parameters.Add("@Percentage", SqlDbType.VarChar, 20).Value = percent;



    //    cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 50).Value = ayid;

    //    cmd.Parameters.Add("@email_id", SqlDbType.VarChar, 50).Value = emailid;

    //    cmd.Parameters.Add("@seat_no", SqlDbType.VarChar, 50).Value = seat_no;

    //    cmd.Parameters.Add("@pass_month", SqlDbType.VarChar, 10).Value = pass_month;

    //    cmd.Parameters.Add("@pass_year", SqlDbType.VarChar, 10).Value = pass_year;

    //    //--
    //    cmd.Parameters.Add("@is_diploma", SqlDbType.VarChar, 50).Value = is_diploma;
    //    //--
    //    cmd.Parameters.Add("@SEM_1", SqlDbType.VarChar, 50).Value = sem1;
    //    //--
    //    cmd.Parameters.Add("@SEM_2", SqlDbType.VarChar, 50).Value = sem_2;
    //    //--
    //    cmd.Parameters.Add("@SEM_3", SqlDbType.VarChar, 50).Value = sem3;
    //    //--
    //    cmd.Parameters.Add("@SEM_4", SqlDbType.VarChar, 50).Value = sem4;

    //    //--
    //    cmd.Parameters.Add("@applicant_type", SqlDbType.Int).Value = type;

    //    string message = cmd.ExecuteScalar().ToString();
    //    con.Close();
    //    string s= con.WorkstationId;
    //    return message;
    //}

    public string insrt_registar(sy_model data)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.OLA_register";

            cmd.Parameters.Add("@fname", SqlDbType.VarChar, 25).Value = data.f_name;

            cmd.Parameters.Add("@mname", SqlDbType.VarChar, 25).Value = data.m_name;

            cmd.Parameters.Add("@lname", SqlDbType.VarChar, 25).Value = data.l_name;

            cmd.Parameters.Add("@mo_name", SqlDbType.VarChar, 25).Value = data.mo_name;
            //--
            //cmd.Parameters.Add("@prefaculty", SqlDbType.VarChar, 25).Value = data.prefaculty;
            //--
            //cmd.Parameters.Add("@subcourse_name", SqlDbType.VarChar, 50).Value = data.subcourse_name;
            //--
            //cmd.Parameters.Add("@group_id", SqlDbType.VarChar, 6).Value = data.group_id;

            cmd.Parameters.Add("@dob", SqlDbType.VarChar, 50).Value = data.dob;

            cmd.Parameters.Add("@mob", SqlDbType.VarChar, 50).Value = data.mob_no;         

            cmd.Parameters.Add("@passwd", SqlDbType.VarChar, 50).Value = data.passwd;

            //--
            //cmd.Parameters.Add("@Out_of", SqlDbType.Int).Value = 0;
            //--
            //cmd.Parameters.Add("@Marks_obtained", SqlDbType.Int).Value = 0;
            //--
           // cmd.Parameters.Add("@Percentage", SqlDbType.VarChar, 20).Value = data.Percentage;

            cmd.Parameters.Add("@ayid", SqlDbType.VarChar, 50).Value = data.ayid;

            cmd.Parameters.Add("@email_id", SqlDbType.VarChar, 50).Value = data.email_id;

            //cmd.Parameters.Add("@seat_no", SqlDbType.VarChar, 50).Value = data.seat_no;

            //cmd.Parameters.Add("@pass_month", SqlDbType.VarChar, 10).Value = data.pass_month;

            //cmd.Parameters.Add("@pass_year", SqlDbType.VarChar, 10).Value = data.pass_year;

            ////--
            //cmd.Parameters.Add("@is_diploma", SqlDbType.VarChar, 50).Value = data.is_diploma;
            ////--
            //cmd.Parameters.Add("@SEM_1", SqlDbType.VarChar, 50).Value = data.SEM_1;
            ////--
            //cmd.Parameters.Add("@SEM_2", SqlDbType.VarChar, 50).Value = data.SEM_2;
            ////--
            //cmd.Parameters.Add("@SEM_3", SqlDbType.VarChar, 50).Value = data.SEM_3;
            ////--
            //cmd.Parameters.Add("@SEM_4", SqlDbType.VarChar, 50).Value = data.SEM_4;
            //--
            cmd.Parameters.Add("@applicant_type", SqlDbType.VarChar, 50).Value = data.applicant_type;


            string message = cmd.ExecuteScalar().ToString();
            con.Close();
            return message;
        }
        catch (Exception ex)
        {
            return "fail";
        }
    }


    public DataSet outlogin(string id, string password)
    {
        DataSet ds =new DataSet();
        DataSet ds1;
        DataTable dt;
        dt = fill_datatable("select max(ayid) as 'ayid' from dbo.m_academic");

        ds1 = fill_dataset("select applicant_type,passwd from adm_applicant_registration where formno='" + id + "' and passwd='" + password + "' ");


        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0]["passwd"].ToString().Equals(password))
            {
                //ds = con.fill_dataset("Select ent.formno,app.f_name,app.m_name,app.l_name,app.mob_no,app.Mo_name,app.Phone_No,convert(varchar(max),app.DOB,105) as DOB,ent.passwd,app.email_id,app.Is_Inhouse,app.Prev_Stud_Id,app.Branch,app.Univ_Enrol_no,app.Stud_Class from d_adm_applicant app ,dbo.adm_applicant_registration ent where app.form_no=ent.formno and ACDID = (select max(ayid) from dbo.m_academic) and form_no='" + id + "' and app.del_flag=0");
                ds = fill_dataset("Select app.*,ent.passwd,ent.formno,ent.seat_no,ent.Out_of as reg_outOf,ent.Marks_obtained as reg_marksObt,ent.Percentage as reg_perct,ent.pass_month,ent.pass_year,ent.SEM_1 as reg_sem1,ent.SEM_2 as reg_sem2,ent.SEM_3 as reg_sem3,ent.SEM_4 as reg_sem4,app.fyi_Institute_name,app.fyi_Institute_place,fy_sem1_sgpi,fy_sem2_sgpi,fy_sem1_CR,fy_sem2_CR,fy_sem1_cg,fy_sem2_cg,fy_sem1_obtain_mks,fy_sem2_obtain_mks,fy_sem1_total_mks,fy_sem2_total_mks,fy_Institute_place,fy_university_name,pg_state,pg_board,pg_inst_name,pg_inst_place,pg_first_attempt,pg_passing_tear,pg_passing_month,pg_total_mks,pg_out_of_mks,pg_grade,pg_seat_no,ty_course from d_adm_applicant app ,dbo.adm_applicant_registration ent where app.form_no=ent.formno and ACDID = (select max(ayid) from dbo.m_academic) and form_no='" + id + "' and app.del_flag=0");

                //if (ds1.Tables[0].Rows[0]["applicant_type"].ToString() == "FY")
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        string str1 = "Select app.*,ent.passwd,ent.formno,ent.seat_no,ent.Out_of as reg_outOf,ent.Marks_obtained as reg_marksObt,ent.Percentage as reg_perct,ent.pass_month,ent.pass_year,ent.SEM_1 as reg_sem1,ent.SEM_2 as reg_sem2,ent.SEM_3 as reg_sem3,ent.SEM_4 as reg_sem4 from d_adm_applicant app ,dbo.adm_applicant_registration ent where app.form_no=ent.formno and ACDID = (select max(ayid) from dbo.m_academic) and form_no='" + id + "' and app.del_flag=0";
                //        str1 += "select * from hsc_previous_detail where hsc_seat_no='" + ds.Tables[0].Rows[0]["seat_no"].ToString() + "'";

                //        ds = fill_dataset(str1);
                //    }
                //}

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_submit = fill_datatable("select submit_dt from dbo.OLA_FY_adm_CourseSelection where formno = '" + id + "' and submit_dt is not null");


                    if (dt_submit.Rows.Count > 0)
                    {
                        ds.Tables[0].Columns.Add("is_submited");
                        ds.Tables[0].Rows[0]["is_submited"] = "Yes";
                        ds.Tables[0].Columns.Add("applicant_type");
                        ds.Tables[0].Rows[0]["applicant_type"] = ds1.Tables[0].Rows[0][0].ToString();
                        ds.Tables[0].Columns.Add("Inserted");
                        ds.Tables[0].Rows[0]["is_submited"] = "Yes";
                        ds.Tables[0].Columns.Add("ayid");
                        ds.Tables[0].Rows[0]["ayid"] = dt.Rows[0]["ayid"].ToString();

                    }
                    else
                    {
                        ds.Tables[0].Columns.Add("is_submited");
                        ds.Tables[0].Rows[0]["is_submited"] = "No";
                        ds.Tables[0].Columns.Add("applicant_type");
                        ds.Tables[0].Rows[0]["applicant_type"] = ds1.Tables[0].Rows[0][0].ToString();
                        ds.Tables[0].Columns.Add("Inserted");
                        ds.Tables[0].Rows[0]["Inserted"] = "Yes";
                        ds.Tables[0].Columns.Add("ayid");
                        ds.Tables[0].Rows[0]["ayid"] = dt.Rows[0]["ayid"].ToString();

                    }

                    return ds;

                }
                else
                {
                    //string str = "select formno,f_name,m_name,l_name,mo_name,convert(varchar(max),dob,105) as DOB,mob_no,passwd,email_id,seat_no from dbo.adm_applicant_registration as app  where formno='" + id + "' and app.del_flag=0 and ayid=(select max(ayid) from dbo.m_academic)";
                    //if (ds1.Tables[0].Rows[0]["applicant_type"].ToString() == "FY")
                    //{
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        str += "select * from hsc_previous_detail where hsc_seat_no='" + ds.Tables[0].Rows[0]["seat_no"].ToString() + "'";
                    //        ds = fill_dataset(str);
                    //    }
                    //}

                    //ds = fill_dataset(str);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                        ds.Tables[0].Columns.Add("is_submited");
                        ds.Tables[0].Rows[0]["is_submited"] = "No";
                        ds.Tables[0].Columns.Add("applicant_type");
                        ds.Tables[0].Rows[0]["applicant_type"] = ds1.Tables[0].Rows[0][0].ToString();
                        ds.Tables[0].Columns.Add("Inserted");
                        ds.Tables[0].Rows[0]["Inserted"] = "No";
                        ds.Tables[0].Columns.Add("ayid");
                        ds.Tables[0].Rows[0]["ayid"] = dt.Rows[0]["ayid"].ToString();

                        return ds;

                    }
                    else
                    {
                        ds.Tables.Add();
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ds.Tables[0].Columns.Add();
                        ds.Tables[0].Rows[0][0] = "User ID Does Not Exist";
                        return ds;
                        //return this.Request.CreateResponse(HttpStatusCode.OK, "User ID Does Not Exist", "application/json");
                    }
                }
            }
            else
            {             
                ds.Tables.Add();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                ds.Tables[0].Columns.Add();
                ds.Tables[0].Rows[0][0] = "Password Does Not Match";
                return ds;
                //return this.Request.CreateResponse(HttpStatusCode.OK, "Password Does Not Match", "application/json");
            }
        }
        else
        {
            ds.Tables.Add();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            ds.Tables[0].Columns.Add();
            ds.Tables[0].Rows[0][0] = "User ID Does Not Exist";
            return ds;
           // return this.Request.CreateResponse(HttpStatusCode.OK, "User ID Does Not Exist", "application/json");
        }
    }
    public bool update_data(string qry)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            Conn();
            cmd.ExecuteNonQuery();
            con_close();
            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
