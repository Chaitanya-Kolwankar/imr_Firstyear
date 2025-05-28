using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instruction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_next_Click(object sender, EventArgs e)
    {
        if (chk_agree.Checked)
        {

            Response.Redirect("WebReport.aspx");
        }
        else
        {
            div_remark.Visible = true;
        }
    }
}