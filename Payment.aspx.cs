using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
//using System.Web.Http;

public partial class Payment : System.Web.UI.Page
{
   // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
   // SqlCommand cmd;
   // SqlDataAdapter da;

    string MerchantLogin, MerchantPass, MerchantDiscretionaryData, ProductID, ClientCode, CustomerAccountNo, TransactionType, TransactionAmount, TransactionCurrency, TransactionServiceCharge, TransactionID, BankID;
    DateTime TransactionDateTime;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          if (!Page.IsPostBack)
            {

        string url = HttpContext.Current.Request.Url.AbsolutePath;
  string[] ss1 = url.Split('/');
TransactionAmount=ss1[3];
TransactionID=ss1[4];
CustomerAccountNo = ss1[5];
  TransferFund(MerchantLogin, MerchantPass, MerchantDiscretionaryData, ProductID, ClientCode, CustomerAccountNo, TransactionType, TransactionAmount, TransactionCurrency, TransactionServiceCharge, TransactionID, TransactionDateTime);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
       
      
    }
    public static void TransferFund(string MerchantLogin, string MerchantPass, string MerchantDiscretionaryData, string ProductID, string ClientCode, string CustomerAccountNo, string TransactionType, string TransactionAmount, string TransactionCurrency, string TransactionServiceCharge, string TransactionID, DateTime TransactionDateTime)
    {

         string strURL, strClientCode, strClientCodeEncoded;
        byte[] b;
        string strResponse = "";

        MerchantLogin = "65796";
        MerchantPass = "VIVA@123";
        //MerchantLogin = "197";
        //MerchantPass = "Test@123";
       TransactionType = "NBFundTransfer";
       ProductID = "MANAGEMENT";
       // ProductID = "NSE";
      //  TransactionID = "123";
        //TransactionAmount = "50";
        TransactionCurrency = "INR";
 		DateTime today = DateTime.Today;
        TransactionDateTime = today;
        //BankID = "2001";
        TransactionServiceCharge = "0";
        //MerchantDiscretionaryData = "DC";
  		ClientCode = "007";
        //CustomerAccountNo = "123456";

        //string ru = "http://localhost:19967/imr_fy/ResponseFundTransfer.aspx";  // try with local host//string ru = localhost:35652/Pages/FundTransferSuccess.aspx";
        string ru = "http://imr.vivacollege.in/imr_fy/ResponseFundTransfer.aspx";  // try with local host
 // string ru = "http://vivacollege.in/student/ResponseFundTransfer.aspx";  // try with local host
  //string ru = "http://asmitacampus.com/atom/ResponseFundTransfer.aspx";  // try with local host   





 // string ru =     "http://203.192.254.34/Admission_erp/Apply_Courses.aspx"; // try with local host


        //string ru = "http://203.192.254.34/Fundtransfersuccesspage.aspx";
 //ConfigurationManager.AppSettings["TransferURL"] = "https://payment.atomtech.in/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]ttype=[TransactionType]prodid=[ProductID]amt=[TransactionAmount]txncurr=    //[TransactionCurrency]txnscamt=[TransactionServiceCharge]clientcode=[ClientCode]txnid=[TransactionID]date=[TransactionDateTime]custacc=[CustomerAccountNo]ru=[ru]signature=[signature]";


  ConfigurationManager.AppSettings["TransferURL"] = "https://payment.atomtech.in/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]ttype=[TransactionType]prodid=[ProductID]amt=[TransactionAmount]txncurr=[TransactionCurrency]txnscamt=[TransactionServiceCharge]clientcode=[ClientCode]txnid=[TransactionID]date=[TransactionDateTime]custacc=[CustomerAccountNo]ru=[ru]signature=[signature]";
 //ConfigurationManager.AppSettings["TransferURL"] = "https://paynetzuat.atomtech.in/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]ttype=[TransactionType]prodid=[ProductID]amt=[TransactionAmount]txncurr=[TransactionCurrency]txnscamt=[TransactionServiceCharge]clientcode=[ClientCode]txnid=[TransactionID]date=[TransactionDateTime]custacc=[CustomerAccountNo]ru=[ru]signature=[signature]";

        try
        {
            b = Encoding.UTF8.GetBytes(ClientCode);
            strClientCode = Convert.ToBase64String(b);
            strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);
            strURL = "" + ConfigurationManager.AppSettings["TransferURL"].ToString();///
            strURL = strURL.Replace("[MerchantLogin]", MerchantLogin + "&");
            strURL = strURL.Replace("[MerchantPass]", MerchantPass + "&");
            strURL = strURL.Replace("[TransactionType]", TransactionType + "&");
            strURL = strURL.Replace("[ProductID]", ProductID + "&");
            strURL = strURL.Replace("[TransactionAmount]", TransactionAmount + "&");
            strURL = strURL.Replace("[TransactionCurrency]", TransactionCurrency + "&");
            strURL = strURL.Replace("[TransactionServiceCharge]", TransactionServiceCharge + "&");
            strURL = strURL.Replace("[ClientCode]", strClientCodeEncoded + "&");
            strURL = strURL.Replace("[TransactionID]", TransactionID + "&");
            strURL = strURL.Replace("[TransactionDateTime]", TransactionDateTime + "&");
            strURL = strURL.Replace("[CustomerAccountNo]", CustomerAccountNo + "&");
            //strURL = strURL.Replace("[MerchantDiscretionaryData]", MerchantDiscretionaryData + "&");
            //strURL = strURL.Replace("[BankID]", BankID + "&");
            strURL = strURL.Replace("[ru]", ru + "&");// Remove on Production

            //  string reqHashKey = requestkey;
            string reqHashKey = "d4715564ededc7cb3b";
           //string reqHashKey = "KEY123657234";
       
            string signature = "";
            string strsignature = MerchantLogin + MerchantPass + TransactionType + ProductID + TransactionID + TransactionAmount + TransactionCurrency;
            byte[] bytes = Encoding.UTF8.GetBytes(reqHashKey);
            byte[] bt = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
            // byte[] b = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(prodid));
            signature = byteToHexString(bt).ToLower();
            //ExceptionLogger.LogExceptionDetails(null, "[Log]" + signature);
            strURL = strURL.Replace("[signature]", signature);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls; //| SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // comparable to modern browsers

            HttpContext.Current.Response.Redirect(strURL, false);

        }
        catch (Exception ex)
        {
            //  ExceptionLogger.LogExceptionDetails(ex, null);
            throw ex;
        }

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
    protected void btn_response_Click(object sender, EventArgs e)
    {

    }
}