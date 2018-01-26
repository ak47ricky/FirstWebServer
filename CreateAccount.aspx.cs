using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateAccount : System.Web.UI.Page
{
    public class UserData
    {
        public string Password;
        public string Email;

        public UserData()
        {
            Password = string.Empty;
            Email = string.Empty;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UserData vData = new UserData();

            vData.Password = Request.QueryString["Password"];
            vData.Email = Request.QueryString["Email"];

            if (vData.Password == null || vData.Email == null)
            {
                Response.Write("99");
            }
            else
            {
                if (CheckEmail(vData) == false)
                    Response.Write("1");
                else
                    IntoAccount(vData);
            }

        }
        catch
        {

        }
    }
    //把帳號寫入SQL
    private void IntoAccount(UserData vData)
    {
        string vSQLStr = "INSERT INTO UserAccount(Password,Email) VALUES('" + vData.Password +
"','" + vData.Email + "')";

        using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            vCon.Open();

            using (SqlCommand cmd = new SqlCommand(vSQLStr, vCon))
            {

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    
                }

                //cmd.ExecuteNonQuery();
            }
        }
        Response.Write("0");
    }

    private bool CheckEmail(UserData vData)
    {
        string vSQLStr = "Select * FROM UserAccount WHERE Email='" + vData.Email + "'";
        bool vFind = false;

        using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;database=RickyDataBase;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            vCon.Open();

            using (SqlCommand vCmd = new SqlCommand(vSQLStr, vCon))
            {
                SqlDataReader vRd = vCmd.ExecuteReader();

                while (vRd.Read())
                {
                    vFind = true;
                    break;
                }

                vRd.Close();
            }
        }

        if (vFind == true)
            return false;
        else
            return true;
    }

    //private bool CheckAccount(UserData vData)
    //{
    //    string vSQLStr = "Select * FROM UserAccount WHERE Account='" + vData.Account + "'";

    //    bool vFindAccount = false;

    //    using (SqlConnection vCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database = Test"))
    //    {
    //        vCon.Open();

    //        using (SqlCommand vCmd = new SqlCommand(vSQLStr, vCon))
    //        {
    //            SqlDataReader vRd = vCmd.ExecuteReader();

    //            while (vRd.Read())
    //            {
    //                vFindAccount = true;
    //                break;
    //            }

    //            vRd.Close();
    //        }

    //        if (vFindAccount == true)
    //            return false;
    //        else
    //            return true;
    //    }

    //}

}