using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    public class NewAccount
    {
        public string Account;
        public string Password;
        public string Email;
        public string IPAddress;

        public NewAccount()
        {
            Account = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            IPAddress = string.Empty;
        }
    };


    protected void Page_Load(object sender, EventArgs e)
    {
        string vKind = string.Empty;

        NewAccount vAccount = new NewAccount();



        //0創角 1登入
        vKind = Request.QueryString["Kind"];
        vAccount.Account = Request.QueryString["Account"];
        vAccount.Password = Request.QueryString["Password"];
        vAccount.Email = Request.QueryString["Mail"];
        vAccount.IPAddress = Request.QueryString["IPAddress"];
        if (vKind == "0")
        {
            CheckAccount(vAccount);
        }
        else if (vKind == "1")
        {

            CheckNewAccount(vAccount);
        }
        else
        {

            Response.Write("99");
            //Response.Write("Kind Error , ReciveKind = " + vKind);
        }
    }

    private void CheckAccount(NewAccount vAccount)
    {
        string vSQLStr = "Select * FROM UserData WHERE(Account='" + vAccount.Account + "')";

        bool vFind = false;
        bool vPasswordSumbit = false;//密碼是否正確
        bool vUpadateIP = false;
        int vResult = -1;
        string vAddress = string.Empty;

        using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileRocky;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            vCon.Open();
            using (SqlCommand cmd = new SqlCommand(vSQLStr, vCon))
            {
                SqlDataReader dr = cmd.ExecuteReader();
            
                while (dr.Read())
                {
                    vFind = true;

                    string zPassword = dr["Password"].ToString();

                    if (vAccount.Password == zPassword)
                    {
                        vPasswordSumbit = true;
                        vAddress = dr["IPAddress"].ToString();

                        if (vAccount.IPAddress != vAddress)
                            vUpadateIP = true;
                    }
                        
                }
                dr.Close();
            }
            //密碼錯誤
            if (vFind == true && vPasswordSumbit == false)
            {
                vResult = 2;
            }
            else if (vFind == true && vPasswordSumbit == true)//密碼正確
            {
                vResult = 0;

                if(vUpadateIP == true)
                    UpdateIPAdress(vCon, vAccount);
            }
            else//找不到帳號
            {
                vResult = 3;
            }


            Response.Write(vResult);
        }
    }

    private void UpdateIPAdress(SqlConnection vCon,NewAccount vAccount)
    {
        string vSQLUpdate = "UPDATE UserData SET IPAddress='"+ vAccount.IPAddress + "' WHERE (Account='" + vAccount.Account +"')";

        using (SqlCommand cmd = new SqlCommand(vSQLUpdate, vCon))
        {
            cmd.ExecuteNonQuery();
        }
    }

    private void CheckNewAccount(NewAccount vAccount)
    {
        string vSQLStr = "Select * FROM UserData WHERE (Account='" + vAccount.Account+"')";
        //是否有找到同樣帳號
        bool vFind = false;

        using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            vCon.Open();

            using (SqlCommand cmd = new SqlCommand(vSQLStr, vCon))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    vFind = true;//有重複的
                }

                dr.Close();

            }

            if (vFind == true)
            {
                Response.Write("1");//這帳號重複
            }
            else
            {
                //將帳號寫入
                string vInsertStr = "INSERT INTO UserData(Account,Password,Mail,IPAddress) " + 
                                     "VALUES('" + vAccount.Account + "','" + vAccount.Password + "','"
                                     + vAccount.Email + "','" + vAccount.IPAddress +"')";

                using (SqlCommand cmd = new SqlCommand(vInsertStr, vCon))
                {
                    cmd.ExecuteNonQuery();
                }

                Response.Write("0");
            }
        }
    }





}