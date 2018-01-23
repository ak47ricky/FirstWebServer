using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string aAccount;
        string aPassword;

        try
        {
            aAccount = Request.QueryString["Acc"];
            aPassword = Request.QueryString["Pass"];

            string Get_Acc = DecodeString(aAccount);
            string Get_Pass = DecodeString(aPassword);

            CheckLogin(Get_Acc, Get_Pass);
        }
        catch
        {
            Response.Write("99");
        }
    }

    private void CheckLogin(string iAcc, string iPass)
    {
        //透過CLINET 傳過來的帳號密碼 來做登入的動作
        string aSQLStr = "Select * FROM UserData WHERE(Account='" + iAcc + "')";
        byte aCount = 0;

        using (SqlConnection aCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database=Test"))
        {
            aCon.Open();

            using (SqlCommand cmd = new SqlCommand(aSQLStr, aCon))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aCount++;
                    //近來表示有相同帳號，就要來判斷是否密碼正確
                    string aPassword = dr["Password"].ToString();

                    if (iPass == aPassword)
                    {
                        Response.Write("0");
                        return;
                    }
                    Response.Write("2");
                    return;
                }
                dr.Close();

                if (aCount <= 0)
                    Response.Write("1");
            }
        }
        return;
    }


    //Base64解密1
    public string DecodeString(string toDecrypt)
    {
        try
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(toDecrypt.Replace(" ", "+"));
            return Encoding.UTF8.GetString(encodedDataAsBytes);
        }
        catch (Exception ex)
        {
            //thorow new Exception();
            return "";
        }
    }
}