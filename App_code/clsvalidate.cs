using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for clsvalidate
/// </summary>
public class clsvalidate
{
    public string check_db_null(object str)
    {
        if (str == DBNull.Value)
        {
            return "";
        }

        else
        {
            return str.ToString();
        }
    }

    public bool CheckName(string txt)
    {
        Regex reg = new Regex("^([a-zA-Z'\\s])+$");
        return reg.IsMatch(txt);
    }
    public bool CheckPhone(string txt)
    {
        Regex reg = new Regex("(^([0-9+-])+$)");
        return reg.IsMatch(txt);
    }
    public bool CheckAlphaNum(string txt)
    {
        Regex reg = new Regex("(^([a-zA-Z0-9-/])+$)");
        return reg.IsMatch(txt);
    }
    public bool CheckMobNo(string txt)
    {
        Regex reg = new Regex("(^[+]*\\d[0,2][- ]*\\d{5,13}?$)");
        return reg.IsMatch(txt);
    }
    public bool CheckNum(string txt)
    {
        Regex reg = new Regex("(^([0-9])+$)");
        return reg.IsMatch(txt);
    }

    public string replacequote(string a)
    {
        if (a.Contains("'"))
        {
            return a.Replace("'", "''");
        }
        else
        {
            return a;
        }
    }


    public bool CheckEmail(string s)
    {
        Regex reg = new Regex("^([0-9a-zA-Z]+[-._])*[0-9a-zA-Z]+@([0-9a-zA-Z]+[.])+[a-zA-Z]{2,3}$");
        return reg.IsMatch(s);
    }
    public bool CheckAddress(string s)
    {
        Regex reg = new Regex("^([a-zA-Z0-9]+[ ]{0,1}?[.,'/-:()]?[ ]?)+$");
        return reg.IsMatch(s);
    }
    public void DisableControls(Page p)
    {
        foreach (Control c in p.Controls)
        {
            if (c is TextBox)

                ((TextBox)c).Enabled = false;
            else if (c is ContentPlaceHolder )

                ((Button)c).Enabled = false;

            else if (c is Button)

                ((Button)c).Enabled = false;

            else if (c is RadioButton)

                ((RadioButton)c).Enabled = false;

            else if (c is ImageButton)

                ((ImageButton)c).Enabled = false;

            else if (c is CheckBox)

                ((CheckBox)c).Enabled = false;

            else if (c is DropDownList)

                ((DropDownList)c).Enabled = false;

            else if (c is HyperLink)

                ((HyperLink)c).Enabled = false;

        }
    }
    //^([a-zA-Z0-9]+[ ]{0,1}?[.,'/-:()]?[ ]?)+$
}
