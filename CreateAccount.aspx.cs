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
        public string Account;
        public string Password;
        public string Email;

        public UserData()
        {
            Account = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UserData vData = new UserData();

            vData.Account = Request.QueryString["Account"];
            vData.Password = Request.QueryString["Password"];
            vData.Email = Request.QueryString["Email"];

            if (vData.Account == null || vData.Password == null || vData.Email == null)
            {
                Response.Write("99");
            }
            else
            {
                if (CheckAccount(vData) == false)
                    Response.Write("1");
                else if (CheckEmail(vData) == false)
                    Response.Write("2");
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
        string vSQLStr = "INSERT INTO UserAccount(Account,Password,Email) VALUES('" + vData.Account + "','" + vData.Password +
"','" + vData.Email + "')";

        using (SqlConnection vCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database = Test"))
        {
            vCon.Open();

            using (SqlCommand cmd = new SqlCommand(vSQLStr, vCon))
            {
                cmd.ExecuteNonQuery();
            }
        }
        Response.Write("0");
    }

    private bool CheckEmail(UserData vData)
    {
        string vSQLStr = "Select * FROM UserAccount WHERE Email='" + vData.Email + "'";
        bool vFind = false;

        using (SqlConnection vCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database = Test"))
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

    private bool CheckAccount(UserData vData)
    {
        string vSQLStr = "Select * FROM UserAccount WHERE Account='" + vData.Account + "'";

        bool vFindAccount = false;

        using (SqlConnection vCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database = Test"))
        {
            vCon.Open();

            using (SqlCommand vCmd = new SqlCommand(vSQLStr, vCon))
            {
                SqlDataReader vRd = vCmd.ExecuteReader();

                while (vRd.Read())
                {
                    vFindAccount = true;
                    break;
                }

                vRd.Close();
            }

            if (vFindAccount == true)
                return false;
            else
                return true;
        }

    }

}