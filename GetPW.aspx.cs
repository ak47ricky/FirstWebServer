using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetPW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string aMail;

        try
        {
            aMail = Request.QueryString["Mail"];
            GetPassWord(aMail);
        }
        catch
        {
            Response.Write("2");
        }
    }

    private string GetPassWord(string iaMail)
    {
        //Password

        string aSqlStr = string.Format("Select Password FROM UserAccount WHERE Email = '{0}'", iaMail);

        string aPassWord = string.Empty;

        int aTotalCount = 0;

        using (SqlConnection aCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            aCon.Open();

            using (SqlCommand cmd = new SqlCommand(aSqlStr, aCon))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                
                while(dr.Read())
                {
                    aTotalCount++;
                    aPassWord = dr["Password"].ToString();
                }
                dr.Close();

                if(aTotalCount <=0)//沒有資料
                {
                    Response.Write("1");
                    return "";
                }

            }

            Response.Write(aPassWord);
        }

            return "";
    }
}
