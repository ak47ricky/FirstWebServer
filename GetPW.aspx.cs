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
        int aPlayerID;

        try
        {
            aPlayerID = int.Parse(Request.QueryString["PlayerID"]);
        }
        catch
        {
            Response.Write("2");
        }
    }

    private string GetPassWord(int iPlayerID)
    {
        //Password

        string aSqlStr = string.Format("Select Password FROM UserData WHERE Account = '{0}'",iPlayerID);

        string aPassWord = string.Empty;

        using (SqlConnection aCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database=Test"))
        {
            aCon.Open();

            using (SqlCommand cmd = new SqlCommand(aSqlStr, aCon))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                
                while(dr.Read())
                {
                    aPassWord = dr["Password"].ToString();
                }
                dr.Close();
            }

            Response.Write(aPassWord);
        }

            return "";
    }
}
