using System;
using System.Data.SqlClient;


public partial class AddCustomerMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string vName = Request.QueryString["Name"].ToString();
            string vEmail = Request.QueryString["Email"].ToString();
            string vPhone = Request.QueryString["Phone"].ToString();
            string vContent = Request.QueryString["MessageContent"].ToString();

            try
            {
                string vStr = "INSERT INTO CustomerMessage(Name,Email,Phone,Message) VALUES(N'" + vName +
                                "','" + vEmail + "','" + vPhone + "',N'" + vContent + " ')";

                using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
                {
                    vCon.Open();
                    using (SqlCommand vCmd = new SqlCommand(vStr, vCon))
                    {
                        vCmd.ExecuteNonQuery();
                    }
                }
                Response.Write("0");
            }
            catch
            {
                Response.Write("1");
            }

        }
        catch
        {
            Response.Write("99");
        }
    }
}