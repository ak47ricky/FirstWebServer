using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string vPath = "d:\\Pic\\";

        //string zPath = Request.PhysicalApplicationPath;

        //System.IO.Directory.CreateDirectory(zPath + "1234");

        //foreach (string f in Request.Files.AllKeys)
        //{
        //    HttpPostedFile file = Request.Files[f];

        //    file.SaveAs(vPath + "1234\\" + file.FileName);
        //}

        string vTest = string.Empty;

        string aSqlStr = string.Format("Select * FROM Uncle");
        using (SqlConnection aCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileRocky;PASSWORD=Aa54380438!;database=RickyDataBase;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            aCon.Open();

            using (SqlCommand cmd = new SqlCommand(aSqlStr, aCon))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    vTest += string.Format("PlayerID{0} : Age{1} </br>", dr["PlayerID"], dr["Age"]);
                }
                dr.Close();

            }
        }

        Response.Write(vTest);
    }
}